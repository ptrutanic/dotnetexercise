import { useEffect } from "react";
import axios from "axios";
import { useAuth0 } from "@auth0/auth0-react";

export function useAxiosInterceptor() {
  const { getAccessTokenSilently, logout } = useAuth0();

  useEffect(() => {
    const interceptor = axios.interceptors.request.use(
      async (config) => {
        try {
          const token = await getAccessTokenSilently();

          config.headers.Authorization = `Bearer ${token}`;
        } catch (error) {
          console.error("Failed to get access token", error);
          logout();
        }
        return config;
      },
      (error) => {
        return Promise.reject(error);
      }
    );

    return () => {
      axios.interceptors.request.eject(interceptor);
    };
  }, [getAccessTokenSilently, logout]);
}

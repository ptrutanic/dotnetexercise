import { useAuth0 } from "@auth0/auth0-react";
import { useEffect } from "react";
import { useAxiosInterceptor } from "./hooks/useAxiosInterceptor";
import axios from "axios";

function App() {
  const { user, isAuthenticated, loginWithRedirect, logout } = useAuth0();

  useAxiosInterceptor();

  useEffect(() => {
    if (user && isAuthenticated) {
      console.log(user);
    }
  }, [isAuthenticated, user]);

  const callProducts = () => {
    axios.get("http://localhost:5269/api/product").then((data) => {
      console.log(data);
    });
  };

  return (
    <div>
      <h1>Welcome</h1>
      <button onClick={() => loginWithRedirect()}>Log In</button>
      {isAuthenticated && user && (
        <div>
          <button onClick={() => logout()}>Log Out</button>
          <button onClick={() => callProducts()}>Data Fetch</button>
          <img src={user.picture} alt={user.name} />
          <h2>{user.name}</h2>
          <p>{user.email}</p>
        </div>
      )}
    </div>
  );
}

export default App;

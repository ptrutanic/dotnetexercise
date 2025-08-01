import { useAuth0 } from "@auth0/auth0-react";
import { useEffect } from "react";

function App() {
  const { user, isAuthenticated, loginWithRedirect, getAccessTokenSilently } =
    useAuth0();

  useEffect(() => {
    if (user && isAuthenticated) {
      getAccessTokenSilently().then((token) => {
        console.log("Access Token:", token);
      });
    }
  }, [getAccessTokenSilently, isAuthenticated, user]);

  return (
    <div>
      <h1>Welcome</h1>
      <button onClick={() => loginWithRedirect()}>Log In</button>
      {isAuthenticated && user && (
        <div>
          <img src={user.picture} alt={user.name} />
          <h2>{user.name}</h2>
          <p>{user.email}</p>
        </div>
      )}
    </div>
  );
}

export default App;

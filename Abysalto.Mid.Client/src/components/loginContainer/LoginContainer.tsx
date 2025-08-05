import { useAuth0 } from "@auth0/auth0-react";
import { Button } from "@mui/material";
import "./LoginContainer.css";

export default function LoginContainer() {
  const { user, isAuthenticated, loginWithRedirect, logout } = useAuth0();

  return (
    <div className="login-container">
      {isAuthenticated && user ? (
        <>
          <p className="username">{user.name}</p>
          <Button color="inherit" variant="outlined" onClick={() => logout()}>
            Log Out
          </Button>
        </>
      ) : (
        <Button
          color="inherit"
          variant="outlined"
          onClick={() => loginWithRedirect()}
        >
          Login
        </Button>
      )}
    </div>
  );
}

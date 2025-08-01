import { createRoot } from "react-dom/client";
import "./index.css";
import App from "./App.tsx";
import { StrictMode } from "react";
import { Auth0Provider } from "@auth0/auth0-react";
import config from "./config.ts";

createRoot(document.getElementById("root")!).render(
  <StrictMode>
    <Auth0Provider
      domain={config.auth0Domain}
      clientId={config.auth0ClientId}
      authorizationParams={{
        redirect_uri: window.location.origin,
        // audience: "https://thatsoservo.eu.auth0.com/api/v2/",
        // scope: "read:current_user update:current_user_metadata",
      }}
    >
      <App />
    </Auth0Provider>
  </StrictMode>
);

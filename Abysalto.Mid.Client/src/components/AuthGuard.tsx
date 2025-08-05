import { useAuth0 } from "@auth0/auth0-react";

interface AuthGuardProps {
  children?: React.ReactNode;
}

export default function AuthGuard({ children }: AuthGuardProps) {
  const { isAuthenticated, isLoading } = useAuth0();

  if (isLoading) return null;

  return isAuthenticated ? children : null;
}

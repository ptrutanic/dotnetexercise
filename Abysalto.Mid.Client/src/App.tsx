import { useAxiosInterceptor } from "./hooks/useAxiosInterceptor";
import Navbar from "./components/Navbar";
import ProductList from "./components/productList/ProductList";
import AuthGuard from "./components/AuthGuard";

function App() {
  useAxiosInterceptor();

  return (
    <div>
      <Navbar />
      <AuthGuard>
        <ProductList />
      </AuthGuard>
    </div>
  );
}

export default App;

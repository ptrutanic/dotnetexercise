import { useAxiosInterceptor } from "./hooks/useAxiosInterceptor";
import Navbar from "./components/Navbar";
import ProductList from "./components/productList/ProductList";
import AuthGuard from "./components/AuthGuard";
import Cart from "./components/cart/Cart";
import { CartContext } from "./context/CartContext";
import { useCart } from "./hooks/useCart";

function App() {
  useAxiosInterceptor();
  const { cart, loading, reload, addToCart, removeFromCart } = useCart();

  return (
    <CartContext value={{ cart, loading, reload, addToCart, removeFromCart }}>
      <Navbar />
      <AuthGuard>
        <Cart />
        <ProductList />
      </AuthGuard>
    </CartContext>
  );
}

export default App;

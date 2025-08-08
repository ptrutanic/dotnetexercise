import { useEffect, useRef, useState } from "react";
import type { Cart } from "../models/Cart";
import { getCart, updateCart } from "../api/cart";
import type {
  CartItemRequestModel,
  CartRequestModel,
} from "../models/CartRequest";

export const useCart = () => {
  const [cart, setCart] = useState<Cart>();
  const [loading, setLoading] = useState<boolean>(false);
  const [error, setError] = useState<string>("");

  const cartFirstLoaded = useRef(false);
  const controllerRef = useRef<AbortController | null>(null);

  const fetchCart = async () => {
    setLoading(true);
    setError("");

    if (controllerRef.current) {
      controllerRef.current.abort();
    }
    const controller = new AbortController();
    controllerRef.current = controller;

    try {
      const response = await getCart();
      if (!response.data) throw new Error("Failed to fetch");
      const result: Cart = response.data;
      setCart(result);
    } catch (err: unknown) {
      if (err instanceof Error && err.name !== "AbortError") {
        setError(err.message || "Error fetching data");
      } else if (!(err instanceof Error)) {
        setError("Unknown error occurred");
      }
    } finally {
      setLoading(false);
    }
  };

  useEffect(() => {
    if (!cartFirstLoaded.current) {
      cartFirstLoaded.current = true;
      fetchCart();
    }

    return () => {
      if (controllerRef.current) controllerRef.current.abort();
    };
  }, []);

  const addToCart = async (productId: number) => {
    const newProduct: CartItemRequestModel = { productId, quantity: 1 };
    const cartItems = cart?.cartItems ?? [];

    const existing = cartItems.find((item) => item.productId === productId);

    const newCart: CartRequestModel = {
      cartItems: existing
        ? cartItems.map((item) =>
            item.productId === productId
              ? { ...item, quantity: item.quantity + 1 }
              : item
          )
        : [...cartItems, newProduct],
    };

    const response = await updateCart(newCart);
    if (!response.data) throw new Error("Failed to fetch");
    const result: Cart = response.data;
    setCart(result);
  };

  return { cart, loading, error, reload: fetchCart, addToCart };
};

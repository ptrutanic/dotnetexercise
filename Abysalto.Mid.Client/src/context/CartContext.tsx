import { createContext } from "react";
import type { Cart } from "../models/Cart";

export type CartContext = {
  cart: Cart | undefined;
  loading: boolean;
  reload: () => void;
  addToCart: (productId: number) => void;
};

const defaultCartContext: CartContext = {
  cart: undefined,
  loading: false,
  reload: () => {},
  addToCart: () => {},
};

export const CartContext = createContext<CartContext>(defaultCartContext);

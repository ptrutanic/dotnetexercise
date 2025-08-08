export type Cart = {
  cartItems: CartItem[];
  totalPrice: number;
};

export type CartItem = {
  productId: number;
  quantity: number;
  totalPrice: number;
  pricePerItem: number;
  title: number;
};

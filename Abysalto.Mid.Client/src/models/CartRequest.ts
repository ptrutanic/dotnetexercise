export type CartRequestModel = {
  cartItems: CartItemRequestModel[];
};

export type CartItemRequestModel = {
  productId: number;
  quantity: number;
};

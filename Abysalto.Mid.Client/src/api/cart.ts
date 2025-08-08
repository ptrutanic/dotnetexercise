import axios from "axios";
import config from "../config.ts";
import type { CartRequestModel } from "../models/CartRequest.ts";

const updateCart = (cart: CartRequestModel) => {
  return axios.post(`${config.serverApiUrl}/cart`, cart);
};

const getCart = () => {
  return axios.get(`${config.serverApiUrl}/cart`);
};

export { updateCart, getCart };

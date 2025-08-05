import axios from "axios";
import config from "../config.ts";

const getProducts = (page: number = 1) => {
  return axios.get(`${config.serverApiUrl}/product?page=${page}`);
};

const getProduct = (id: number) => {
  return axios.get(`${config.serverApiUrl}/product/${id}`);
};

export { getProducts, getProduct };

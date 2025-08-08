import axios from "axios";
import config from "../config.ts";
import { PriceSortType } from "../constants/PriceSortType.ts";

const getProducts = (page: number = 1, priceSort?: PriceSortType) => {
  const sortByPrice = priceSort && `&sortByPrice=${priceSort}`;
  return axios.get(`${config.serverApiUrl}/product?page=${page}${sortByPrice}`);
};

const getProduct = (id: number) => {
  return axios.get(`${config.serverApiUrl}/product/${id}`);
};

const favoriteProduct = (id: number) => {
  return axios.post(`${config.serverApiUrl}/product/favorite`, {
    id,
  });
};

export { getProducts, getProduct, favoriteProduct };

export type ProductListResult = {
  products: ProductListProduct[];
  total: number;
};

export type ProductListProduct = {
  id: number;
  title: string;
  price: number;
  thumbnail: string;
  isFavorite: boolean;
};

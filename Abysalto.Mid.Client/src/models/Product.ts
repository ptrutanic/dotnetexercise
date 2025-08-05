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

export type ProductWithDetails = {
  id: number;
  title: string;
  price: number;
  thumbnail: string;
  description: string;
  brand: string;
  rating: number;
};

export type ProductFavoriteResponse = {
  isFavorite: boolean;
};

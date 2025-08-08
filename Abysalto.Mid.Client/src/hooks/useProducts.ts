import { useEffect, useRef, useState } from "react";
import { PriceSortType } from "../constants/PriceSortType";
import type { ProductListProduct, ProductListResult } from "../models/Product";
import { getProducts } from "../api/products";

export const useProducts = (page: number, priceSortType: PriceSortType) => {
  const [products, setProducts] = useState<ProductListProduct[]>([]);
  const [total, setTotal] = useState<number>(0);
  const [loading, setLoading] = useState<boolean>(false);
  const [error, setError] = useState<string>("");

  const lastFetchParams = useRef<{
    page: number;
    priceSortType: PriceSortType;
  } | null>(null);

  useEffect(() => {
    const controller = new AbortController();

    const paramsDidUpdate = () => {
      return !(
        lastFetchParams.current &&
        lastFetchParams.current.page === page &&
        lastFetchParams.current.priceSortType == priceSortType
      );
    };

    if (!paramsDidUpdate()) return;
    const prevParams = lastFetchParams.current;
    lastFetchParams.current = { page, priceSortType };

    const fetchData = async () => {
      setLoading(true);
      setError("");

      try {
        const response = await getProducts(page, priceSortType);
        if (!response.data) throw new Error("Failed to fetch");
        const result: ProductListResult = await response.data;

        if (prevParams?.priceSortType !== priceSortType) {
          setProducts(result.products);
        } else {
          setProducts((previousProducts) => [
            ...previousProducts,
            ...result.products,
          ]);
        }

        setTotal(result.total);
      } catch (err: unknown) {
        if (err instanceof Error && err.name !== "AbortError") {
          setError(err.message || "Error fetching data");
        } else {
          setError("Unknown error occurred");
        }
      } finally {
        setLoading(false);
      }
    };

    fetchData();

    return () => controller.abort();
  }, [page, priceSortType]);

  return { products, total, loading, error };
};

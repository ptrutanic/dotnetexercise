import { useEffect, useRef, useState } from "react";
import type { ProductWithDetails } from "../models/Product";
import { getProduct } from "../api/products";

export const useProduct = (productId: number) => {
  const [product, setProduct] = useState<ProductWithDetails>();
  const [loading, setLoading] = useState<boolean>(false);
  const [error, setError] = useState<string>("");

  const lastFetchParams = useRef<{
    productId: number;
  } | null>(null);

  useEffect(() => {
    const controller = new AbortController();

    const paramsDidUpdate = () => {
      return !(
        lastFetchParams.current &&
        lastFetchParams.current.productId === productId
      );
    };

    if (!paramsDidUpdate()) return;
    lastFetchParams.current = { productId };

    const fetchData = async () => {
      setLoading(true);
      setError("");

      try {
        const response = await getProduct(productId);
        if (!response.data) throw new Error("Failed to fetch");
        const result: ProductWithDetails = await response.data;
        setProduct(result);
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
  }, [productId]);

  return { product, loading, error };
};

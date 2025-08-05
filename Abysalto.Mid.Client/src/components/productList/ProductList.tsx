import { useCallback, useEffect, useRef, useState } from "react";
import "./ProductList.css";
import { getProducts } from "../../api/products";
import type {
  ProductListProduct,
  ProductListResult,
} from "../../models/Product";
import { Button, CircularProgress } from "@mui/material";
import Product from "../product/Product";

export default function ProductList() {
  const [products, setProducts] = useState<ProductListProduct[]>([]);
  const [total, setTotal] = useState(0);
  const [loading, setLoading] = useState(true);
  const [page, setPage] = useState(1);

  const hasLoadedOnce = useRef(false);

  const loadProducts = useCallback(async (page: number = 1) => {
    try {
      const result: ProductListResult = (await getProducts(page)).data;
      setTotal(result.total);
      setProducts((prevProducts) => [...prevProducts, ...result.products]);
    } catch (err) {
      console.error("Failed to load products:", err);
    } finally {
      setLoading(false);
    }
  }, []);

  const loadMoreProducts = () => {
    if (loading || products.length >= total) return;

    setLoading(true);
    const newPage = page + 1;
    setPage(newPage);
    loadProducts(newPage);
  };

  useEffect(() => {
    if (hasLoadedOnce.current) return;
    hasLoadedOnce.current = true;
    loadProducts();
  }, [loadProducts]);

  return (
    <div>
      <h2>Products</h2>
      <h3>
        Loaded {products.length}/{total}
      </h3>
      <div className="product-list">
        {products.map((product) => (
          <Product key={product.id} product={product} />
        ))}
      </div>
      <Button
        variant="contained"
        disabled={loading || products.length >= total}
        onClick={() => loadMoreProducts()}
      >
        Load More
      </Button>
    </div>
  );
  return loading ? <CircularProgress /> : <div>Loaded</div>;
}

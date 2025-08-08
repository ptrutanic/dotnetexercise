import { useCallback, useEffect, useRef, useState } from "react";
import "./ProductList.css";
import { getProducts } from "../../api/products";
import type {
  ProductListProduct,
  ProductListResult,
} from "../../models/Product";
import { Button, Typography } from "@mui/material";
import Product from "../product/Product";
import ProductSort from "../productSort/ProductSort";
import { PriceSortType } from "../../constants/PriceSortType";

export default function ProductList() {
  const [products, setProducts] = useState<ProductListProduct[]>([]);
  const [total, setTotal] = useState(0);
  const [loading, setLoading] = useState(true);
  const [page, setPage] = useState(1);

  const hasLoadedOnce = useRef(false);

  const loadProducts = useCallback(async (page: number = 1) => {
    try {
      const result: ProductListResult = (
        await getProducts(page, PriceSortType.HIGHER_FIRST)
      ).data;
      setTotal(result.total);
      setProducts((prevProducts) => [...prevProducts, ...result.products]);
    } catch (err) {
      console.error("Failed to load products:", err);
    } finally {
      setLoading(false);
    }
  }, []);

  const handleProductSort = (priceSortType: PriceSortType) => {
    console.log(priceSortType);
  };

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
      <Typography variant="h2">Products</Typography>
      <Typography variant="subtitle1">
        Loaded {products.length}/{total}
      </Typography>
      <ProductSort onChange={handleProductSort} />
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
}

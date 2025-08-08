import { useState } from "react";
import "./ProductList.css";
import { Button, Typography } from "@mui/material";
import Product from "../product/Product";
import ProductSort from "../productSort/ProductSort";
import { PriceSortType } from "../../constants/PriceSortType";
import { useProducts } from "../../hooks/useProducts";

export default function ProductList() {
  const [page, setPage] = useState(1);
  const [priceSortType, setPriceSortType] = useState<PriceSortType>(
    PriceSortType.DEFAULT
  );
  const { products, loading, total, error } = useProducts(page, priceSortType);

  const loadMoreProducts = () => {
    if (loading || products.length >= total) return;
    setPage((previousPage) => previousPage + 1);
  };

  const handleProductSort = (sortType: PriceSortType) => {
    setPage(1);
    setPriceSortType(sortType);
  };

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

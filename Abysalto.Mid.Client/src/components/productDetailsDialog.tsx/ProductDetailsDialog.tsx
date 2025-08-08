import {
  CircularProgress,
  Dialog,
  DialogTitle,
  Typography,
} from "@mui/material";
import { useCallback, useEffect, useRef, useState } from "react";
import type { ProductWithDetails } from "../../models/Product";
import { getProduct } from "../../api/products";
import "./ProductDetailsDialog.css";
import { getCart, updateCart } from "../../api/cart";

interface ProductDetailsDialogProps {
  productId: number;
  handleClose: () => void;
  open: boolean;
}

export default function ProductDetailsDialog({
  productId,
  handleClose,
  open,
}: ProductDetailsDialogProps) {
  const [product, setProduct] = useState<ProductWithDetails>();
  const [loading, setLoading] = useState(true);

  const hasLoadedOnce = useRef(false);

  const loadProduct = useCallback(async () => {
    try {
      // const cart1 = (await getCart()).data;
      const cart = (
        await updateCart({
          cartItems: [
            { productId: 1, quantity: 2 },
            { productId: 3, quantity: 6 },
            { productId: 3, quantity: 6 },
            { productId: 2, quantity: 6 },
          ],
        })
      ).data;
      const result: ProductWithDetails = (await getProduct(productId)).data;
      setProduct(result);
    } catch (err) {
      console.error("Failed to load product:", err);
    } finally {
      setLoading(false);
    }
  }, [productId]);

  useEffect(() => {
    if (hasLoadedOnce.current) return;
    hasLoadedOnce.current = true;
    loadProduct();
  }, [loadProduct]);

  return (
    <Dialog onClose={handleClose} open={open}>
      {loading || !product ? (
        <CircularProgress />
      ) : (
        <div className="product-details-container">
          <DialogTitle>{product.title}</DialogTitle>
          <img src={product.thumbnail} alt={product.title} />
          <Typography gutterBottom variant="subtitle1" component="div">
            {product.description}
          </Typography>
          <Typography
            sx={{ fontWeight: "bold" }}
            gutterBottom
            variant="body1"
            component="div"
          >
            Rating: {product.rating}/5
          </Typography>
          <Typography
            sx={{ fontWeight: "bold" }}
            gutterBottom
            variant="body1"
            component="div"
          >
            Price: {product.price} €
          </Typography>
        </div>
      )}
    </Dialog>
  );
}

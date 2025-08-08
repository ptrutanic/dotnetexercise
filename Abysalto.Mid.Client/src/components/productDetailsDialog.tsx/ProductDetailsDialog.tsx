import {
  CircularProgress,
  Dialog,
  DialogTitle,
  Typography,
} from "@mui/material";
import "./ProductDetailsDialog.css";
import { useProduct } from "../../hooks/useProduct";

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
  const { product, loading } = useProduct(productId);

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

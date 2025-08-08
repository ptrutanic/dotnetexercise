import {
  Card,
  CardActionArea,
  CardActions,
  CardContent,
  CardMedia,
  Typography,
} from "@mui/material";
import type {
  ProductFavoriteResponse,
  ProductListProduct,
} from "../../models/Product";
import StarOutlineIcon from "@mui/icons-material/StarOutline";
import StarIcon from "@mui/icons-material/Star";
import "./ProductCard.css";
import { useContext, useState } from "react";
import { favoriteProduct } from "../../api/products";
import ProductDetailsDialog from "../productDetailsDialog.tsx/ProductDetailsDialog";
import AddShoppingCartIcon from "@mui/icons-material/AddShoppingCart";
import { CartContext } from "../../context/CartContext";

interface ProductCardProps {
  product: ProductListProduct;
}

export default function ProductCard({ product }: ProductCardProps) {
  const [isFavorite, setIsFavorite] = useState(product.isFavorite);
  const { addToCart } = useContext(CartContext);

  const [isDetailsDialogOpen, setIsDetailsDialogOpen] =
    useState<boolean>(false);

  const handleFavoriteProduct = async () => {
    const result: ProductFavoriteResponse = (await favoriteProduct(product.id))
      .data;
    setIsFavorite(result.isFavorite);
  };

  const toggleProductDetailsDialog = async (isOpen: boolean) => {
    setIsDetailsDialogOpen(isOpen);
  };

  return (
    <div className="product-container">
      {isDetailsDialogOpen && (
        <ProductDetailsDialog
          productId={product.id}
          open={isDetailsDialogOpen}
          handleClose={() => toggleProductDetailsDialog(false)}
        />
      )}
      <Card sx={{ width: 300 }}>
        <CardActionArea onClick={() => toggleProductDetailsDialog(true)}>
          <CardMedia
            sx={{
              width: 100,
              marginLeft: "auto",
              marginRight: "auto",
            }}
            component="img"
            alt={product.title}
            image={product.thumbnail}
          />
          <CardContent>
            <Typography gutterBottom variant="h5" component="div">
              {product.title}
            </Typography>
          </CardContent>
        </CardActionArea>
        <CardActions sx={{ display: "flex", justifyContent: "space-between" }}>
          <div className="card-actions">
            <div
              style={{ cursor: "pointer" }}
              onClick={() => handleFavoriteProduct()}
            >
              {isFavorite ? <StarIcon /> : <StarOutlineIcon />}
            </div>
            <div
              style={{ cursor: "pointer" }}
              onClick={() => addToCart(product.id)}
            >
              <AddShoppingCartIcon />
            </div>
          </div>
          <Typography>{product.price} €</Typography>
        </CardActions>
      </Card>
    </div>
  );
}

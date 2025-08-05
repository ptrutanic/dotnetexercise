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
import "./Product.css";
import { useState } from "react";
import { favoriteProduct } from "../../api/products";

interface ProductProps {
  product: ProductListProduct;
}

export default function Product({ product }: ProductProps) {
  const [isFavorite, setIsFavorite] = useState(product.isFavorite);

  const handleFavoriteProduct = async () => {
    const result: ProductFavoriteResponse = (await favoriteProduct(product.id))
      .data;
    setIsFavorite(result.isFavorite);
  };

  return (
    <div className="product-container">
      <Card sx={{ width: 300 }}>
        <CardActionArea>
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
          <div onClick={() => handleFavoriteProduct()}>
            {isFavorite ? <StarIcon /> : <StarOutlineIcon />}
          </div>
          <Typography>{product.price} €</Typography>
        </CardActions>
      </Card>
    </div>
  );
}

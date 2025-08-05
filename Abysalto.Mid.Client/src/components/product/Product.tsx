import {
  Card,
  CardActionArea,
  CardActions,
  CardContent,
  CardMedia,
  Typography,
} from "@mui/material";
import type { ProductListProduct } from "../../models/Product";
import StarOutlineIcon from "@mui/icons-material/StarOutline";
import StarIcon from "@mui/icons-material/Star";
import "./Product.css";

interface ProductProps {
  product: ProductListProduct;
}

export default function Product({ product }: ProductProps) {
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
          {product.isFavorite ? <StarIcon /> : <StarOutlineIcon />}
          <Typography>{product.price} €</Typography>
        </CardActions>
      </Card>
    </div>
  );
}

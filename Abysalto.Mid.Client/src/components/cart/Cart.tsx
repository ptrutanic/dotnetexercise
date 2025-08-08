import {
  Button,
  CircularProgress,
  Table,
  TableBody,
  TableCell,
  TableHead,
  TableRow,
  Typography,
} from "@mui/material";
import "./Cart.css";
import { useContext } from "react";
import { CartContext } from "../../context/CartContext";
import RemoveIcon from "@mui/icons-material/Remove";
import AddIcon from "@mui/icons-material/Add";

export default function Cart() {
  const { cart, loading, reload, addToCart, removeFromCart } =
    useContext(CartContext);

  return (
    <div>
      <Typography variant="h2">Cart</Typography>
      <Button onClick={() => reload()}>Reload</Button>
      {loading || !cart ? (
        <CircularProgress />
      ) : (
        <div>
          <Typography variant="h5">Total: {cart.totalPrice} €</Typography>
          <Typography variant="h5">Cart Items:</Typography>
          <Table
            sx={{ minWidth: 650, maxWidth: 1000 }}
            aria-label="simple table"
          >
            <TableHead>
              <TableRow>
                <TableCell>Title</TableCell>
                <TableCell align="right">Quantity</TableCell>
                <TableCell align="right">Price Per Item</TableCell>
                <TableCell align="right">Total Price</TableCell>
              </TableRow>
            </TableHead>
            <TableBody>
              {cart.cartItems.map((cartItem) => (
                <TableRow
                  key={cartItem.productId}
                  sx={{ "&:last-child td, &:last-child th": { border: 0 } }}
                >
                  <TableCell component="th" scope="row">
                    {cartItem.title}
                  </TableCell>
                  <TableCell align="right">{cartItem.quantity}</TableCell>
                  <TableCell align="right">{cartItem.pricePerItem}</TableCell>
                  <TableCell align="right">{cartItem.totalPrice}</TableCell>
                  <TableCell align="right">
                    <div onClick={() => removeFromCart(cartItem.productId)}>
                      <RemoveIcon sx={{ cursor: "pointer" }} />
                    </div>
                    <div onClick={() => addToCart(cartItem.productId)}>
                      <AddIcon sx={{ cursor: "pointer" }} />
                    </div>
                  </TableCell>
                </TableRow>
              ))}
            </TableBody>
          </Table>
        </div>
      )}
    </div>
  );
}

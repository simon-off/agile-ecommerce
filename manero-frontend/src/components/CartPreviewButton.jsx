import { ShoppingBag } from "lucide-react";
import { Link } from "react-router-dom";
import { useCart } from "../hooks/useCart";

export default function CartPreviewButton() {
  const { cart } = useCart();

  return (
    <Link to="/cart" className={`cart-button ${cart.length == 0 ? "hidden" : ""}`}>
      <ShoppingBag />
      <span className="cart-button-amount">{cart.reduce((a, b) => a + b.amount, 0)}</span>
    </Link>
  );
}

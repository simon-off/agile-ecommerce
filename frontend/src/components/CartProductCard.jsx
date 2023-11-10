import { Minus, Plus } from "lucide-react";
import { apiDomain } from "../helpers/apiDomain";
import { Link } from "react-router-dom";
import { useCart } from "../hooks/useCart";

export function CartProductCard({ cartItem }) {
  const { incrementCartItemAmount, decrementCartItemAmount } = useCart();

  return (
    <div className="cart-product-card">
      <Link to={`/products/${cartItem.id}`}>
        <img src={apiDomain.https + cartItem.imagePaths[0]} alt="" />
        <div className="info">
          <p>{cartItem.name}</p>
          <span>${cartItem.price}</span>
          <span>Size: {cartItem.size}</span>
        </div>
      </Link>
      <div className="buttons">
        <button onClick={() => incrementCartItemAmount(cartItem.itemId)}>
          <Plus size={16} />
        </button>
        <span>{cartItem.amount}</span>
        <button onClick={() => decrementCartItemAmount(cartItem.itemId)}>
          <Minus size={16} />
        </button>
      </div>
    </div>
  );
}

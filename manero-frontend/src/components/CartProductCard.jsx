import { Minus, Plus } from "lucide-react";
import { apiDomain } from "../helpers/api-domain";

export function CartProductCard({ cartItem }) {
  return (
    <div className="cart-product-card">
      <img src={apiDomain.https + cartItem.imagePaths[0]} alt="" />
      <div className="info">
        <p>{cartItem.name}</p>
        <span>${cartItem.price}</span>
        <span>Size: {cartItem.size}</span>
      </div>
      <div className="buttons">
        <button>
          <Plus size={16} />
        </button>
        {/* TODO: Fix this */}
        <span>{cartItem.amount || 1}</span>
        <button>
          <Minus size={16} />
        </button>
      </div>
    </div>
  );
}

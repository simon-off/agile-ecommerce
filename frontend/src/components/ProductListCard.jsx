import { Heart, ShoppingBag, Star } from "lucide-react";
import { apiDomain } from "../helpers/api-domain";
import { Link } from "react-router-dom";
import { useCart } from "../hooks/useCart";
import { useWishlist } from "../hooks/useWishlist";

export default function ProductListCard({ product }) {
  const { addToCart, isInCart, removeProductFromCart } = useCart();
  const { addToWishlist, isInWishlist, removeFromWishlist } = useWishlist();

  const handleShoppingBagClick = (e) => {
    e.preventDefault();
    if (isInCart(product.id)) {
      removeProductFromCart(product.id);
    } else {
      addToCart(product);
    }
  };

  const handleWishlistClick = (e) => {
    e.preventDefault();
    if (isInWishlist(product.id)) {
      removeFromWishlist(product.id);
    } else {
      addToWishlist(product);
    }
  };

  return (
    <Link to={`/products/${product.id}`}>
      <div className="product-list-card">
        <div className="product-card-image-wrapper">
          <img src={apiDomain.https + product.imagePaths[0]} alt={product.name} />
        </div>
        <div className="product-card-details">
          <p id="b" className="product-name">
            {product.name}
          </p>
          <p id="c" className="product-price">
            $ {product.price}
          </p>
          <div id="a" className="product-card-rating">
            <Star color="orange" />
            <Star color="orange" />
            <Star color="orange" />
            <Star color="orange" />
            <Star color="orange" />
            <span className="product-card-reviews">(3)</span>
          </div>
        </div>
        <div className="product-card-icons">
          <button onClick={handleWishlistClick}>
            <Heart style={{ color: isInWishlist(product.id) ? "var(--color-red)" : "" }} />
          </button>
          <button onClick={handleShoppingBagClick}>
            <ShoppingBag
              style={{ color: isInCart(product.id) ? "green" : "var(--color-succes)" }}
            />
          </button>
        </div>
      </div>
    </Link>
  );
}

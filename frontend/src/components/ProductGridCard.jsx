import { Heart, ShoppingBag, Star } from "lucide-react";
import { apiDomain } from "../helpers/apiDomain";
import { Link } from "react-router-dom";
import { useCart } from "../hooks/useCart";
import { useWishlist } from "../hooks/useWishlist";

export default function ProductGridCard({ product }) {
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
      <div className="product-grid-card">
        <div className="product-card-image-wrapper">
          <img src={apiDomain.https + product.imagePaths[0]} alt={product.name} />
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
        <div className="product-card-details">
          <div id="a" className="product-card-rating">
            <Star color="orange" />
            <Star color="orange" />
            <Star color="orange" />
            <Star color="orange" />
            <Star color="orange" />
            <span className="product-card-reviews">(3)</span>
          </div>
          <p id="b" className="product-name">
            {product.name}
          </p>
          <p id="c" className="product-price">
            $ {product.price}
          </p>
        </div>
      </div>
    </Link>
  );
}

import { Heart, ShoppingBag, Star } from "lucide-react";
import { apiDomain } from "../helpers/api-domain";

export default function ProductCard({ product }) {
  return (
    <div className="product-card">
      <div className="product-card-image-wrapper">
        <img src={apiDomain.https + product.imagePaths[0]} alt={product.name} />
        <div className="product-card-icons">
          <Heart />
          <ShoppingBag />
        </div>
      </div>
      <div className="product-card-details">
        <div className="product-card-rating">
          <Star color="orange" />
          <Star color="orange" />
          <Star color="orange" />
          <Star color="orange" />
          <Star color="orange" />
          <span className="product-card-reviews">(3)</span>
        </div>
        <p className="product-name">{product.name}</p>
        <p>{product.price}</p>
      </div>
    </div>
  );
}

import { Heart } from "lucide-react";
import PageIconCircle from "../components/PageIconCircle";
import ProductListCard from "../components/ProductListCard";
import { useWishlist } from "../hooks/useWishlist";
import { Link } from "react-router-dom";

function WishList() {
  const { wishlist } = useWishlist();

  if (wishlist.length === 0)
    return (
      <section className="wishlist-page empty">
        <PageIconCircle icon={<Heart />} />
        <div>
          <h2>Your wishlist is empty!</h2>
          <p>Looks like you haven{"'"}t added any products yet.</p>
        </div>
        <Link to="/products" className="button button-black">
          Shop now
        </Link>
      </section>
    );

  return (
    <section className="wishlist-page not-empty">
      <div className="wishlist-container">
        {wishlist.map((product) => (
          <ProductListCard key={product.id} product={product} />
        ))}
      </div>
    </section>
  );
}

export default WishList;

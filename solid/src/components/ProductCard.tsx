import styles from "./ProductCard.module.scss";
import { convertToSlug } from "../helpers/utilities.ts";
import { API_URL } from "../helpers/constants";
import { A } from "@solidjs/router";
import { wishlistStore } from "../helpers/stores.ts";
import { Product } from "../types/product.ts";
import { FiHeart } from "solid-icons/fi";

interface ProductCardProps {
  product: Product;
}

export default function ProductCard({ product }: ProductCardProps) {
  const [wishlist, setWishlist] = wishlistStore;

  const isInWishlist = () => wishlist.some(x => x.id === product.id);

  const toggleItemInWishlist = () => {
    if (isInWishlist()) {
      setWishlist(wishlist.filter(x => x.id !== product.id));
    } else {
      setWishlist(wishlist.length, product);
    }
  };

  return (
    <article class={styles.card}>
      <A href={`/products/${convertToSlug(product.name)}`}>
        <img src={API_URL + product.imagePaths[0]} alt={product.name} />
        <div>
          <h3>{product.name}</h3>
          <span>${product.price}</span>
        </div>
      </A>
      <button
        id="toggle-wishlist-button"
        title={isInWishlist() ? "Remove from wishlist" : "Add to wishlist"}
        class={isInWishlist() ? styles.active : ""}
        onClick={() => toggleItemInWishlist()}
      >
        <FiHeart aria-labelledby="toggle-wishlist-button" />
      </button>
    </article>
  );
}

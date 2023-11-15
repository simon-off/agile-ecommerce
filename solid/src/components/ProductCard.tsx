import styles from "./ProductCard.module.scss";
import { convertToSlug } from "../helpers/convertToSlug.ts";
import { API_URL } from "../helpers/constants";
import { A } from "@solidjs/router";

interface ProductCardProps {
  product: {
    id: number;
    name: string;
    description: string;
    price: number;
    category: string;
    tags: string[];
    imagePaths: string[];
    availableSizes: string[];
  };
}

export default function ProductCard({ product }: ProductCardProps) {
  return (
    <article class={styles.card}>
      <A href={`/products/${convertToSlug(product.name)}`}>
        <img src={API_URL + product.imagePaths[0]} alt={product.name} />
        <div>
          <h3>{product.name}</h3>
          <span>${product.price}</span>
        </div>
      </A>
    </article>
  );
}

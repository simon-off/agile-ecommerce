import styles from "./ProductCard.module.scss";
import { API_URL } from "../helpers/constants";

interface ProductCardProps {
  product: {
    id: number;
    name: string;
    price: number;
    imagePaths: string[];
  };
}

export default function ProductCard({ product }: ProductCardProps) {
  console.log(product);

  return (
    <article class={styles.card}>
      <img src={API_URL + product.imagePaths[0]} alt="" />
      <div>
        <h3>{product.name}</h3>
        <span>${product.price}</span>
      </div>
    </article>
  );
}

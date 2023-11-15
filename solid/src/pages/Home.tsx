import styles from "./Home.module.scss";
import { For, Suspense, createResource } from "solid-js";
import LoadingSpinner from "../components/LoadingSpinner";
import ProductCard from "../components/ProductCard";
import { API_URL } from "../helpers/constants";

export default function Home() {
  const [products] = createResource(async () =>
    (await fetch(`${API_URL}/api/products`)).json()
  );

  return (
    <div class={`${styles.page} container`}>
      <h1>Products</h1>
      <section class={styles.products}>
        <Suspense fallback={<LoadingSpinner />}>
          <For each={products()}>
            {(product) => <ProductCard product={product} />}
          </For>
        </Suspense>
      </section>
    </div>
  );
}

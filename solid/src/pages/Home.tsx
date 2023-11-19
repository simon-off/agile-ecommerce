import styles from "./Home.module.scss";
import { For, Suspense, createResource } from "solid-js";
import LoadingSpinner from "../components/LoadingSpinner";
import ProductCard from "../components/ProductCard";
import { API_URL } from "../helpers/constants";
import { A } from "@solidjs/router";

const getProducts = async (query: string) =>
  (await fetch(`${API_URL}/api/products${query}`)).json();

export default function Home() {
  const [featured] = createResource(() => getProducts("?tag=featured"));
  const [popular] = createResource(() => getProducts("?tag=popular"));

  return (
    <div class={`${styles.page} container`}>
      <section>
        <Suspense fallback={<LoadingSpinner />}>
          <header>
            <h2>Featured</h2>
            <A href="products?tag=Featured">View all</A>
          </header>
          <div class={styles.gallery}>
            <For each={featured()}>{product => <ProductCard product={product} />}</For>
          </div>
        </Suspense>
      </section>
      <section>
        <Suspense fallback={<LoadingSpinner />}>
          <header>
            <h2>Popular</h2>
            <A href="products?tag=Popular">View all</A>
          </header>
          <div class={styles.gallery}>
            <For each={popular()}>{product => <ProductCard product={product} />}</For>
          </div>
        </Suspense>
      </section>
    </div>
  );
}

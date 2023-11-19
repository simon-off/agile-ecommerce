import { For, Show, Suspense, createMemo, createResource } from "solid-js";
import LoadingSpinner from "../components/LoadingSpinner";
import ThemedSelect from "../components/ThemedSelect";
import ProductCard from "../components/ProductCard";
import { useSearchParams } from "@solidjs/router";
import { API_URL } from "../helpers/constants";
import styles from "./Products.module.scss";
import { Product } from "../types/product";

const getFilterOptions = async (options: string) =>
  await (await fetch(`${API_URL}/api/${options}`)).json();

const getProducts = async (query: string) => {
  return (await fetch(`${API_URL}/api/products?${query}`)).json();
};

export default function products() {
  const [params, setParams] = useSearchParams();
  const query = createMemo(() =>
    Object.entries(params)
      .map(([key, value]) => `${key}=${value.toLowerCase().split(" ").join("")}`)
      .join("&")
  );

  const [categories] = createResource<string[], string>("categories", getFilterOptions);
  const [tags] = createResource<string[], string>("tags", getFilterOptions);
  const [products] = createResource<Product[], string>(query, getProducts);

  return (
    <div class={`${styles.page} container`}>
      <section class={styles.filters}>
        <Show when={categories()} keyed>
          {categories => (
            <label>
              <span>Categories</span>
              <ThemedSelect
                options={["All", ...categories]}
                defaultValue={params.category}
                onChange={value =>
                  setParams(value === "All" ? { category: undefined } : { category: value })
                }
              />
            </label>
          )}
        </Show>
        <Show when={tags()} keyed>
          {tags => (
            <label>
              <span>Tags</span>
              <ThemedSelect
                options={["All", ...tags]}
                defaultValue={params.tag}
                onChange={value => setParams(value === "All" ? { tag: undefined } : { tag: value })}
              />
            </label>
          )}
        </Show>
        <label>
          <span>Order</span>
          <ThemedSelect
            options={["Newest", "Lowest price", "Highest price"]}
            defaultValue={params.sort}
            onChange={value => setParams(value === "All" ? { sort: undefined } : { sort: value })}
          />
        </label>
      </section>
      <Suspense fallback={<LoadingSpinner />}>
        <Show when={products()?.length === 0}>No products</Show>
        <section class={styles.gallery}>
          <For each={products()}>{product => <ProductCard product={product} />}</For>
        </section>
      </Suspense>
    </div>
  );
}

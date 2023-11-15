import { For, Suspense, createResource } from "solid-js";
import LoadingSpinner from "./components/LoadingSpinner";
import "@fontsource-variable/inter";
import "./scss/main.scss";

export default function App() {
  const [data] = createResource(async () =>
    (await fetch("https://localhost:7270/api/products")).json()
  );

  return (
    <div class="container">
      <h1>Products</h1>
      <div class="test"></div>
      <Suspense fallback={<LoadingSpinner />}>
        <For each={data()}>
          {(item) => (
            <article>
              <p>{item.name}</p>
              <p>${item.price}</p>
            </article>
          )}
        </For>
      </Suspense>
    </div>
  );
}

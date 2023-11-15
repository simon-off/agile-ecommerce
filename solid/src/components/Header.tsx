import { FiShoppingBag, FiSearch } from "solid-icons/fi";
import { A } from "@solidjs/router";
import styles from "./Header.module.scss";

export default function Header() {
  return (
    <header class={styles.header}>
      <div class="container">
        <nav>
          <A href="/" class={styles.logo}>
            <picture>
              <source
                media="(min-width: 400px)"
                srcset="images/manero-logo-mobile.svg"
              />
              <img src="images/manero-logo-mobile.svg" alt="Manero logo" />
            </picture>
          </A>
          <A href="/">Link</A>
        </nav>
        <form action="">
          <input type="text" placeholder="Search for products..." />
          <button type="submit">
            <FiSearch />
          </button>
        </form>
        <button>
          <FiShoppingBag />
        </button>
      </div>
    </header>
  );
}

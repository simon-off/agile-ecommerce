import { FiShoppingBag, FiSearch, FiHeart } from "solid-icons/fi";
import { A, useNavigate } from "@solidjs/router";
import styles from "./Header.module.scss";
import { createSignal } from "solid-js";

export default function Header() {
  const [searchValue, setSearchValue] = createSignal("");
  const navigate = useNavigate();

  const handleSubmit = (e: SubmitEvent) => {
    e.preventDefault();
    if (searchValue()) navigate(`/products?q=${searchValue()}`);
  };

  return (
    <header class={styles.header}>
      <div class="container">
        <A href="/" class={styles.logo}>
          <img src="images/manero-logo-desktop.svg" alt="Manero logo" />
        </A>
        <form onSubmit={handleSubmit}>
          <input
            type="text"
            value={searchValue()}
            onInput={(e) => setSearchValue(e.currentTarget.value)}
            placeholder="Search for products..."
          />
          <button type="submit">
            <FiSearch />
          </button>
        </form>
        <button>
          <FiHeart />
        </button>
        <button>
          <FiShoppingBag />
        </button>
      </div>
    </header>
  );
}

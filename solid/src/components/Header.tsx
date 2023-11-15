import styles from "./Header.module.scss";

export default function Header() {
  return (
    <header class={styles.header}>
      <div class="container">
        <picture>
          <source
            media="(min-width: 400px)"
            srcset="images/manero-logo-desktop.svg"
          />
          <img src="images/manero-logo-mobile.svg" alt="Manero logo" />
        </picture>
      </div>
    </header>
  );
}

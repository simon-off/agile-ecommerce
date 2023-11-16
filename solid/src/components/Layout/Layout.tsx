import { Outlet } from "@solidjs/router";
import styles from "./Layout.module.scss";
import Header from "./Header";
import Footer from "./Footer";

export default function Layout() {
  return (
    <>
      <Header />
      <main class={styles.main}>
        <Outlet />
      </main>
      <Footer />
    </>
  );
}

import { Link, Outlet } from "react-router-dom";
import Navbar from "./Navbar";
import ContactBurgerMenu from "./ContactBurgerMenu";
import CartPreviewButton from "../CartPreviewButton";

function LayoutDesktop({ sidebarOpenState }) {
  return (
    <div className="layout layout-desktop">
      <header className="header desktop-header">
        <Link>
          <img className="logo" src="/images/manero-logo-desktop.svg" alt="" />
        </Link>
        <Navbar />
        <div className="cart-and-burger-buttons">
          <CartPreviewButton />
          <ContactBurgerMenu sidebarOpenState={sidebarOpenState} />
        </div>
      </header>
      <main className="container">
        <Outlet />
      </main>
      <footer className="footer"></footer>
    </div>
  );
}

export default LayoutDesktop;

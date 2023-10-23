import { Link, Outlet, useLocation, useNavigate } from "react-router-dom";
import ContactBurgerMenu from "./ContactBurgerMenu";
import { ChevronLeft } from "lucide-react";
import Navbar from "./Navbar";
import CartPreviewButton from "../CartPreviewButton";

const navbarRoutes = ["/", "/search", "/cart", "/wishlist", "/profile"];

function LayoutMobile({ sidebarOpenState }) {
  const location = useLocation();
  const navigate = useNavigate();
  return (
    <div className="layout layout-mobile">
      <header className="header mobile-header">
        {navbarRoutes.includes(location.pathname) ? (
          <>
            <ContactBurgerMenu sidebarOpenState={sidebarOpenState} />
            <Link to="/">
              <img className="logo" src="/images/manero-logo-mobile.svg" alt="" />
            </Link>
          </>
        ) : (
          <>
            <Link onClick={() => navigate(-1)}>
              <ChevronLeft />
            </Link>
            <h1>{location.pathname}</h1>
          </>
        )}
        <CartPreviewButton />
      </header>
      <main className="container">
        <Outlet />
      </main>
      <footer className="footer">
        <Navbar />
      </footer>
    </div>
  );
}

export default LayoutMobile;

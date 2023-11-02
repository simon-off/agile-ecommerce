import { Link, Outlet, useLocation, useNavigate } from "react-router-dom";
import ContactBurgerMenu from "./ContactBurgerMenu";
import { ChevronLeft } from "lucide-react";
import Navbar from "./Navbar";
import CartPreviewButton from "../CartPreviewButton";
import routes from "../../routes";

function LayoutMobile({ sidebarOpenState }) {
  const location = useLocation();
  const navigate = useNavigate();

  const pageTitle = routes?.find((route) => route.path == location.pathname)?.title;

  return (
    <div className="layout layout-mobile">
      <header className="header mobile-header">
        <div className="container">
          {pageTitle ? (
            <>
              <Link onClick={() => navigate(-1)}>
                <ChevronLeft />
              </Link>
              <h1>{pageTitle}</h1>
            </>
          ) : (
            <>
              <ContactBurgerMenu sidebarOpenState={sidebarOpenState} />
              <Link to="/">
                <img className="logo" src="/images/manero-logo-mobile.svg" alt="" />
              </Link>
            </>
          )}
          <CartPreviewButton />
        </div>
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

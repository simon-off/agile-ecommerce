import { BrowserRouter, Route, Routes } from "react-router-dom";
import "./scss/main.scss";
import "@fontsource-variable/mulish";
import useWindowResize from "./hooks/useWindowResize";
import { useState } from "react";
import LayoutMobile from "./components/Layout/LayoutMobile";
import LayoutDesktop from "./components/Layout/LayoutDesktop";
import routes from "./routes";
import { CartContextProvider } from "./hooks/useCart";
import { OrderContextProvider } from "./hooks/useOrder";
import { ToastContextProvider } from "./hooks/useToast";
import { WishlistContextProvider } from "./hooks/useWishlist";

function App() {
  // Added state for mobile/desktop
  const [isMobile, setIsMobile] = useState(false);
  const sidebarOpenState = useState(false);

  useWindowResize(() => {
    if (window.innerWidth < 840) {
      setIsMobile(true);
    } else {
      setIsMobile(false);
    }
  }, true);

  return (
    <ToastContextProvider>
      <WishlistContextProvider>
        <CartContextProvider>
          <OrderContextProvider>
            <BrowserRouter>
              <Routes>
                <Route
                  path="/"
                  element={
                    isMobile ? (
                      <LayoutMobile sidebarOpenState={sidebarOpenState} />
                    ) : (
                      <LayoutDesktop sidebarOpenState={sidebarOpenState} />
                    )
                  }
                >
                  {routes.map((route) => (
                    <Route key={route.path} path={route.path} element={route.element} />
                  ))}
                </Route>
              </Routes>
            </BrowserRouter>
          </OrderContextProvider>
        </CartContextProvider>
      </WishlistContextProvider>
    </ToastContextProvider>
  );
}

export default App;

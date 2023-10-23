import { BrowserRouter, Route, Routes } from "react-router-dom";
import "./scss/main.scss";
import "@fontsource-variable/mulish";
import useWindowResize from "./hooks/useWindowResize";
import { useState } from "react";
import LayoutMobile from "./components/Layout/LayoutMobile";
import LayoutDesktop from "./components/Layout/LayoutDesktop";
import routes from "./routes";
import { CartContextProvider } from "./hooks/useCart";

function App() {
  // Added state for mobile/desktop
  const [isMobile, setIsMobile] = useState(false);
  const sidebarOpenState = useState(false);

  useWindowResize(() => {
    if (window.innerWidth < 800) {
      setIsMobile(true);
    } else {
      setIsMobile(false);
    }
  }, true);

  return (
    <CartContextProvider>
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
    </CartContextProvider>
  );
}

export default App;

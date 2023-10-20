import { BrowserRouter, Route, Routes } from "react-router-dom";
import "./scss/main.scss";
import "@fontsource-variable/mulish";
import useWindowResize from "./hooks/useWindowResize";
import { createContext, useState } from "react";
import LayoutMobile from "./components/Layout/LayoutMobile";
import LayoutDesktop from "./components/Layout/LayoutDesktop";
import routes from "./routes";

export const CartContext = createContext(null);

function App() {
  // Added state for mobile/desktop
  const [isMobile, setIsMobile] = useState(false);
  const cartState = useState([]);

  useWindowResize(() => {
    if (window.innerWidth < 800) {
      setIsMobile(true);
    } else {
      setIsMobile(false);
    }
  }, true);

  return (
    <CartContext.Provider value={cartState}>
      <BrowserRouter>
        <Routes>
          <Route path="/" element={isMobile ? <LayoutMobile /> : <LayoutDesktop />}>
            {routes.map((route) => (
              <Route key={route.path} path={route.path} element={route.element} />
            ))}
          </Route>
        </Routes>
      </BrowserRouter>
    </CartContext.Provider>
  );
}

export default App;

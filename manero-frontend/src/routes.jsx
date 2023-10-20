import Cart from "./pages/Cart";
import Home from "./pages/Home";
import ProductDetails from "./pages/ProductDetails";
import Search from "./pages/Search";

const routes = [
  { path: "/", element: <Home /> },
  { path: "/search", element: <Search /> },
  { path: "/cart", element: <Cart /> },
  { path: "/products/:id", element: <ProductDetails /> },
  { path: "*", element: <h1>Not found</h1> },
];

export default routes;

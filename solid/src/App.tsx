import { Router, Route, Routes } from "@solidjs/router";
import "@fontsource-variable/inter";
import "./scss/main.scss";
import Home from "./pages/Home";
import Layout from "./components/Layout/Layout";
import products from "./pages/Products";

export default function App() {
  return (
    <Router>
      <Routes>
        <Route path="/" component={Layout}>
          <Route path="/" component={Home} />
          <Route path="/products" component={products} />
        </Route>
      </Routes>
    </Router>
  );
}

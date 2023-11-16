import { Router, Route, Routes } from "@solidjs/router";
import "@fontsource-variable/inter";
import "./scss/main.scss";
import Home from "./pages/Home";
import Layout from "./components/Layout/Layout";

export default function App() {
  return (
    <Router>
      <Routes>
        <Route path="/" component={Layout}>
          <Route path="/" component={Home} />{" "}
        </Route>
      </Routes>
    </Router>
  );
}

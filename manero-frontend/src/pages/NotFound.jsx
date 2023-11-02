import { Link } from "react-router-dom";

export default function NotFound() {
  return (
    <div className="not-found-page">
      <h1>Sorry! 😳</h1>
      <h2>This page does not exist...</h2>
      <Link to="/" className="button button-black">
        Go to homepage
      </Link>
    </div>
  );
}

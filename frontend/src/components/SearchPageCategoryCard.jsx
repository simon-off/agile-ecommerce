import { Link } from "react-router-dom";

export default function SearchPageCategoryCard({ category }) {
  return (
    <Link
      to={`/products?categoryName=${category.name.toLowerCase()}`}
      className="search-page-category-card"
    >
      <h2>{category.name}</h2>
    </Link>
  );
}

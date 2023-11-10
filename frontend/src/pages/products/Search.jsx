import SearchPageCategoryCard from "../../components/SearchPageCategoryCard";
import { apiDomain } from "../../helpers/apiDomain";
import useFetch from "../../hooks/useFetch";
import { Link } from "react-router-dom";

export default function Search() {
  const categories = useFetch(`${apiDomain.https}/api/categories`);
  const tags = useFetch(`${apiDomain.https}/api/tags`);

  return (
    <div className="search-page">
      <ul className="tags-container">
        {tags?.data?.map((tag) => (
          <li key={tag.name}>
            <Link to={`/products?tagName=${tag.name.toLowerCase()}`}>{tag.name}</Link>
          </li>
        ))}
      </ul>
      <div className="category-cards-container">
        {categories?.data?.map((category) => (
          <SearchPageCategoryCard key={category.name} category={category} />
        ))}
      </div>
    </div>
  );
}

import { SlidersHorizontal, Check, Square } from "lucide-react";
import { useNavigate } from "react-router-dom";
import useFetch from "../../hooks/useFetch";
import { apiDomain } from "../../helpers/api-domain";

function FilterBurgerMenu({ filterMenuOpenState }) {
  const [sidebarOpen, setSidebarOpen] = filterMenuOpenState;
  const navigate = useNavigate();
  const categories = useFetch(`${apiDomain.https}/api/categories`);
  const tags = useFetch(`${apiDomain.https}/api/tags`);

  const handleBurgerClick = () => {
    setSidebarOpen(!sidebarOpen);
  };

  const handleBackgroundClick = (e) => {
    if (e.target.classList.contains("open")) setSidebarOpen(false);
  };

  const handleQueryClick = (queryName, queryValue) => {
    const currentUrl = new URL(window.location.href);
    // Make everything lowercase otherwise queries.has() won't match
    let queries = new URLSearchParams(currentUrl.search.toLowerCase());
    queryName = queryName.toLowerCase();
    queryValue = queryValue.toLowerCase();

    if (queries.has(queryName, queryValue)) {
      queries.delete(queryName, queryValue);
    } else if (queries.has(queryName)) {
      queries.delete(queryName);
      queries.append(queryName, queryValue);
    } else {
      queries.append(queryName, queryValue);
    }

    navigate(`?${queries.toString()}`);
  };

  const isCurrentQuery = (queryName, queryValue) => {
    const currentUrl = new URL(window.location.href);
    // Make everything lowercase otherwise queries.has() won't match
    let queries = new URLSearchParams(currentUrl.search.toLowerCase());
    queryName = queryName.toLowerCase();
    queryValue = queryValue.toLowerCase();

    if (queries.has(queryName, queryValue)) {
      return true;
    }

    return false;
  };

  return (
    <>
      <button onClick={handleBurgerClick} className="filter-burger-button">
        <SlidersHorizontal />
        Filters
      </button>
      <div
        onClick={handleBackgroundClick}
        className={`${sidebarOpen ? "open" : "closed"} filter-bg`}
      ></div>
      <div className={`${sidebarOpen ? "open" : "closed"} filter-sidebar`}>
        <div className="container-filter-menu">
          <div className="category-container">
            <h2>Categories</h2>
            {categories.data?.map((category) => (
              <button
                key={category.name}
                onClick={() => handleQueryClick("categoryName", category.name)}
                aria-checked={isCurrentQuery("categoryName", category.name) ? true : false}
              >
                {category.name}
                <div className="checkbox-container">
                  <Square size={20} />
                  {isCurrentQuery("categoryName", category.name) && <Check size={20} />}
                </div>
              </button>
            ))}
          </div>
          <div className="tag-container">
            <h2>Tags</h2>
            {tags.data?.map((tag) => (
              <button key={tag.name} onClick={() => handleQueryClick("tagName", tag.name)}>
                {tag.name}
                <div className="checkbox-container">
                  <Square size={20} />
                  {isCurrentQuery("tagName", tag.name) && <Check size={18} />}
                </div>
              </button>
            ))}
          </div>
        </div>
      </div>
    </>
  );
}

export default FilterBurgerMenu;

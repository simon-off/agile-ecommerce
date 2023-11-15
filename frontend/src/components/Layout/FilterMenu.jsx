import { useNavigate } from "react-router-dom";
import useFetch from "../../hooks/useFetch";
import { apiDomain } from "../../helpers/apiDomain";
import useQuery from "../../hooks/useQuery";
import ThemedDropdown from "../ThemedDropdown";
import cleanQueryValue from "../../helpers/cleanQueryValue";

function FilterMenu({ menuExpanded }) {
  const navigate = useNavigate();
  const query = useQuery();

  const categories = useFetch(`${apiDomain.https}/api/categories`);
  const tags = useFetch(`${apiDomain.https}/api/tags`);

  const setCategoryQuery = (value) => {
    value === "all" ? query.delete("category") : query.set("category", value);
    query.delete("page");
    navigate(`?${query.toString()}`);
  };

  const setTagQuery = (value) => {
    query.has("tag", value) ? query.delete("tag") : query.set("tag", value);
    query.delete("page");
    navigate(`?${query.toString()}`);
  };

  return (
    <>
      <div className={`${menuExpanded ? "open" : "closed"} filter-menu`}>
        <div className="filter-menu-inner">
          <div className="category-container">
            <h2>Category</h2>
            <ThemedDropdown
              value={query.get("category") ?? "All"}
              options={["All", ...(categories.data?.map((category) => category) ?? [])]}
              onChange={(selected) => setCategoryQuery(cleanQueryValue(selected))}
            />
          </div>
          <div className="tag-container">
            <h2>Tags</h2>
            <div className="buttons">
              {tags.data?.map((tag) => (
                <button
                  key={tag}
                  onClick={() => setTagQuery(cleanQueryValue(tag))}
                  className={query.has("tag", cleanQueryValue(tag)) ? "active" : ""}
                >
                  {tag}
                </button>
              ))}
            </div>
          </div>
        </div>
      </div>
    </>
  );
}

export default FilterMenu;

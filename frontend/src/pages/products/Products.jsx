import ProductGridCard from "../../components/ProductGridCard";
import { apiDomain } from "../../helpers/apiDomain";
import useFetch from "../../hooks/useFetch";
import useQuery from "../../hooks/useQuery";
import { useNavigate } from "react-router-dom";
import PaginationButtons from "../../components/PaginationButtons";
import FilterMenu from "../../components/Layout/FilterMenu";
import { ChevronDown, SearchX, SlidersHorizontal } from "lucide-react";
import { useState } from "react";
import ThemedDropdown from "../../components/ThemedDropdown";
import cleanQueryValue from "../../helpers/cleanQueryValue";
import PageIconCircle from "../../components/PageIconCircle";

function Products() {
  const [menuExpanded, setMenuExpanded] = useState(false);
  const navigate = useNavigate();
  const query = useQuery();

  const productCount = useFetch(`${apiDomain.https}/api/products/count?${query.toString()}`);
  const displayAmount = 10;
  const pageAmount = Math.ceil(productCount.data / displayAmount);

  const orderByOptions = ["Lowest Price", "Highest Price"];
  const orderByValue =
    orderByOptions.filter((x) => cleanQueryValue(x) === query.get("orderby"))[0] ?? "Order By";

  const products = useFetch(
    `${apiDomain.https}/api/products?${query.toString()}&amount=${displayAmount}`
  );

  const updatePageNumber = (pageNumber) => {
    query.set("page", pageNumber);
    navigate(`?${query.toString()}`);
  };

  const updateOrderByValue = (value) => {
    query.set("orderby", value);
    navigate(`?${query.toString()}`);
  };

  return (
    <div className="products-page">
      <div className="top-row">
        <button className="filter-button" onClick={() => setMenuExpanded(!menuExpanded)}>
          <SlidersHorizontal />
          <span>Filters</span>
          <ChevronDown style={menuExpanded ? { rotate: "-180deg" } : {}} />
        </button>
        <ThemedDropdown
          value={orderByValue}
          options={orderByOptions}
          onChange={(selected) => updateOrderByValue(cleanQueryValue(selected))}
        />
      </div>
      <FilterMenu menuExpanded={menuExpanded} />
      {products.data?.length == 0 && (
        <section className="no-products-container">
          <PageIconCircle icon={<SearchX />} />
          <div>
            <h2>Could not find any products!</h2>
            <p>Please try again with other filtering options.</p>
          </div>
          <button className="button button-black" onClick={() => navigate("")}>
            Clear filters
          </button>
        </section>
      )}
      <section className="product-card-container">
        {products.data?.map((product) => (
          <ProductGridCard key={product.id} product={product} />
        ))}
      </section>
      <PaginationButtons pageAmount={pageAmount} updatePageNumber={updatePageNumber} />
    </div>
  );
}

export default Products;

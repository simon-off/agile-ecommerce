import { useState } from "react";
import ProductGridCard from "../../components/ProductGridCard";
import { apiDomain } from "../../helpers/api-domain";
import useFetch from "../../hooks/useFetch";
import useQuery from "../../hooks/useQuery";
import FilterBurgerMenu from "../../components/Layout/FilterBurgerMenu";
import { useNavigate } from "react-router-dom";

function Products() {
  const navigate = useNavigate();
  const query = useQuery();
  const orderBy = query.get("orderby") ?? "";
  const products = useFetch(`${apiDomain.https}/api/products?${query.toString()}`);
  const filterMenuOpenState = useState(false);

  const handleChange = (event) => {
    query.set("orderby", event.target.value.toLowerCase());
    navigate(`?${query.toString()}`);
  };

  return (
    <div className="products-page">
      <div className="filter-container">
        <FilterBurgerMenu filterMenuOpenState={filterMenuOpenState} />
        <select value={orderBy} onChange={handleChange}>
          <option value="" disabled hidden>
            Order By
          </option>
          <option value="lowestprice">Lowest Price</option>
          <option value="highestprice">Highest Price</option>
        </select>
      </div>
      {products.data?.length == 0 && (
        <div className="no-products-container">
          <h1>We Could Not Find Any Products Based on Your Filtering</h1>
          <p>Please try again with other filtering options.</p>
        </div>
      )}
      <div className="product-card-container">
        {products.data?.map((product) => (
          <ProductGridCard key={product.id} product={product} />
        ))}
      </div>
    </div>
  );
}

export default Products;

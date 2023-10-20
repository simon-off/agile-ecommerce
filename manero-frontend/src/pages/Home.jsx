import { Link } from "react-router-dom";
//import Product from "../components/Product";
import { apiDomain } from "../helpers/api-domain";
import useFetch from "../hooks/useFetch";
import DiscountCard from "../components/DiscountCard";
import ProductGridCard from "../components/ProductGridCard";
import ProductListCard from "../components/ProductListCard";

export default function Home() {
  const products = useFetch(`${apiDomain.https}/api/products`);
  const tags = useFetch(`${apiDomain.https}/api/tags`);

  const productsToDisplayGrid = products.data?.slice(0, 4);
  // const productsToDisplayList = products.data?.slice(0, 7);

  return (
    <>
      <ul className="tags-container">
        {tags?.data?.map((tag) => (
          <li key={tag.name}>
            <Link to={`/products?tagName=${tag.name.toLowerCase()}`}>
              <div className="tag-wrapper">
                <div className="tag-circle"></div>
                <p>{tag.name}</p>
              </div>
            </Link>
          </li>
        ))}
      </ul>
      <DiscountCard />

      <section className="featured-products">
        <div className="featured-header">
          <h2>Featured products</h2>
          <Link to={"/products?tagName=featured"}>view all</Link>
        </div>
        <div className="product-grid">
          {productsToDisplayGrid?.map((product) => (
            <ProductGridCard key={product.id} product={product} />
          ))}
        </div>
      </section>

      <section className="best-sellers">
        <div className="best-seller-header">
          <h2>Best sellers </h2>
          <Link to={"/products?tagName=bestseller"}>view all</Link>
        </div>
        <div className="product-list">
          {products?.data?.map((product) => (
            <ProductListCard key={product.id} product={product} />
          ))}
        </div>
      </section>

      {/* {products.isLoading && <h2>Loading</h2>}
      {products.error && <h2>Error</h2>}
       */}
    </>
  );
}

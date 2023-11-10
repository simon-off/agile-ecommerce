import { Link } from "react-router-dom";
import { apiDomain } from "../helpers/apiDomain";
import useFetch from "../hooks/useFetch";
import DiscountCard from "../components/DiscountCard";
import ProductGridCard from "../components/ProductGridCard";
import ProductListCard from "../components/ProductListCard";

export default function Home() {
  const productsFeatured = useFetch(`${apiDomain.https}/api/products?tag=featured&amount=4`);
  const productsBestSeller = useFetch(`${apiDomain.https}/api/products?tag=popular&amount=9`);
  const tags = useFetch(`${apiDomain.https}/api/tags`);

  return (
    <>
      <ul className="tags-container">
        {tags?.data?.map((tag) => (
          <li key={tag.name}>
            <Link to={`/products?tag=${tag.name.toLowerCase()}`}>
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
          <Link to={"/products?tag=featured"}>view all</Link>
        </div>
        <div className="product-grid">
          {productsFeatured.data?.map((product) => (
            <ProductGridCard key={product.id} product={product} />
          ))}
        </div>
      </section>

      <section className="best-sellers">
        <div className="best-seller-header">
          <h2>Best sellers </h2>
          <Link to={"/products?tag=popular"}>view all</Link>
        </div>
        <div className="product-list">
          {productsBestSeller.data?.map((product) => (
            <ProductListCard key={product.id} product={product} />
          ))}
        </div>
      </section>
    </>
  );
}

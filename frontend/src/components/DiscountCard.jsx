import { Link } from "react-router-dom";

function DiscountCard() {
  return (
    <div className="discount-card">
      <div className="content">
        <h2>Take 50% off!</h2>
        <Link to="/products">
          <button className="button button-white">shop now</button>
        </Link>
      </div>
    </div>
  );
}

export default DiscountCard;

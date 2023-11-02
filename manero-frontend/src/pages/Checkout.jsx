import { Link, useNavigate } from "react-router-dom";

import { useCart } from "../hooks/useCart";
import { ChevronRight } from "lucide-react";
import CheckoutItem from "../components/CheckoutItem";
import { useOrder } from "../hooks/useOrder";
import { useState } from "react";
import hideCreditCardNumber from "../helpers/hide-credit-card-number";

function Checkout() {
  const { cart } = useCart();
  const { placeOrder, address, customer, paymentCard } = useOrder();
  const navigate = useNavigate();
  const [shippingError, setShippingError] = useState(false);
  const [paymentError, setPaymentError] = useState(false);

  const handlePlaceOrder = () => {
    setShippingError(!address && !customer);
    setPaymentError(!paymentCard);

    if (cart.length <= 0) {
      navigate("/cart");
      return;
    }

    if (address && customer && paymentCard) {
      placeOrder();
      navigate("/checkout/order-confirmation");
    }
  };

  return (
    <div className="checkout-page">
      <section className="container-top">
        <div className="heading">
          <h2>My order</h2>
          <p>
            <span>${cart.reduce((a, b) => a + b.price * b.amount, 0).toFixed(2)}</span>
          </p>
        </div>
        <div className="specification">
          {cart.map((cartItem) => (
            <CheckoutItem key={cartItem.id} cartItem={cartItem} />
          ))}
        </div>
        <Link to="/checkout/shipping" className={shippingError ? "error" : ""}>
          <div className="info">
            <h2>Shipping Details {shippingError && "*"}</h2>
            <p>{address && `${address?.streetAddress}, ${address?.postalCode} ${address?.city}`}</p>
          </div>
          <div className="icon">
            <ChevronRight />
          </div>
        </Link>
        <Link to="/checkout/add-card" className={paymentError ? "error" : ""}>
          <div className="info">
            <h2>Payment Details {paymentError && "*"}</h2>
            <p>{paymentCard && hideCreditCardNumber(paymentCard.cardNumber)}</p>
          </div>
          <div className="icon">
            <ChevronRight />
          </div>
        </Link>
      </section>
      <section className="container-bottom">
        <div className="comment-field">
          <label>Comment</label>
          <input placeholder="Write your comment"></input>
        </div>
        <div className="order-button">
          <button
            to="/handle-order"
            className="button button-black"
            onClick={() => handlePlaceOrder()}
          >
            Place order
          </button>
        </div>
      </section>
    </div>
  );
}

export default Checkout;

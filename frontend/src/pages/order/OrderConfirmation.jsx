import { Check, X } from "lucide-react";
import PageIconCircle from "../../components/PageIconCircle";
import { Link } from "react-router-dom";
import { useOrder } from "../../hooks/useOrder";

export default function OrderConfirmation() {
  const { isOrderSuccessful } = useOrder();

  return (
    <div className="order-confirmation-page">
      {isOrderSuccessful ? (
        <>
          <PageIconCircle icon={<Check />} color="var(--color-success)" />
          <div>
            <h2>Thank you for your order!</h2>
            <p>We will handle it as soon as possible</p>
          </div>
          <Link to="/products" className="button button-black">
            Continue shopping
          </Link>
        </>
      ) : (
        <>
          <PageIconCircle icon={<X />} color="var(--color-danger)" />
          <div>
            <h2>Sorry, your order has failed!</h2>
            <p>Something went wrong. Please try again.</p>
          </div>
          <Link to="/checkout" className="button button-black">
            Back to checkout
          </Link>
        </>
      )}
    </div>
  );
}

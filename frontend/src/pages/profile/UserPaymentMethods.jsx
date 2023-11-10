import { Link, useNavigate } from "react-router-dom";
import PaymentCard from "../../components/PaymentCard";
import useFetch from "../../hooks/useFetch";
import { apiDomain } from "../../helpers/apiDomain";
import getCookieByName from "../../helpers/getCookieByName";
import { useEffect } from "react";
import { Plus, Check, PencilLine } from "lucide-react";

function UserPaymentMethods() {
  const userCards = useFetch(`${apiDomain.https}/api/BankCards`);
  const navigate = useNavigate();
  const authToken = getCookieByName("Authorization");

  useEffect(() => {
    // Login failed
    if (!authToken || userCards.error) {
      // Delete cookie to prevent infinite redirects
      document.cookie = `Authorization=; expires="${new Date(
        0
      ).toUTCString()}" path=/; secure; SameSite=Lax`;
      navigate("/signin");
    }
  }, [authToken, navigate, userCards]);

  return (
    <div className="user-payment-page">
      <div className="heading">
        <p>Cards</p>
        <Link to={"/profile/payment/add"}>
          Add new card <Plus />
        </Link>
      </div>
      <div className="card-container">
        {userCards?.data?.map((card) => (
          <Link key={card.id} to={`/profile/payment/card/${card.id}`}>
            <PaymentCard
              cardNumber={card.creditCardNumber.replace(/(.{4})/g, "$1 ")}
              nameOnCard={card.cardholderName}
            />
          </Link>
        ))}

        </div>
        <div className="linklist">
          <Link to={"/profile/payment/apple-pay"}>
            <div className="left-side">
            <p>Appel Pay </p> 
            <Check />
            </div>
            <PencilLine />
          </Link>

          <Link to={"/profile/payment/pay-pal"}>
            <div className="left-side">
            <p>Pay Pal </p> 
            <Check />
            </div>
            <PencilLine />
          </Link>

          <Link to={"/profile/payment/payoneer"}>
            <div className="left-side">
            <p>Payoneer </p> 
            </div>
            <Plus />
          </Link>
      </div>
    </div>
  );
}

export default UserPaymentMethods;

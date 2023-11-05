import { Camera } from "lucide-react";
import PaymentCard from "../../components/PaymentCard";
import ThemedInput from "../../components/ThemedInput";
import { useNavigate } from "react-router-dom";
import { useOrder } from "../../hooks/useOrder";
import { useState } from "react";

function AddPaymentCard() {
  const { setPaymentCard, paymentCard } = useOrder();
  const navigate = useNavigate();

  // State variables to store the name and card number entered by the user.
  const [nameOnCard, setNameOnCard] = useState(paymentCard?.nameOnCard || "");
  const [cardNumber, setCardNumber] = useState(paymentCard?.cardNumber || "");

  const handleSubmit = (e) => {
    e.preventDefault();

    const formData = new FormData(e.target);
    const formDataObj = Object.fromEntries(formData.entries());
    setPaymentCard(formDataObj);

    navigate(-1);
  };

  return (
    <div className="add-payment-card-page">
      <div className="card-container">
        <PaymentCard nameOnCard={nameOnCard} cardNumber={cardNumber} />
      </div>
      <form method="post" onSubmit={handleSubmit}>
        <ThemedInput
          label="Name"
          type="text"
          name="nameOnCard"
          placeholder="John Doe"
          defaultValue={paymentCard?.nameOnCard}
          onChange={(e) => setNameOnCard(e.target.value)}
          required
          minLength={2}
          maxLength={100}
        />
        <ThemedInput
          label="card number"
          type="text"
          name="cardNumber"
          className="form-control"
          placeholder="xxxx xxxx xxxx xxxx"
          defaultValue={paymentCard?.cardNumber}
          onChange={(e) => setCardNumber(e.target.value)}
          required
          minLength={4}
          maxLength={20}
        >
          <Camera />
        </ThemedInput>
        <div className="row">
          <ThemedInput
            label="MM/YY"
            name="expirationDate"
            className="row-control"
            placeholder="--/--"
            defaultValue={paymentCard?.expirationDate}
            required
            minLength={5}
            maxLength={5}
          />
          <ThemedInput
            label="CVV"
            name="cvvNumber"
            className="row-control"
            placeholder="---"
            defaultValue={paymentCard?.cvvNumber}
            required
            minLength={3}
            maxLength={3}
          />
        </div>
        <div className="form-actions">
          <button className="button button-black">Save card</button>
        </div>
      </form>
    </div>
  );
}

export default AddPaymentCard;

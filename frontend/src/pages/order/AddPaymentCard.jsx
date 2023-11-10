import { Camera } from "lucide-react";
import PaymentCard from "../../components/PaymentCard";
import ThemedInput from "../../components/ThemedInput";
import { useNavigate } from "react-router-dom";
import { useOrder } from "../../hooks/useOrder";
import { useState, useEffect } from "react";
import ThemedDropdown from "../../components/ThemedDropdown";
import { apiDomain } from "../../helpers/apiDomain";
import useFetch from "../../hooks/useFetch";

function AddPaymentCard() {
  const { setPaymentCard, paymentCard } = useOrder();
  const navigate = useNavigate();
  const savedCards = useFetch(`${apiDomain.https}/api/bankcards`);

  const [chosenCardNumber, setChosenCardNumber] = useState(null);

  const [nameOnCard, setNameOnCard] = useState(paymentCard?.nameOnCard || "");
  const [cardNumber, setCardNumber] = useState(paymentCard?.cardNumber || "");
  const [expirationDate, setExpirationDate] = useState(paymentCard?.expirationDate || "");
  const [cvvNumber, setCvvNumber] = useState(paymentCard?.cvvNumber || "");

  const chosenCard = savedCards.data?.find((card) => card.creditCardNumber === chosenCardNumber);
  console.log(nameOnCard, cardNumber, expirationDate, cvvNumber);

  useEffect(() => {
    if (chosenCard === undefined) return;

    setNameOnCard(chosenCard?.cardholderName);
    setCardNumber(chosenCard?.creditCardNumber);
    setExpirationDate(chosenCard?.expirationDate);
    setCvvNumber(chosenCard?.cvc);
  }, [chosenCardNumber, chosenCard]);

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
        <PaymentCard nameOnCard={nameOnCard} cardNumber={cardNumber} expDate={expirationDate} />
      </div>
      <form method="post" onSubmit={handleSubmit}>
        {savedCards.data?.length > 0 && (
          <ThemedDropdown
            value={chosenCard ? chosenCard.creditCardNumber : "Use saved card"}
            options={savedCards.data?.map((card) => card.creditCardNumber)}
            onChange={(option) => setChosenCardNumber(option)}
          />
        )}
        <ThemedInput
          label="Name"
          type="text"
          name="nameOnCard"
          placeholder="John Doe"
          value={nameOnCard}
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
          value={cardNumber}
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
            value={expirationDate}
            onChange={(e) => setExpirationDate(e.target.value)}
            required
            minLength={5}
            maxLength={5}
          />
          <ThemedInput
            label="CVV"
            name="cvvNumber"
            className="row-control"
            placeholder="---"
            value={cvvNumber}
            onChange={(e) => setCvvNumber(e.target.value)}
            required
            minLength={3}
            maxLength={3}
          />
        </div>
        <div className="form-actions">
          <button className="button button-black">Use card</button>
        </div>
      </form>
    </div>
  );
}

export default AddPaymentCard;

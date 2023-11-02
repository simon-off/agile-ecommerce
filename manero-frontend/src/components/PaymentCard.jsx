import { CreditCard } from "lucide-react";
import { useState, useEffect } from "react";

function PaymentCard({ nameOnCard, cardNumber }) {
  const [displayedName, setDisplayedName] = useState("");
  const [displayedCardNumber, setDisplayedCardNumber] = useState("");

  //Effect hooks that change the displayed name and card number when the nameOnCard and cardNumber props change.
  useEffect(() => {
    setDisplayedName(nameOnCard || "John Doe");
  }, [nameOnCard]);

  useEffect(() => {
    setDisplayedCardNumber(cardNumber || "xxxx xxxx xxxx xxxx");
  }, [cardNumber]);

  return (
    <div className="payment-card">
      <CreditCard />
      <p className="card-number">{displayedCardNumber}</p>
      <div className="card-details">
        <p>{displayedName}</p>
        <p>EXP. END</p>
      </div>
    </div>
  );
}

export default PaymentCard;

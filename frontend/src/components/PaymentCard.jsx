import { CreditCard } from "lucide-react";

function PaymentCard({ nameOnCard, cardNumber, expDate }) {
  console.log(nameOnCard, cardNumber, expDate);
  return (
    <div className="payment-card">
      <CreditCard />
      <p className="card-number">{cardNumber || "xxxx xxxx xxxx xxxx"}</p>
      <div className="card-details">
        <p>{nameOnCard || "John Doe"}</p>
        <p>{expDate || "EXP.END"}</p>
      </div>
    </div>
  );
}

export default PaymentCard;

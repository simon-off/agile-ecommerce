import { useNavigate, useParams } from "react-router-dom";
import useFetch from "../../hooks/useFetch";
import getCookieByName from "../../helpers/getCookieByName";
import { useState, useEffect } from "react";
import { useToast } from "../../hooks/useToast";
import { apiDomain } from "../../helpers/apiDomain";
import ThemedInput from "../../components/ThemedInput";
import PaymentCard from "../../components/PaymentCard";

function EditCard() {
  const { id } = useParams();
  const bankCard = useFetch(`${apiDomain.https}/api/bankcards/${id}`);
  const authToken = getCookieByName("Authorization");
  const toast = useToast();
  const navigate = useNavigate();
  const [cardholderName, setCardholderName] = useState("");
  const [creditCardNumber, setcreditCardNumber] = useState("");
  const [expirationDate, setExpirationDate] = useState("");
  const [cardIssuer, setcardIssuer] = useState("");
  const [cvc, setCvc] = useState("");

  useEffect(() => {
    // Login failed
    if (!authToken || bankCard.error) {
      // Delete cookie to prevent infinite redirects
      document.cookie = `Authorization=; expires="${new Date(
        0
      ).toUTCString()}" path=/; secure; SameSite=Lax`;
      navigate("/signin");
    }
  }, [authToken, navigate, bankCard]);

  if (
    bankCard.data &&
    !cardholderName &&
    !creditCardNumber &&
    !expirationDate &&
    !cardIssuer &&
    !cvc
  ) {
    setCardholderName(bankCard.data.cardholderName);
    setcreditCardNumber(bankCard.data.creditCardNumber);
    setExpirationDate(bankCard.data.expirationDate);
    setcardIssuer(bankCard.data.cardIssuer);
    setCvc(bankCard.data.cvc);
  }

  const handleSubmit = async (e) => {
    e.preventDefault();

    const createData = {
      id: bankCard.data.id,
      creditCardNumber: creditCardNumber.replace(/\s/g, ""),
      cvc: cvc,
      cardholderName: cardholderName,
      cardIssuer: cardIssuer,
      expirationDate: expirationDate,
    };

    try {
      const response = await fetch(`${apiDomain.https}/api/bankcards`, {
        method: "PUT",
        mode: "cors",
        headers: {
          "Content-Type": "application/json",
          Authorization: `Bearer ${authToken}`,
        },
        body: JSON.stringify(createData),
      });

      if (!response.ok) {
        throw new Error("Could not save card, please try again.");
      }

      toast.add("Card saved!");
      navigate("/profile/payment");
    } catch (error) {
      toast.add(error.message, "var(--color-danger)");
      console.log(error);
    }
  };

  const handleDelete = async (e) => {
    e.preventDefault();
    try {
      const response = await fetch(`${apiDomain.https}/api/bankcards/${bankCard.data.id}`, {
        method: "DELETE",
        mode: "cors",
        headers: {
          "Content-Type": "application/json",
          Authorization: `Bearer ${authToken}`,
        },
      });

      if (!response.ok) {
        throw new Error("Could not delete card, please try again.");
      }

      toast.add("Address deleted");
      navigate("/profile/payment");
    } catch (error) {
      toast.add(error.message, "var(--color-danger)");
      console.log(error);
    }
  };

  return (
    <div className="add-payment-card-page">
      <div className="card-container">
        <PaymentCard nameOnCard={cardholderName} cardNumber={creditCardNumber} />
      </div>
      {bankCard.data && (
        <form onSubmit={handleSubmit}>
          <ThemedInput
            label="Name"
            type="text"
            name="nameOnCard"
            value={cardholderName}
            onChange={(e) => setCardholderName(e.target.value)}
            required
            minLength={2}
            maxLength={100}
          />
          <ThemedInput
            label="card number"
            type="text"
            name="cardNumber"
            regex={"^(\\d{4}\\s?){3}\\d{4}$"}
            className="form-control"
            value={creditCardNumber}
            onChange={(e) => setcreditCardNumber(e.target.value)}
            onBlur={(e) => {
              const creditCardRegex = /^(\d{4}\s?){3}\d{4}$/;
              const hasWhitespace = /\s/;
              // Don't add the formatting if string is invalid or already is formatted
              if (creditCardRegex.test(creditCardNumber) && !hasWhitespace.test(creditCardNumber)) {
                setcreditCardNumber(e.target.value.replace(/(.{4})/g, "$1 "));
              }
            }}
            required
            minLength={4}
            maxLength={20}
          ></ThemedInput>
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
              value={cvc}
              onChange={(e) => setCvc(e.target.value)}
              required
              minLength={3}
              maxLength={3}
            />
          </div>
          <ThemedInput
            label="Card Issuer"
            name="cardIssuer"
            className="row-control"
            value={cardIssuer}
            onChange={(e) => setcardIssuer(e.target.value)}
            required
            minLength={2}
            maxLength={100}
          />
          <div className="form-actions">
            <button className="button button-black">Save card</button>
            <button className="button button-delete" type="button" onClick={handleDelete}>
            Delete
          </button>
          </div>
        </form>
      )}
    </div>
  );
}

export default EditCard;

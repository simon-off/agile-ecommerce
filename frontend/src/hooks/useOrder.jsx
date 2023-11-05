import { createContext, useContext, useState } from "react";
import { useCart } from "./useCart";
import Customer from "../models/Customer";
import Address from "../models/Address";
import PaymentCard from "../models/PaymentCard";
import { apiDomain } from "../helpers/api-domain";

const OrderContext = createContext(null);

export function OrderContextProvider({ children }) {
  const [customer, _setCustomer] = useState(null);
  const [address, _setAddress] = useState(null);
  const [paymentCard, _setPaymentCard] = useState();
  const [isOrderSuccessful, _setIsOrderSuccessful] = useState(false);
  const { cart } = useCart();

  const setCustomer = (firstName, lastName, email, phone) => {
    _setCustomer(new Customer(firstName, lastName, email, phone));
  };

  const setAddress = (streetAddress, city, postalCode) => {
    _setAddress(new Address(streetAddress, city, postalCode));
  };

  const setShipping = (formData) => {
    _setCustomer(
      new Customer(formData.firstName, formData.lastName, formData.email, formData.phone)
    );
    _setAddress(new Address(formData.streetAddress, formData.city, formData.postalCode));
  };

  const setPaymentCard = (formData) => {
    _setPaymentCard(
      new PaymentCard(
        formData.cardNumber,
        formData.expirationDate,
        formData.cvvNumber,
        formData.nameOnCard
      )
    );
  };

  const placeOrder = async () => {
    // Cancel if details are missing or invalid
    if (!customer || !address || !paymentCard) {
      console.log("Invalid order details");
      return;
    }

    const orderData = {
      customer: customer,
      address: address,
      products: cart.map((item) => ({
        productId: item.id,
        size: item.size,
        amount: item.amount,
      })),
    };

    // Send data to the backend via POST
    const response = await fetch(`${apiDomain.https}/api/orders`, {
      method: "POST",
      mode: "cors",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(orderData),
    });
    console.log(response);
    const data = await response.json();
    console.log("response from server:", data);

    _setIsOrderSuccessful(response.ok);
  };

  return (
    <OrderContext.Provider
      value={{
        placeOrder,
        isOrderSuccessful,
        setShipping,
        customer,
        setCustomer,
        address,
        setAddress,
        paymentCard,
        setPaymentCard,
      }}
    >
      {children}
    </OrderContext.Provider>
  );
}

export const useOrder = () => useContext(OrderContext);

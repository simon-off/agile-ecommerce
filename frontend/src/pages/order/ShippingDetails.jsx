import { useNavigate } from "react-router-dom";
import { useOrder } from "../../hooks/useOrder";
import ThemedInput from "../../components/ThemedInput";
import ThemedDropdown from "../../components/ThemedDropdown";
import useFetch from "../../hooks/useFetch";
import { apiDomain } from "../../helpers/apiDomain";
import { useEffect, useState } from "react";

export default function ShippingDetails() {
  const { setShipping, customer, address } = useOrder();
  const account = useFetch(`${apiDomain.https}/api/account`);
  const savedAddresses = useFetch(`${apiDomain.https}/api/addresses`);
  const navigate = useNavigate();

  const [chosenStreetName, setChosenStreetName] = useState(null);
  const [streetAddress, setStreetAddress] = useState(address?.streetAddress ?? "");
  const [postalCode, setPostalCode] = useState(address?.postalCode ?? "");
  const [city, setCity] = useState(address?.city ?? "");

  const chosenAddress = savedAddresses.data?.find(
    (address) => address.streetName === chosenStreetName
  );

  useEffect(() => {
    if (chosenAddress === undefined) return;
    setStreetAddress(chosenAddress?.streetName);
    setPostalCode(chosenAddress?.postalCode);
    setCity(chosenAddress?.city);
  }, [chosenStreetName, chosenAddress]);

  const handleSubmit = (e) => {
    e.preventDefault();

    const formData = new FormData(e.target);
    const formDataObj = Object.fromEntries(formData.entries());
    setShipping(formDataObj);

    navigate(-1);
  };

  return (
    <div className="shipping-details-page">
      <p>Please enter you shipping details</p>
      <form method="post" onSubmit={handleSubmit}>
        <h3>Customer</h3>
        <ThemedInput
          label="First Name"
          name="firstName"
          defaultValue={customer?.firstName || account.data?.firstName}
          required
          minLength={2}
          maxLength={100}
        />
        <ThemedInput
          label="Last Name"
          name="lastName"
          defaultValue={customer?.lastName || account.data?.lastName}
          required
          minLength={2}
          maxLength={100}
        />
        <ThemedInput
          label="Email Address"
          type="email"
          name="email"
          defaultValue={customer?.email || account.data?.email}
          required
          minLength={6}
          maxLength={320}
        />
        <ThemedInput
          label="Phone Number"
          type="tel"
          name="phone"
          defaultValue={customer?.phoneNumber || account.data?.phoneNumber}
          required
          minLength={10}
          maxLength={20}
        />
        <h3>Address</h3>
        {savedAddresses.data?.length > 0 && (
          <ThemedDropdown
            value={
              chosenAddress
                ? `${chosenAddress.streetName}, ${chosenAddress?.city}`
                : "Use saved address"
            }
            options={savedAddresses.data?.map(
              (address) => `${address.streetName}, ${address.city}`
            )}
            onChange={(option) => {
              setChosenStreetName(option.split(",")[0].trim());
            }}
          />
        )}
        <ThemedInput
          label="Street Address"
          type="text"
          name="streetAddress"
          value={streetAddress}
          onChange={(e) => setStreetAddress(e.target.value)}
          required
          minLength={1}
          maxLength={255}
        />
        <ThemedInput
          label="Postal Code"
          type="text"
          name="postalCode"
          value={postalCode}
          onChange={(e) => setPostalCode(e.target.value)}
          required
          minLength={1}
          maxLength={255}
        />
        <ThemedInput
          label="City"
          type="text"
          name="city"
          value={city}
          onChange={(e) => setCity(e.target.value)}
          required
          minLength={4}
          maxLength={20}
        />
        <button className="button button-black">Save</button>
      </form>
    </div>
  );
}

import { useNavigate } from "react-router-dom";
import { useOrder } from "../../hooks/useOrder";
import ThemedInput from "../../components/ThemedInput";

export default function ShippingDetails() {
  const { setShipping, customer, address } = useOrder();

  const navigate = useNavigate();

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
          defaultValue={customer?.firstName}
          required
          minLength={2}
          maxLength={100}
        />
        <ThemedInput
          label="Last Name"
          name="lastName"
          defaultValue={customer?.lastName}
          required
          minLength={2}
          maxLength={100}
        />
        <ThemedInput
          label="Email Address"
          type="email"
          name="email"
          defaultValue={customer?.email}
          required
          minLength={6}
          maxLength={320}
        />
        <ThemedInput
          label="Phone Number"
          type="tel"
          name="phone"
          defaultValue={customer?.phoneNumber}
          required
          minLength={10}
          maxLength={20}
        />
        <h3>Address</h3>
        <ThemedInput
          label="Street Address"
          type="text"
          name="streetAddress"
          defaultValue={address?.streetAddress}
          required
          minLength={1}
          maxLength={255}
        />
        <ThemedInput
          label="Postal Code"
          type="text"
          name="postalCode"
          defaultValue={address?.postalCode}
          required
          minLength={1}
          maxLength={255}
        />
        <ThemedInput
          label="City"
          type="text"
          name="city"
          defaultValue={address?.city}
          required
          minLength={4}
          maxLength={20}
        />
        <button className="button button-black">Save</button>
      </form>
    </div>
  );
}

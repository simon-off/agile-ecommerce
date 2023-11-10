import { useEffect, useState } from "react";
import ThemedInput from "../../components/ThemedInput";
import { useToast } from "../../hooks/useToast";
import { apiDomain } from "../../helpers/apiDomain";
import { useNavigate } from "react-router-dom";
import getCookieByName from "../../helpers/getCookieByName";

function AddAddress() {
  const [streetAddress, setStreetAddress] = useState("");
  const [city, setCity] = useState("");
  const [postalCode, setPostalCode] = useState("");
  const authToken = getCookieByName("Authorization");
  const toast = useToast();
  const navigate = useNavigate();

  useEffect(() => {
    // Login failed
    if (!authToken) {
      // Delete cookie to prevent infinite redirects
      document.cookie = `Authorization=; expires="${new Date(
        0
      ).toUTCString()}" path=/; secure; SameSite=Lax`;
      navigate("/signin");
    }
  }, [authToken, navigate]);

  const handleSubmit = async (e) => {
    e.preventDefault();

    const createData = {
      streetAddress: streetAddress,
      city: city,
      postalCode: postalCode,
    };

    try {
      const response = await fetch(`${apiDomain.https}/api/addresses`, {
        method: "POST",
        mode: "cors",
        headers: {
          "Content-Type": "application/json",
          Authorization: `Bearer ${authToken}`,
        },
        body: JSON.stringify(createData),
      });

      if (!response.ok) {
        throw new Error("Could not create address, please try again.");
      }

      toast.add("Address saved");
      navigate("/profile/address");
    } catch (error) {
      toast.add(error.message, "var(--color-danger)");
      console.log(error);
    }
  };

  return (
    <div className="add-address-page">
      <div className="heading">
        <h1>Add Address</h1>
      </div>
      <form onSubmit={handleSubmit}>
        <ThemedInput
          label="Street Address"
          required
          error={"Must contain only letters"}
          value={streetAddress}
          type="text"
          onChange={(e) => setStreetAddress(e.target.value)}
          maxLength={255}
          minLength={1}
        ></ThemedInput>{" "}
        <ThemedInput
          label="City"
          required
          error={"Must contain only letters"}
          value={city}
          type="text"
          onChange={(e) => setCity(e.target.value)}
          maxLength={255}
          minLength={1}
        ></ThemedInput>{" "}
        <ThemedInput
          label="Postal Code"
          required
          value={postalCode}
          type="text"
          onChange={(e) => setPostalCode(e.target.value)}
          maxLength={200}
          minLength={4}
        ></ThemedInput>
        <button className="button button-black" type="submit">
          Save Address
        </button>
      </form>
    </div>
  );
}

export default AddAddress;

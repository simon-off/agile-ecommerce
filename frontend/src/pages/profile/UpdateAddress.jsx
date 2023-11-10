import { useNavigate, useParams } from "react-router-dom";
import { apiDomain } from "../../helpers/apiDomain";
import useFetch from "../../hooks/useFetch";
import { useEffect, useState } from "react";
import getCookieByName from "../../helpers/getCookieByName";
import ThemedInput from "../../components/ThemedInput";
import { useToast } from "../../hooks/useToast";

function UpdateAddress() {
  const { id } = useParams();
  const address = useFetch(`${apiDomain.https}/api/addresses/${id}`);
  const authToken = getCookieByName("Authorization");
  const navigate = useNavigate();
  const [streetAddress, setStreetAddress] = useState("");
  const [city, setCity] = useState("");
  const [postalCode, setPostalCode] = useState("");
  const toast = useToast();

  useEffect(() => {
    // Login failed
    if (!authToken || address.error) {
      // Delete cookie to prevent infinite redirects
      document.cookie = `Authorization=; expires="${new Date(
        0
      ).toUTCString()}" path=/; secure; SameSite=Lax`;
      navigate("/signin");
    }
  }, [authToken, navigate, address]);

  if (address.data && !streetAddress && !city && !postalCode) {
    setStreetAddress(address.data.city);
    setCity(address.data.city);
    setPostalCode(address.data.postalCode);
  }

  const handleSubmit = async (e) => {
    e.preventDefault();

    const createData = {
      id: id,
      streetAddress: streetAddress,
      city: city,
      postalCode: postalCode,
    };

    try {
      const response = await fetch(`${apiDomain.https}/api/addresses`, {
        method: "PUT",
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

  const handleDelete = async (e) => {
    e.preventDefault();
    try {
      const response = await fetch(`${apiDomain.https}/api/addresses?addressId=${id}`, {
        method: "DELETE",
        mode: "cors",
        headers: {
          "Content-Type": "application/json",
          Authorization: `Bearer ${authToken}`,
        },
      });

      if (!response.ok) {
        throw new Error("Could not delete address, please try again.");
      }

      toast.add("Address deleted");
      navigate("/profile/address");
    } catch (error) {
      toast.add(error.message, "var(--color-danger)");
      console.log(error);
    }
  };

  return (
    <div className="update-address-page">
      {address.data && (
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
          ></ThemedInput>
          <ThemedInput
            label="City"
            required
            error={"Must contain only letters"}
            value={city}
            type="text"
            onChange={(e) => setCity(e.target.value)}
            maxLength={255}
            minLength={1}
          ></ThemedInput>
          <ThemedInput
            label="Postal Code"
            required
            error={"Must contain only letters"}
            value={postalCode}
            type="text"
            onChange={(e) => setPostalCode(e.target.value)}
            maxLength={20}
            minLength={4}
          ></ThemedInput>
          <button className="button button-black" type="submit">
            Save Changes
          </button>
          <button className="button button-delete" type="button" onClick={handleDelete}>
            Delete
          </button>
        </form>
      )}
    </div>
  );
}

export default UpdateAddress;

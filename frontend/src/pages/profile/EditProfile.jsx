import { useNavigate, Link } from "react-router-dom";
import useFetch from "../../hooks/useFetch";
import getCookieByName from "../../helpers/getCookieByName";
import { apiDomain } from "../../helpers/apiDomain";
import { useEffect, useState } from "react";
import ThemedInput from "../../components/ThemedInput";
import { User } from "lucide-react";
import PageIconCircle from "../../components/PageIconCircle";
import { useToast } from "../../hooks/useToast";

function EditProfile() {
  const navigate = useNavigate();
  const account = useFetch(`${apiDomain.https}/api/account`);
  const authToken = getCookieByName("Authorization");
  const [firstName, setFirstName] = useState("");
  const [lastName, setLastName] = useState("");
  const [email, setEmail] = useState("");
  const [phoneNumber, setPhoneNumber] = useState("");
  const toast = useToast();

  useEffect(() => {
    // Login failed
    if (!authToken || account.error || (!account.isLoading && !account.data)) {
      // Delete cookie to prevent infinite redirects
      document.cookie = `Authorization=; expires="${new Date(
        0
      ).toUTCString()}" path=/; secure; SameSite=Lax`;
      navigate("/signin");
    }
  }, [authToken, account, navigate]);

  // Check state values to prevent infinte render loop
  if (account.data && !firstName && !lastName && !email && !phoneNumber) {
    setFirstName(account.data.firstName);
    setLastName(account.data.lastName);
    setEmail(account.data.email);
    setPhoneNumber(account.data.phoneNumber);
  }

  const handleSubmit = async (e) => {
    e.preventDefault();

    const updateData = {
      firstName: firstName,
      lastName: lastName,
      email: email,
      phoneNumber: phoneNumber,
    };

    try {
      const response = await fetch(`${apiDomain.https}/api/account/update`, {
        method: "PUT",
        mode: "cors",
        headers: {
          "Content-Type": "application/json",
          Authorization: `Bearer ${authToken}`,
        },
        body: JSON.stringify(updateData),
      });

      if (!response.ok) {
        throw new Error("Something went wrong, please try again.");
      }

      toast.add("Changes successfully saved.");
      navigate("/profile");
    } catch (error) {
      toast.add(error.message, "var(--color-danger)");
      console.log(error);
    }
  };

  return (
    <div className="edit-profile-page">
      <div className="heading">
        <Link to="/profile/edit" className="icon-container">
          <PageIconCircle icon={<User />} />
        </Link>
      </div>
      {account.data && (
        <form onSubmit={handleSubmit}>
          <ThemedInput
            label="First Name"
            regex={"^[a-zA-ZåäöÅÄÖ]+$"}
            required
            error={"Must contain only letters"}
            value={firstName}
            type="text"
            onChange={(e) => setFirstName(e.target.value)}
            maxLength={100}
            minLength={2}
          ></ThemedInput>
          <ThemedInput
            label="Last Name"
            type="text"
            regex={"^[a-zA-ZåäöÅÄÖ]+$"}
            required
            error={"Must contain only letters"}
            value={lastName}
            onChange={(e) => setLastName(e.target.value)}
            maxLength={100}
            minLength={2}
          ></ThemedInput>
          <ThemedInput
            label="Email"
            type="email"
            regex={"^[\\w-\\.]+@([\\w-]+.)+[\\w-]{2,4}$"}
            required
            error={"Must be a valid email address"}
            value={email}
            onChange={(e) => setEmail(e.target.value)}
            maxLength={320}
            minLength={1}
          ></ThemedInput>
          <ThemedInput
            label="phone number"
            type="text"
            regex={"^(\\+\\d{1,4}\\s?)?(\\(?\\d{1,}\\)?[-.\\s]?)+\\d{1,}$"}
            required
            error={"Must be a valid phone number"}
            value={phoneNumber}
            onChange={(e) => setPhoneNumber(e.target.value)}
            maxLength={20}
            minLength={10}
          ></ThemedInput>
          <div className="button-container">
            <Link to={"/profile/edit/changepassword"} className="button change-password-button">
              Change Password
            </Link>
            <button className="button button-black" type="submit">
              Save Changes
            </button>
          </div>
        </form>
      )}
    </div>
  );
}

export default EditProfile;

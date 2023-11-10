import { Check, EyeOff, Eye, Facebook, Twitter } from "lucide-react";
import { Link, useNavigate } from "react-router-dom";
import ThemedInput from "../../components/ThemedInput";
import { useState, useEffect } from "react";
import { apiDomain } from "../../helpers/apiDomain";
import getCookieByName from "../../helpers/getCookieByName";
import { useToast } from "../../hooks/useToast";

function SignUp() {
  const [firstName, setFirstName] = useState("");
  const [lastName, setLastName] = useState("");
  const [email, setEmail] = useState("");
  const [phoneNumber, setPhoneNumber] = useState("");
  const [password, setPassword] = useState("");
  const [confirmPassword, setConfirmPassword] = useState("");
  const [passwordIsHidden, setPasswordIsHidden] = useState(true);
  const [confirmPasswordIsHidden, setConfirmPasswordIsHidden] = useState(true);
  const navigate = useNavigate();
  const authToken = getCookieByName("Authorization");
  const toast = useToast();

  useEffect(() => {
    if (authToken) {
      // If you already are logged in you should not be able to access this page
      navigate("/profile");
    }
  }, [authToken, navigate]);

  const handleSubmit = async (e) => {
    e.preventDefault();

    const signUpData = {
      firstName: firstName,
      lastName: lastName,
      email: email,
      phoneNumber: phoneNumber,
      password: password,
      confirmPassword: confirmPassword,
    };
    try {
      const response = await fetch(`${apiDomain.https}/api/account/signup`, {
        method: "POST",
        mode: "cors",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(signUpData),
      });

      if (!response.ok) {
        if (response.status === 400) {
          throw new Error(`Error: ${response.status}. Invalid input, please try again.`);
        }

        const errorMessage = await response.text();
        throw new Error(`Error: ${response.status}. ${errorMessage}`);
      }

      const data = await response.json();
      toast.add(`Created account: ${data.email}!`);
      navigate("/signin");
    } catch (error) {
      toast.add(error.message, "var(--color-danger)");
      console.log(error);
    }
  };

  return (
    <>
      <div className="signup-container">
        <h1>Sign Up</h1>
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
          >
            <Check />
          </ThemedInput>
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
          >
            <Check />
          </ThemedInput>
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
          >
            <Check />
          </ThemedInput>
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
          >
            <Check />
          </ThemedInput>
          <ThemedInput
            label="Password"
            type={passwordIsHidden ? "password" : "text"}
            regex={
              "^(?=.*[a-zåäö])(?=.*[A-ZÅÄÖ])(?=.*\\d)(?=.*[@$!%*?&])[A-ZÅÄÖa-zåäö\\d@$!%*?&]{8,}$"
            }
            required
            error={
              "Must contain at least 8 characters, one lowercase, one uppercase and one special character"
            }
            value={password}
            onChange={(e) => setPassword(e.target.value)}
            maxLength={100}
            minLength={8}
          >
            <button type="button" onClick={() => setPasswordIsHidden(!passwordIsHidden)}>
              {passwordIsHidden ? <EyeOff /> : <Eye />}
            </button>
          </ThemedInput>
          <ThemedInput
            label="Confirm Password"
            type={confirmPasswordIsHidden ? "password" : "text"}
            regex={
              "^(?=.*[a-zåäö])(?=.*[A-ZÅÄÖ])(?=.*\\d)(?=.*[@$!%*?&])[A-ZÅÄÖa-zåäö\\d@$!%*?&]{8,}$"
            }
            required
            error={confirmPassword !== password ? "Must match the previous password" : null}
            value={confirmPassword}
            onChange={(e) => setConfirmPassword(e.target.value)}
            maxLength={100}
            minLength={8}
          >
            <button type="button" onClick={() => setConfirmPasswordIsHidden(!confirmPasswordIsHidden)}>
              {confirmPasswordIsHidden ? <EyeOff /> : <Eye />}
            </button>
          </ThemedInput>

          <button type="submit" className="button button-black">
            SIGN UP
          </button>
          <Link className="sign-in-button" to="/signin">
            Already have an account? Sign in.
          </Link>
        </form>

        <div className="signup-options">
          <Link to={"/facebook-auth"}>
            <div className="icon facebook">
              <Facebook />
            </div>
          </Link>
          <Link to={"/twitter-auth"}>
            <div className="icon twitter">
              {" "}
              <Twitter />
            </div>
          </Link>
          <Link to={"google-auth"}>
            <div className="image-icon">
              <img src="\images\google plus.png" alt="google-icon" />
            </div>
          </Link>
        </div>
      </div>
    </>
  );
}

export default SignUp;

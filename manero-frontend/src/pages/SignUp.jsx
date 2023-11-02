import { Check, EyeOff, Facebook, Twitter } from "lucide-react";
import { Link } from "react-router-dom";
import ThemedInput from "../components/ThemedInput";

function SignUp() {
  return (
    <>
      <div className="signup-container">
        <h1>Sign Up</h1>
        <form>
          <ThemedInput label="Name" type="text">
            <Check />
          </ThemedInput>
          <ThemedInput label="Email" type="text">
            <Check />
          </ThemedInput>
          <ThemedInput label="Password" type="password">
            <button type="button">
              <EyeOff className="container-icon" />
            </button>
          </ThemedInput>
          <ThemedInput label="Confirm Password" type="text">
            <button type="button">
              <EyeOff className="container-icon" />
            </button>
          </ThemedInput>
          <Link to={"/account-confirmation"}>
            <button type="submit" className="button button-black">
              SIGN UP
            </button>
          </Link>
          <p>
            Already have an account? <Link to="/signin">Sign in.</Link>
          </p>
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

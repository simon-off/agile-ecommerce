import { Check, EyeOff, Facebook, Twitter } from "lucide-react";
import { Link } from "react-router-dom";
import ThemedInput from "../../components/ThemedInput";

export default function SignIn() {
  return (
    <>
      <div className="signin-container">
        <h1>Welcome Back!</h1>
        <h3>Sign in to continue</h3>
        <form>
          <div className="signin-detail">
            <ThemedInput label="Email" type="email">
              <Check />
            </ThemedInput>
            <ThemedInput label="Password" type="password">
              <button type="button">
                <EyeOff />
              </button>
            </ThemedInput>
          </div>
          <div className="config-content">
            <div>
              <label>
                <input type="checkbox" name="rememberme" value="check" /> Remember me
              </label>
            </div>
            <Link to="/forgot-password">Forgot password?</Link>
          </div>
          <button type="submit" className="button button-black">
            SIGN IN
          </button>
          <p>
            Don’t have an account? <Link to="/signup">Sign up.</Link>
          </p>
        </form>

        <div className="signin-options">
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

import { Link } from "react-router-dom";
import ThemedInput from "../../components/ThemedInput";

function ForgotPassword() {
  return (
    <div className="forgot-password-page">
      <div className="ingress">
        Please enter your email address. You will receive a link to create a new password via email.
      </div>
      <form>
        <ThemedInput label="Email" type="email" placeholder="Enter your email" />
        <Link to={"/reset-password"}>
          <button type="submit" className="button button-black">
            SEND
          </button>
        </Link>
      </form>
    </div>
  );
}

export default ForgotPassword;

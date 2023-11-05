import { EyeOff } from "lucide-react";
import { Link } from "react-router-dom";
import ThemedInput from "../../components/ThemedInput";

function ResetPassword() {
  return (
    <div className="reset-password-page">
      <div className="ingress">Enter new password and confirm.</div>
      <form>
        <ThemedInput label="New Password" type="password" placeholder="Enter your new password">
          <button type="button">
            <EyeOff className="container-icon" />
          </button>
        </ThemedInput>
        <ThemedInput
          label="Confirm Password"
          type="password"
          placeholder="Confirm your new password"
        >
          <button type="button">
            <EyeOff className="container-icon" />
          </button>
        </ThemedInput>
        <Link to={"/password-confirmation"}>
          <button type="submit" className="button button-black">
            CHANGE PASSWORD
          </button>
        </Link>
      </form>
    </div>
  );
}

export default ResetPassword;

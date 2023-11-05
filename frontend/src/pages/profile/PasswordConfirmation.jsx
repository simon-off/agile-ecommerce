import { KeyRound } from "lucide-react";
import PageIconCircle from "../../components/PageIconCircle";
import { Link } from "react-router-dom";

function PasswordConfirmation() {
  return (
    <div className="order-confirmation-page">
      <>
        <PageIconCircle icon={<KeyRound />} />
        <div>
          <h2>Your password has been reset!</h2>
          <p>Lorem ipsum dolor sit amet consectetur elit! Lorem ipsum dolor sit amet.</p>
        </div>
        <Link to="/products" className="button button-black">
          Done
        </Link>
      </>
    </div>
  );
}

export default PasswordConfirmation;

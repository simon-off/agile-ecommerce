import { UserCircle } from "lucide-react";
import PageIconCircle from "../components/PageIconCircle";
import { Link } from "react-router-dom";

function AccountCreated() {
  return (
    <div className="order-confirmation-page">
      <>
        <PageIconCircle icon={<UserCircle />} />
        <div>
          <h2>Account Created!</h2>
          <p>Your account had been created successfully.</p>
        </div>
        <Link to="/products" className="button button-black">
          Shop now
        </Link>
      </>
    </div>
  );
}

export default AccountCreated;

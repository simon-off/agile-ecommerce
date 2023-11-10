import useFetch from "../../hooks/useFetch";
import getCookieByName from "../../helpers/getCookieByName";
import { useNavigate } from "react-router-dom";
import { useEffect } from "react";
import { apiDomain } from "../../helpers/apiDomain";
import PageIconCircle from "../../components/PageIconCircle";
import {
  User,
  PencilLine,
  MapPin,
  CreditCard,
  DoorOpen,
  Calendar,
  ChevronRight,
} from "lucide-react";
import { Link } from "react-router-dom";

function Profile() {
  const navigate = useNavigate();
  const account = useFetch(`${apiDomain.https}/api/account`);
  const authToken = getCookieByName("Authorization");

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

  if (account.isLoading) {
    return;
  }

  return (
    <div className="profile-page">
      {account.data && (
        <div className="heading">
          <Link to="/profile/edit" className="icon-container">
            <PageIconCircle icon={<User />} />
            <div className="edit-icon">
              <PencilLine />
            </div>
          </Link>
          <div className="heading-text">
            <h1>
              {account.data.firstName} {account.data.lastName}
            </h1>
            <p>{account.data.email}</p>
          </div>
        </div>
      )}
      <div className="link-list">
        <Link to={"/profile/orders"}>
          <div className="list-item">
            <div className="items-start">
              <Calendar />
              <p>Order History</p>
            </div>
            <ChevronRight />
          </div>
        </Link>
        <Link to={"/profile/payment"}>
          <div className="list-item">
            <div className="items-start">
              <CreditCard />
              <p>Payment Method</p>
            </div>
            <ChevronRight />
          </div>
        </Link>
        <Link to={"/profile/address"}>
          <div className="list-item">
            <div className="items-start">
              <MapPin />
              <p>My Address</p>
            </div>
            <ChevronRight />
          </div>
        </Link>
        <Link to={"/signout"}>
          <div className="list-item">
            <div className="items-start">
              <DoorOpen />
              <p>Sign Out</p>
            </div>
            <ChevronRight />
          </div>
        </Link>
      </div>
    </div>
  );
}

export default Profile;

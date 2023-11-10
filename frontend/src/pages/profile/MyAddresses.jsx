import { Link } from "react-router-dom";
import { apiDomain } from "../../helpers/apiDomain";
import useFetch from "../../hooks/useFetch";
import { MapPin, PencilLine, Plus } from "lucide-react";

function MyAddresses() {
  const addresses = useFetch(`${apiDomain.https}/api/addresses`);

  return (
    <div className="my-addresses-page">
      <div className="heading">
        <h1>Add Address</h1>
      </div>
      <ul>
        {addresses?.data?.map((address) => (
          <li key={address.id}>
            <Link to={`/profile/address/${address.id}`}>
              <MapPin />
              <div className="text-container">
                <h2>{address.streetName}</h2>
                <p>
                  {address.city}, {address.postalCode}
                </p>
              </div>
              <PencilLine />
            </Link>
          </li>
        ))}
      </ul>
      <div className="add-container">
        <Link to="/profile/address/add">
          <Plus />
          <span>Add new address</span>
        </Link>
      </div>
    </div>
  );
}

export default MyAddresses;

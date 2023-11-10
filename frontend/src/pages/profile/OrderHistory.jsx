import useFetch from "../../hooks/useFetch";
import { apiDomain } from "../../helpers/apiDomain";
import { useEffect, useState } from "react";
import { Link, useNavigate } from "react-router-dom";
import getCookieByName from "../../helpers/getCookieByName";
import { Check, PackageOpen, ShoppingBag, Truck } from "lucide-react";
import PageIconCircle from "../../components/PageIconCircle";

function OrderHistory() {
  const orders = useFetch(`${apiDomain.https}/api/orders`);
  const authToken = getCookieByName("Authorization");
  const navigate = useNavigate();
  const [openOrderId, setOpenOrderId] = useState(null);

  useEffect(() => {
    // Login failed
    if (!authToken || orders.error) {
      // Delete cookie to prevent infinite redirects
      document.cookie = `Authorization=; expires="${new Date(
        0
      ).toUTCString()}" path=/; secure; SameSite=Lax`;
      navigate("/signin");
    }
  }, [authToken, orders, navigate]);

  const formatDateString = (inputDateString) => {
    const options = {
      month: "short",
      day: "numeric",
      year: "numeric",
      hour: "numeric",
      minute: "numeric",
      hour12: false,
    };

    const inputDate = new Date(inputDateString);
    const formattedDate = inputDate.toLocaleDateString("en-US", options);

    return formattedDate;
  };

  const getIcon = (status) => {
    switch (status) {
      case "Processing":
        return <PackageOpen size={16} />;
      case "Shipped":
        return <Truck size={16} />;
      case "Done":
        return <Check size={16} />;
    }
  };

  if (orders?.data?.length === 0) {
    return (
      <div className="cart-page empty">
        <PageIconCircle icon={<ShoppingBag />} />
        <div>
          <h2>You haven{"'"}t place an order.</h2>
          <p>You can start shopping by pressing the button below!</p>
        </div>
        <Link to="/products" className="button button-black">
          Shop now
        </Link>
      </div>
    );
  }

  return (
    <div className="order-history-page">
      <ul>
        {orders?.data?.map((order) => (
          <li key={order.orderDate}>
            <div
              className="order-details"
              onClick={() => setOpenOrderId(order.id === openOrderId ? null : order.id)}
            >
              <div className="left-container">
                <p className="id">#{order.id}</p>
                <p className="date">{formatDateString(order.orderDate)}</p>
              </div>
              <div className="right-container">
                <p className={`status ${order.status}`}>
                  {order.status} {getIcon(order.status)}
                </p>
                <p className="total">${order.totalPrice}</p>
              </div>
            </div>
            <div className={`product-container ${openOrderId == order.id ? "active" : ""}`}>
              {order.items.map((item) => (
                <div className="product" key={item.product.id + crypto.randomUUID()}>
                  <p>
                    {item.product.name}, {item.size}
                  </p>
                  <p>
                    {item.quantity} x ${item.product.price}
                  </p>
                </div>
              ))}
            </div>
          </li>
        ))}
      </ul>
    </div>
  );
}

export default OrderHistory;

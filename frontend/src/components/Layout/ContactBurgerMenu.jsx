import { ArrowRight, Mail, MapPin, Menu, PhoneCall } from "lucide-react";
import { Link } from "react-router-dom";

function ContactBurgerMenu({ sidebarOpenState }) {
  const [sidebarOpen, setSidebarOpen] = sidebarOpenState;
  const handleBurgerClick = () => {
    setSidebarOpen(!sidebarOpen);
  };

  const handleBackgroundClick = (e) => {
    if (e.target.classList.contains("open")) setSidebarOpen(false);
  };

  return (
    <>
      <button onClick={handleBurgerClick} className="contact-burger-button">
        <Menu />
      </button>
      <div
        onClick={handleBackgroundClick}
        className={`${sidebarOpen ? "open" : "closed"} contact-bg`}
      ></div>
      <div className={`${sidebarOpen ? "open" : "closed"} contact-sidebar`}>
        <div className="contact-container">
          <div className="content-top">
            <h2>Contact us</h2>
            <Link>
              <div className="sidebar-icon">
                <MapPin className="icon" />
              </div>
              <div className="sidebar-text">
                <p>27 Division St, New York </p>
                <p> NY 10002, USA</p>
              </div>
            </Link>

            <Link>
              <div className="sidebar-icon">
                <Mail className="icon" />
              </div>
              <div className="sidebar-text">
                <p>manerosale@mail.com </p>
                <p>manerosupport@mail.com </p>
              </div>
            </Link>

            <Link>
              <div className="sidebar-icon">
                <PhoneCall className="icon" />
              </div>
              <div className="sidebar-text">
                <p>+17 123456789</p>
                <p>+17 987654321</p>
              </div>
            </Link>
          </div>
          <div className="content-bottom">
            <p>Track your order</p>
            <div className="input-container">
              <input type="text" placeholder="Order ID" />
              <button type="submit">
                <div className="container-arrow">
                  <ArrowRight />
                </div>
              </button>
            </div>
          </div>
        </div>
      </div>
    </>
  );
}

export default ContactBurgerMenu;

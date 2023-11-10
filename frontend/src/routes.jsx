import Home from "./pages/Home";
import Search from "./pages/products/Search";
import SignIn from "./pages/profile/SignIn";
import SignUp from "./pages/profile/SignUp";
import Profile from "./pages/profile/Profile";
import ForgotPassword from "./pages/profile/ForgotPassword";
import ResetPassword from "./pages/profile/ResetPassword";
import Cart from "./pages/order/Cart";
import Products from "./pages/products/Products";
import ProductDetails from "./pages/products/ProductDetails";
import ShippingDetails from "./pages/order/ShippingDetails";
import WishList from "./pages/products/WishList";
import OrderConfirmation from "./pages/order/OrderConfirmation";
import AddPaymentCard from "./pages/order/AddPaymentCard";
import NotFound from "./pages/NotFound";
import Checkout from "./pages/order/Checkout";
import SignOut from "./pages/profile/SignOut";
import OrderHistory from "./pages/profile/OrderHistory";
import EditProfile from "./pages/profile/EditProfile";
import MyAddresses from "./pages/profile/MyAddresses";
import AddAddress from "./pages/profile/AddAddress";
import UpdateAddress from "./pages/profile/UpdateAddress";
import UserPaymentMethods from "./pages/profile/UserPaymentMethods";
import UserAddPaymentMethods from "./pages/profile/UserAddPaymentMethods";
import EditCard from "./pages/profile/EditCard";
import ChangePassword from "./pages/profile/ChangePassword";

// If no title is set, the manero logo will show instead
const routes = [
  { path: "*", element: <NotFound />, title: "Not Found" },
  { path: "/", element: <Home /> },
  { path: "/search", element: <Search /> },
  { path: "/cart", element: <Cart /> },
  { path: "/wishlist", element: <WishList /> },
  { path: "/signin", element: <SignIn />, title: "Sign in" },
  { path: "/signup", element: <SignUp />, title: "Sign up" },
  { path: "/signout", element: <SignOut />, title: "Sign out" },
  { path: "/profile", element: <Profile />, title: "Profile" },
  { path: "/profile/edit", element: <EditProfile />, title: "Edit Profile" },
  { path: "/profile/edit/changepassword", element: <ChangePassword />, title: "Change Password" },
  { path: "/profile/address", element: <MyAddresses />, title: "My Addresses" },
  { path: "/profile/address/:id", element: <UpdateAddress />, title: "My Address" },
  { path: "/profile/address/add", element: <AddAddress />, title: "Add address" },
  { path: "/profile/orders", element: <OrderHistory />, title: "Order History" },
  { path: "/profile/payment", element: <UserPaymentMethods />, title: "Payment Methods" },
  { path: "/profile/payment/add", element: <UserAddPaymentMethods />, title: "Add new a card" },
  { path: "/profile/payment/card/:id", element: <EditCard />, title: "Add new a card" },
  { path: "/forgot-password", element: <ForgotPassword />, title: "Forgot Password" },
  { path: "/reset-password", element: <ResetPassword />, title: "Reset Password" },
  { path: "/products", element: <Products />, title: "Products" },
  { path: "/products/:id", element: <ProductDetails /> },
  { path: "/checkout", element: <Checkout />, title: "Checkout" },
  { path: "/checkout/shipping", element: <ShippingDetails />, title: "Shipping" },
  {
    path: "/checkout/order-confirmation",
    element: <OrderConfirmation />,
    title: "Order Confirmation",
  },
  { path: "/checkout/add-card", element: <AddPaymentCard />, title: "Add new a card" },
];

export default routes;

import { ShoppingBag } from "lucide-react";
import PageIconCircle from "../components/PageIconCircle";
import { useContext } from "react";
import { CartContext } from "../App";
import useFetch from "../hooks/useFetch";
import { apiDomain } from "../helpers/api-domain";
import { CartProductCard } from "../components/CartProductCard";

export default function Cart() {
  const [cart, setCart] = useContext(CartContext);

  // TODO: Fetch products and adding to cart for testing purposes
  const products = useFetch(`${apiDomain.https}/api/products`);

  // Page if cart is empty
  if (cart.length == 0)
    return (
      <div className="cart-page empty">
        <PageIconCircle icon={<ShoppingBag />} />
        <div>
          <h2>Your cart is empty!</h2>
          <p>Looks like you haven{"'"}t added any products yet.</p>
        </div>
        <button onClick={() => setCart(products.data)}>hämta produkter för att testa</button>
      </div>
    );

  // Page if cart is not empty
  return (
    <div className="cart-page not-empty">
      <div className="cart">
        {cart.map((cartItem) => (
          <CartProductCard key={cartItem.id} cartItem={cartItem} />
        ))}
      </div>
      <div className="total">
        <div>
          <p>Total</p>
          <span>${cart.reduce((a, b) => a + b.price, 0).toFixed(2)}</span>
        </div>
      </div>
    </div>
  );
}

import { createContext, useContext, useState } from "react";
import CartItem from "../models/CartItem";

const CartContext = createContext(null);

export function CartContextProvider({ children }) {
  const [cart, setCart] = useState([]);

  const findCartItem = (itemId) => cart.find((item) => item.itemId === itemId);

  const addToCart = (incomingProduct, amount = 1, size = "M") => {
    // Add amount and size to the incoming product object
    const newCartItem = new CartItem(incomingProduct, size, amount);

    // Check if the incoming item is already in cart
    const sameItemInCart = cart.find((item) => item.itemId === newCartItem.itemId);

    // Add to the amount if the item is already in cart else add new incoming item
    if (sameItemInCart) {
      sameItemInCart.amount += amount;
      setCart([...cart]);
    } else {
      setCart([...cart, newCartItem]);
    }
  };

  const removeFromCart = (itemId) => {
    setCart([...cart.filter((x) => x.itemId !== itemId)]);
  };

  // Doesn't take size into account
  const removeProductFromCart = (productId) => {
    setCart([...cart.filter((x) => x.id !== productId)]);
  };

  const incrementCartItemAmount = (itemId) => {
    const cartItem = findCartItem(itemId);
    cartItem.amount += 1;
    setCart([...cart]);
  };

  const decrementCartItemAmount = (itemId) => {
    const cartItem = findCartItem(itemId);
    cartItem.amount -= 1;
    if (cartItem.amount <= 0) {
      removeFromCart(itemId);
    } else {
      setCart([...cart]);
    }
  };

  const isInCart = (productId) => {
    return cart.some((item) => item.id === productId);
  };

  return (
    <CartContext.Provider
      value={{
        cart,
        addToCart,
        removeFromCart,
        removeProductFromCart,
        incrementCartItemAmount,
        decrementCartItemAmount,
        isInCart,
      }}
    >
      {children}
    </CartContext.Provider>
  );
}

export const useCart = () => useContext(CartContext);

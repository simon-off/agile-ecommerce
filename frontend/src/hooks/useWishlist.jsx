import { createContext, useState, useContext, useEffect } from "react";
import WishlistItem from "../models/WishlistItem";
import { useToast } from "./useToast";

const WishlistContext = createContext(null);

const GetInitialState = () => {
  const localWishlist = localStorage.getItem("wishlist");
  return localWishlist ? JSON.parse(localWishlist) : [];
};

export function WishlistContextProvider({ children }) {
  const [wishlist, setWishlist] = useState(GetInitialState);
  const toast = useToast();

  useEffect(() => {
    localStorage.setItem("wishlist", JSON.stringify(wishlist));
  }, [wishlist]);

  const addToWishlist = (incomingProduct, amount = 1, size = "M") => {
    const newWishlistItem = new WishlistItem(incomingProduct, size, amount);

    const sameProductInWishlist = wishlist.find((item) => item.itemId === newWishlistItem.itemId);

    if (sameProductInWishlist) {
      sameProductInWishlist.amount += amount;
      setWishlist([...wishlist]);
    } else {
      setWishlist([...wishlist, newWishlistItem]);
    }

    toast.add(`Added ${incomingProduct.name} to cart!`);
    return wishlist;
  };

  const removeFromWishlist = (productId) => {
    setWishlist([...wishlist.filter((x) => x.id !== productId)]);
  };

  const isInWishlist = (productId) => {
    return wishlist.some((item) => item.id === productId);
  };


  return (
    <WishlistContext.Provider
      value={{
        wishlist,
        addToWishlist,
        removeFromWishlist,
        isInWishlist,
      }}
    >
      {children}
    </WishlistContext.Provider>
  );
}

export const useWishlist = () => useContext(WishlistContext);

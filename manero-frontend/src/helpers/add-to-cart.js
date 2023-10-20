export const handleAddToCart = (cartState, product, amount = 1, size = "M") => {
  const [cart, setCart] = cartState;

  const itemInCart = cart.find((item) => item.id === product.id);

  if (itemInCart) {
    amount += itemInCart.amount;
    setCart([...cart.filter((item) => item.id !== itemInCart.id), { ...product, amount, size }]);
  } else {
    setCart([...cart, { ...product, amount, size }]);
  }
};

function CheckoutItem({ cartItem }) {
  return (
    <div className="checkout-product">
      <div className="product-details">
        <span>
          {cartItem.name}, {cartItem.size}{" "}
        </span>
      </div>
      <div className="product-total">
        <span>
          {cartItem.amount} x ${cartItem.price}
        </span>
      </div>
    </div>
  );
}

export default CheckoutItem;

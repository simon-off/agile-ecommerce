export default function hideCreditCardNumber(cardNumber) {
  return cardNumber
    .split("")
    .map((char, i) => {
      if (char === " ") {
        return " ";
      } else if (i >= cardNumber.length - 4) {
        return char;
      } else {
        return "*";
      }
    })
    .join("");
}

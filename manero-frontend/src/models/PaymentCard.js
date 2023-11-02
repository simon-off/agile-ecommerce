export default class PaymentCard {
  constructor(cardNumber, expirationDate, cvvNumber, nameOnCard) {
    this.cardNumber = cardNumber;
    this.expirationDate = expirationDate;
    this.cvvNumber = cvvNumber;
    this.nameOnCard = nameOnCard;
  }
}

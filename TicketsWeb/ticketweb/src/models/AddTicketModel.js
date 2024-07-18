export default class AddTicketModel {
  constructor(name, category, userId, eventId, expirationDate, price) {
    (this.name = name), (this.category = category);
    (this.userId = userId), (this.eventId = eventId);
    (this.expirationDate = expirationDate);
    (this.price = price)
  }
}

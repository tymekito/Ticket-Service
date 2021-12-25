export default class AddEventModel {
  constructor(name, category, description, ownerId, eventDate, price) {
    (this.name = name), (this.category = category);
    this.description = description;
    this.ownerId = ownerId;
    this.eventDate = eventDate;
    this.price = price;
  }
}

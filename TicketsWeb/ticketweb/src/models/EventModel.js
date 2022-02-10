import BookModel from "./BookModel";
export default class EventModel {
  constructor(data) {
    (this.id = data.id),
      (this.name = data.name),
      (this.category = data.category);
    this.description = data.description;
    this.books = data.booka.map((book) => new BookModel(book));
    this.eventDate = new Date(data.eventDate).toLocaleString();
    this.price = data.price;
  }
}

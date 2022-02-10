export default class AddBookModel {
  constructor(name, category, userId, expirationDate) {
    (this.name = name), (this.category = category);
    (this.userId = userId);
    (this.expirationDate = expirationDate);
  }
}

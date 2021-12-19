export default class AddEventModel {
  constructor(name, category, description, ownerId) {
    (this.name = name), (this.category = category);
    this.description = description;
    this.ownerId = ownerId;
  }
}

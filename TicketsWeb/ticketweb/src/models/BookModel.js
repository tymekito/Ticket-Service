export default class BookModel {
    constructor(data) {
        this.id = data.id,
        this.name = data.name,
        this.category = data.category;
        this.author = data.author;
        this.expirationDate = new Date(data.expirationDate).toLocaleString();
    }
}
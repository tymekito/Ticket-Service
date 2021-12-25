export default class TicketModel {
    constructor(data) {
        this.id = data.id,
        this.name = data.name,
        this.category = data.category;
        this.expirationDate = new Date(data.expirationDate).toLocaleString();
        this.price = data.price;
    }
}
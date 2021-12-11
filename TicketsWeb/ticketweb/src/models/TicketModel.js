export default class TicketModel {
    constructor(data) {
        this.id = data.id,
        this.name = data.name,
        this.category = data.category;
    }
}
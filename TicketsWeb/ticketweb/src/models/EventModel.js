import TicketModel from "./TicketModel";
export default class EventModel {
  constructor(data) {
    (this.id = data.id),
      (this.name = data.name),
      (this.category = data.category);
    this.description = data.description;
    this.tickets = data.tickets.map((ticket) => new TicketModel(ticket));
  }
}

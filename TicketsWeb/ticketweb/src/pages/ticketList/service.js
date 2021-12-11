import TicketModel from "../../models/TicketModel";
import client from "../../shared/api";

const service = {
    async getTickets(){
        try{
            const resource = "/api/ticket";
            const result = await client.get(resource);
            return result.data.map((item) => new TicketModel(item));
        } catch{
            return {};
        }
    },
    async deleteTicket(ticketId){
        const resource = `/api/ticket/${ticketId}`;
        await client.delete(resource);
    }
}

export default service;
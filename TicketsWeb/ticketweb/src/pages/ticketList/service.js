import TicketModel from "../../models/TicketModel";
import client from "../../shared/api";

const service = {
    async getTickets(userId){
        try{
            const resource = `/api/ticket/${userId}`;
            const result = await client.get(resource);
            return result.data.map((item) => new TicketModel(item));
        } catch{
            return {};
        }
    },
    async payForTicket(userInfo) {
        try {
          const resource = "/api/payment";
          const result = await client.postFormData(resource, userInfo);
          return result.data;
        } catch {
          return null;
        }
    },    
    async deleteTicket(ticketId){
        const resource = `/api/ticket/${ticketId}`;
        await client.delete(resource);
    },
    async buyTicketOnEvent(ticket) {
        const resource = `/api/ticket`;
        await client.post(resource, ticket);
    }

}

export default service;
import client from "../../shared/api";

const service = {
    async getTickets(){
        try{
            const resource = "/api/ticket";
            const result = await client.get(resource);
            return result.data;
        } catch{
            return {};
        }
    }
}

export default service;
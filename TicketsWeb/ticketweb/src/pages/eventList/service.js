import EventModel from "../../models/EventModel";
import client from "../../shared/api";

const service = {
    async getEvents(){
        try{
            const resource = "/api/event";
            const result = await client.get(resource);
            return result.data.map((item) => new EventModel(item));
        } catch{
            return {};
        }
    },
    async deleteEvent(eventId){
        const resource = `/api/event/${eventId}`;
        await client.delete(resource);
    }
}

export default service;
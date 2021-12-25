import EventModel from "../../models/EventModel";
import client from "../../shared/api";

const service = {
    async getMyEvents(userId){
        try{
            const resource = `/api/event/${userId}`;
            const result = await client.get(resource);
            return result.data.map((item) => new EventModel(item));
        } catch{
            return {};
        }
    },
    async addMyEvent(event){
        const resource = `/api/event/`;
        await client.post(resource,event);
    },
    async deleteMyEvent(eventId){
        const resource = `/api/event/${eventId}`;
        await client.delete(resource);
    }
}

export default service;
import BookModel from "../../models/BookModel";
import client from "../../shared/api";

const service = {
    async getBooks(userId){
        try{
            const resource = `/api/book/${userId}`;
            const result = await client.get(resource);
            return result.data.map((item) => new BookModel(item));
        } catch{
            return {};
        }
    },
    async returnBook(bookId){
        const resource = `/api/book/${bookId}`;
        await client.post(resource);
    },
    async addMyBook(event){
        const resource = `/api/book/`;
        await client.post(resource,event);
    },

}

export default service;
import BookModel from "../../models/BookModel";
import client from "../../shared/api";

const service = {
    async getBooks(){
        try{
            const resource = `/api/book`;
            const result = await client.get(resource);
            return result.data.map((item) => new BookModel(item));
        } catch{
            return {};
        }
    },
    async borrowBook(bookId, userId){
        const resource = `/api/book/${bookId}/${userId}`;
        await client.post(resource);
    },
}

export default service;
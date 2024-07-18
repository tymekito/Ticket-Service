
import client from "../../shared/api";

const service = {
    async addMoneyToUserWallet(payment) {
        try {
          const resource = "/api/wallet";
          console.log(payment)
          await client.postFormData(resource, payment);
        } catch {
          return null;
        }
    },    
}

export default service;
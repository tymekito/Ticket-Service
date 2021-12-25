import client from "../../shared/api";

const service = {
  async logIn(userInfo) {
    try {
      const resource = "/api/login";
      const result = await client.postFormData(resource, userInfo);
      return result.data;
    } catch {
      return null;
    }
  },
  async getUserDetails(userId){
    try{
        const resource = `/api/user/${userId}`;
        const result = await client.get(resource);
          return result.data;
    } catch{
        return {};
    }
},
  async registerUser(userInfo) {
    try {
      const resource = "/api/user";
      const result = await client.post(resource, userInfo);
      return result.data;
    } catch {
      return null;
    }
  },
};
export default service;

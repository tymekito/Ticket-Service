import axios from 'axios';

const api = axios.create({
  baseURL: 'https://localhost:44365',
});

//api.defaults.headers.common['X-Requested-With'] = 'XMLHttpRequest';


const client = {
  async get(resource, params, handleError = true) {
    const config = {
      params,
      headers: {
      },
    };
    try {
     const result = await api.get(resource, config);
      return result;
    } catch (ex) {
      if (handleError) {
          console.log(ex)
      }
      throw ex;
    }
  },

  async post(resource, data, params, handleError = true) {
    const config = {
      params,
      headers: {
      },
    };
    try {
      const result = await api.post(resource, data, config);
      return result;
    } catch (ex) {
      if (handleError) {
        console.log(ex)
      }
      throw ex;
    }
  },
  async postFormData(resource, data, params, handleError = true) {
    const config = {
      params,
      headers: {
        'Content-Type': 'multipart/form-data',
      },
    };
    try {
      const result = await api.post(resource, data, config);
      return result;
    } catch (ex) {
      if (handleError) {
        console.log(ex)
      }
      throw ex;
    }
  },

  async put(resource, data, params, handleError = true) {
    const config = {
      params,
      headers: {
      },
    };
    try {
      const result = await api.put(resource, data, config);
      return result;
    } catch (ex) {
      if (handleError) {
        console.log(ex)
      }
      throw ex;
    }
  },

  async delete(resource, params, handleError = true) {
    const config = {
      params,
      headers: {
      },
    };
    try {
      const result = await api.delete(resource, config);
      return result;
    } catch (ex) {
      if (handleError) {
        console.log(ex)
      }
      throw ex;
    }
  },
};

export default client;

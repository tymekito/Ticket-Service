import myEventService from "./service";

const getDefultState = () => ({
  myEventList: 0,
  selectedEvent: null,
});

const state = getDefultState();

const getters = {
  myEventList: (state) => state.myEventList,
  selectedEvent: (state) => state.selectedEvent,
};

const actions = {
  async getMyEventList({ commit },userId) {
    const myEventList = await myEventService.getMyEvents(userId);
    commit("setMyEventList", myEventList);
  },
  async addMyEvent(state, myEvent){
    await myEventService.addMyEvent(myEvent);
  },
  async deleteMyEvent(state, eventId){
    await myEventService.deleteMyEvent(eventId);
  }
};

const mutations = {
  setMyEventList(state, data) {
    state.myEventList = data;
  },
};

const module = {
  namespaced: true,
  state,
  getters,
  actions,
  mutations,
};

export default module;
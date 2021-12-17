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
  async getEventList({ commit }) {
    const myEventList = await myEventService.getMyEvents();
    commit("setEventList", myEventList);
  },
  async deleteEvent(state, eventId){
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

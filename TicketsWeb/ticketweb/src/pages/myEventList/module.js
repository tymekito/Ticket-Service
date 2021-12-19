import myEventService from "./service";

const getDefultState = () => ({
  myEventList: 0,
  selectedEvent: null,
  search: '',
});

const state = getDefultState();

const getters = {
  myEventList: (state) => state.myEventList,
  selectedEvent: (state) => state.selectedEvent,
  search: (state) => state.search,
};

const actions = {
  async getMyEventList({ commit }) {
    const myEventList = await myEventService.getMyEvents();
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
  setSearch(state, search) {
    state.search = search;
  }
};

const module = {
  namespaced: true,
  state,
  getters,
  actions,
  mutations,
};

export default module;

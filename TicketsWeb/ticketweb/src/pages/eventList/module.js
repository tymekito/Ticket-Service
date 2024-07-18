import eventService from "./service";

const getDefultState = () => ({
  eventList: 0,
  selectedEvent: null,
});

const state = getDefultState();

const getters = {
  eventList: (state) => state.eventList,
  selectedEvent: (state) => state.selectedEvent,
};

const actions = {
  async getEventList({ commit }) {
    const eventList = await eventService.getEvents();
    commit("setEventList", eventList);
  },
  async deleteEvent(state, eventId){
    await eventService.deleteEvent(eventId);
  }
};

const mutations = {
  setEventList(state, data) {
    state.eventList = data;
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

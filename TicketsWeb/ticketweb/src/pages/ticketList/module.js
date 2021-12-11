import ticketService from "./service";

const getDefultState = () => ({
  ticketList: 0,
  selectedTicket: null,
});

const state = getDefultState();

const getters = {
  ticketList: (state) => state.ticketList,
  selectedTicket: (state) => state.selectedTicket,
};

const actions = {
  async getTicketList({ commit }) {
    const ticketList = await ticketService.getTickets();
    commit("setTicketList", ticketList);
  },
  async deleteTicket(state, ticketId){
    await ticketService.deleteTicket(ticketId);
  }
};

const mutations = {
  setTicketList(state, data) {
    state.ticketList = data;
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

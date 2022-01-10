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
  async getTicketList({ commit }, userId) {
    const ticketList = await ticketService.getTickets(userId);
    commit("setTicketList", ticketList);
  },
  async deleteTicket(state, ticketId) {
    await ticketService.deleteTicket(ticketId);
  },
  async buyTicketOnEvent(state, ticket) {
    await ticketService.buyTicketOnEvent(ticket);
  },
  async payForTicket(state, paymentInfo) {
    const form = new FormData();
    form.append("userId", paymentInfo.Id);
    form.append("amount", paymentInfo.Amount);
    form.append("eventId", paymentInfo.EventId);
    const result = await ticketService.payForTicket(form);

    return result;
  },
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

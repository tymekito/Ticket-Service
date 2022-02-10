import allBookService from "./service";

const getDefultState = () => ({
  bookList: 0,
  selectedBook: null,
});

const state = getDefultState();

const getters = {
  bookList: (state) => state.bookList,
  selectedBook: (state) => state.selectedBook,
};

const actions = {
  async getBookList({ commit }) {
    const bookList = await allBookService.getBooks();
    commit("setBookList", bookList);
  },
  async borrowBook(state, model) {
    console.log(model);
    await allBookService.borrowBook(model.bookId,model.userId);
  },
};

const mutations = {
  setBookList(state, data) {
    state.bookList = data;
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

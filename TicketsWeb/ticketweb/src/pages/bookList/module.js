import bookService from "./service";

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
  async getBookList({ commit }, userId) {
    const bookList = await bookService.getBooks(userId);
    commit("setBookList", bookList);
  },
  async returnBook(state, bookId) {
    await bookService.returnBook(bookId);
  },
  async buyBookOnEvent(state, book) {
    await bookService.buyBookOnEvent(book);
  },
  async addMyBook(state, myBook){
    await bookService.addMyBook(myBook);
  },
  async payForBook(state, paymentInfo) {
    const form = new FormData();
    form.append("userId", paymentInfo.Id);
    form.append("amount", paymentInfo.Amount);
    form.append("eventId", paymentInfo.BookId);
    const result = await bookService.payForBook(form);

    return result;
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

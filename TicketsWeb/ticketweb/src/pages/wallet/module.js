import paymentService from "./service";

const actions = {
  async addMoneyToUserWallet(state, paymentInfo) {
    const form = new FormData();
    form.append("userId", paymentInfo.userId);
    form.append("amount", paymentInfo.amount);
    const result = await paymentService.addMoneyToUserWallet(form);

    return result;
  },
};

const module = {
  namespaced: true,
  actions,
};

export default module;

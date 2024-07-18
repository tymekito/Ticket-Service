import loginService from "./service";
import UserModel from "../../models/UserModel";
import UserDetailsModel from "../../models/UserDetailsModel";

const getDefultState = () => ({
  userDetails: {},
  loggedIn: false,
});

const state = getDefultState();

const getters = {
  userDetails: (state) => state.userDetails,
  isLoggedIn: (state) => state.loggedIn,
};

const actions = {
  async logInUser({ commit }, userInfo) {
    const form = new FormData();
    form.append("login", userInfo.login);
    form.append("password", userInfo.password);
    const userDetails = new UserModel(await loginService.logIn(form));
    if (userDetails !== null) {
      commit("setUserDetails", userDetails);
      commit("setLoggedIn", true);
      return true;
    }
    commit("setLoggedIn", false);
    return false;
  },
  async refreshUserData({ commit }, userId) {
    const result = new UserDetailsModel(
      await loginService.getUserDetails(userId)
    );
    commit("setUserDetails", result);
  },
  async registerUser(state, user) {
    await loginService.registerUser(user);
  },
  signOut({ commit }) {
    commit("setSignOut");
    commit("setLoggedIn", false);
  },
};

const mutations = {
  setUserDetails(state, userDetails) {
    state.userDetails = {
      userLogin: userDetails.userLogin,
      userId: userDetails.userId,
      userName: userDetails.userName,
      wallet: userDetails.wallet,
    };
  },
  setSignOut(state) {
    state.userDetails = {};
  },
  setLoggedIn(state, data) {
    state.loggedIn = data;
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

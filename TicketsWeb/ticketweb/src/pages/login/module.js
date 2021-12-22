import loginService from "./service";

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
    console.log(userInfo);
    const form = new FormData();
    form.append("login", userInfo.login);
    form.append("password", userInfo.password);
    const userDetails = await loginService.logIn(form);
    if (userDetails !== null) {
      commit("setUserDetails", userDetails);
      commit("setLoggedIn", true);
      return true;
    }
    commit("setLoggedIn", false);
    return false;
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
      userLogin: userDetails.UserLogin,
      userId: userDetails.UserId,
      userName: userDetails.UserName,
    };
    console.log(userDetails);
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

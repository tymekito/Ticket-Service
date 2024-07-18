import Vue from "vue";
import VueRouter from "vue-router";
import store from "./store";
import ticketRoutes from "./pages/ticketList/router";
import homeRoutes from "./pages/home/router";
import eventsRoutes from "./pages/eventList/router";
import myEventsRoutes from "./pages/myEventList/router";
import loginRoutes from "./pages/login/router";
import walletRoutes from "./pages/wallet/router";

Vue.use(VueRouter);

const router = new VueRouter({
  routes: [ticketRoutes, homeRoutes, eventsRoutes, myEventsRoutes, walletRoutes, loginRoutes],
});

router.beforeEach((to, from, next) => {
  const isLoggedIn = store.getters["login/isLoggedIn"];
  if (to.path === "/") {
    next();
    return;
  }
  if (to.path === "/login") {
    next();
    return;
  }
  if (to.path === "/logout") {
    store.dispatch("login/signOut");
    router.push("login").catch(() => {});
    return;
  }
  if (!isLoggedIn) {
    router.push("login").catch(() => {});
    return;
  }
  if (isLoggedIn) {
    next();
    return;
  }
});

export default router;

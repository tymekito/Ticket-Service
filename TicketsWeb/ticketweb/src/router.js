import Vue from "vue";
import VueRouter from "vue-router";
import store from "./store";
import bookRoutes from "./pages/bookList/router";
import allbookRoutes from "./pages/allbookList/router";
import homeRoutes from "./pages/home/router";
import loginRoutes from "./pages/login/router";

Vue.use(VueRouter);

const router = new VueRouter({
  routes: [bookRoutes, homeRoutes, allbookRoutes, loginRoutes],
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

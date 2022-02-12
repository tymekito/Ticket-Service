<template>
  <v-app id="inspire">
    <v-navigation-drawer v-model="drawer" app>
      <v-list-item>
        <v-list-item-content>
          <v-list-item-title class="text-h6"> LibraryApp </v-list-item-title>
        </v-list-item-content>
      </v-list-item>

      <v-divider></v-divider>

      <v-list dense nav>
        <v-list-item
          v-for="item in pagesList"
          :key="item.title"
          :to="item.to"
          link
        >
          <v-list-item-icon>
            <v-icon>{{ item.icon }}</v-icon>
          </v-list-item-icon>

          <v-list-item-content>
            <v-list-item-title>{{ item.title }}</v-list-item-title>
          </v-list-item-content>
        </v-list-item>
      </v-list>
    </v-navigation-drawer>
    <v-app-bar app absolute color="#43a047" dark>
      <template v-slot:img="{ props }">
        <v-img
          v-bind="props"
          gradient="to top right, rgba(55,236,186,.7), rgba(25,32,72,.7)"
        ></v-img>
      </template>

      <v-app-bar-nav-icon @click="drawer = !drawer"></v-app-bar-nav-icon>

      <!-- <v-app-bar-title>Title</v-app-bar-title> -->
      <v-spacer></v-spacer>
    </v-app-bar>
    <v-sheet
      id="scrolling-techniques-5"
      absolute
      fixed-header
      elevate-on-scroll
    >
      <v-main>
        <router-view></router-view>
      </v-main>
    </v-sheet>
  </v-app>
</template>

<script>
import { mapGetters } from "vuex";
import { mdiWalletOutline } from "@mdi/js";
export default {
  name: "app",
  componetns: {},
  data: () => ({
    loggedItems: [
      { title: "Home", icon: "mdi-view-dashboard", to: "/" },
      {
        title: "MyBooks",
        icon: "mdi-image",
        to: "/books",
      },
      {
        title: "Books",
        icon: "mdi-image",
        to: "/allbooks",
      },
      {
        title: "Logout",
        icon: "mdi-help-box",
        to: "/logout",
      },
    ],
    unLoggedItems: [
      { title: "Home", icon: "mdi-view-dashboard", to: "/" },
      { title: "Login", icon: "mdi-help-box", to: "/login" },
    ],
    pagesList: [],
    drawer: false,
    icons: {
      mdiWalletOutline,
    },
  }),
  mounted() {
    this.pagesList = this.isLoggedIn ? this.loggedItems : this.unLoggedItems;
  },
  methods: {
    changePageList() {
      this.pagesList = this.isLoggedIn ? this.loggedItems : this.unLoggedItems;
    },
  },
  computed: {
    ...mapGetters("login", ["isLoggedIn", "userDetails"]),
  },
  watch: {
    isLoggedIn: function () {
      this.changePageList();
    },
  },
};
</script>

<style>
.sticky {
  position: fixed;
  top: 0;
  width: 100%;
}
.wallet {
  display: flex;
  align-items: flex-end;
  margin-left: 88%;
}
</style>

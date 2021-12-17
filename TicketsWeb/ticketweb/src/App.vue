<template>
  <v-app id="inspire">
    <v-navigation-drawer v-model="drawer" app>
      <v-list-item>
        <v-list-item-content>
          <v-list-item-title class="text-h6"> BuyTicketApp </v-list-item-title>
          <v-list-item-subtitle> Buy and dont cry </v-list-item-subtitle>
        </v-list-item-content>
      </v-list-item>

      <v-divider></v-divider>

      <v-list dense nav>
        <v-list-item v-for="item in items" :key="item.title" :to="item.to" link>
          <v-list-item-icon>
            <v-icon>{{ item.icon }}</v-icon>
          </v-list-item-icon>

          <v-list-item-content>
            <v-list-item-title>{{ item.title }}</v-list-item-title>
          </v-list-item-content>
        </v-list-item>
      </v-list>
    </v-navigation-drawer>
    <v-app-bar
      app
      absolute
      color="#43a047"
      dark
      src="https://picsum.photos/1920/1080?random"
      fade-img-on-scroll
    >
      <template v-slot:img="{ props }">
        <v-img
          v-bind="props"
          gradient="to top right, rgba(55,236,186,.7), rgba(25,32,72,.7)"
        ></v-img>
      </template>

      <v-app-bar-nav-icon @click="drawer = !drawer"></v-app-bar-nav-icon>

      <v-app-bar-title>Title</v-app-bar-title>

      <v-spacer></v-spacer>

      <v-btn icon>
        <v-icon>mdi-magnify</v-icon>
      </v-btn>

      <v-btn icon>
        <v-icon>mdi-heart</v-icon>
      </v-btn>

      <v-btn icon>
        <v-icon>mdi-dots-vertical</v-icon>
      </v-btn>
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
export default {
  name: "app",
  componetns: {},
  data() {
    return {
      items: [
        { title: "Home", icon: "mdi-view-dashboard", to: "/" },
        { title: "MyTickets", icon: "mdi-image", to: "/tickets" },
        { title: "Events", icon: "mdi-help-box", to: "/events" },
        { title: "MyEvents", icon: "mdi-help-box", to: "/myEvents" },
      ],
      drawer: false,
    };
  },
};
</script>

<style>
.sticky {
  position: fixed;
  top: 0;
  width: 100%

}
</style>

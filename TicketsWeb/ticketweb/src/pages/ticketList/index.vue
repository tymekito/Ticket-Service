<template>
  <v-card max-width="1200" height="900" class="mx-auto ticketsContainer">
    <v-container fluid>
      <v-row dense>
        <v-col v-for="ticket in tickets" :key="ticket.name" :cols="6">                 
          <v-card > 
            <!-- TODO on click open ticket details
            przekazać w parametrze klinięty bilet
            dodać możliwość usuwania biletu
             -->
            <v-img
              src="https://picsum.photos/1920/1080?random"
              class="white--text align-end"
              gradient="to bottom, rgba(0,0,0,.1), rgba(0,0,0,.5)"
              height="200px"
            >
              <v-card-title v-text="ticket.name"></v-card-title>
            </v-img>

            <v-card-actions>
                <v-icon>{{calenderIcon}}</v-icon>
                <span>{{'03/12/2021'}}</span>
              <v-spacer></v-spacer>
                <v-icon>{{deleteIcon}}</v-icon>

            </v-card-actions>
          </v-card>
        </v-col>
      </v-row>
    </v-container>
  </v-card>
</template>

<script>
import { mapActions, mapGetters } from "vuex";
import { mdiDelete, mdiCalendarMonth  } from '@mdi/js';
export default {
  data: () => ({
    tickets: [],
    cards: [
      {
        title: "Favorite road trips",
        src: "https://cdn.vuetifyjs.com/images/cards/road.jpg",
        flex: 6,
      },
      {
        title: "Best airlines",
        src: "https://cdn.vuetifyjs.com/images/cards/plane.jpg",
        flex: 6,
      },
    ],
  }),
  mounted() {
    this.getTicketList();
    this.tickets = JSON.parse(JSON.stringify(this.ticketList));
  },
  methods: {
    ...mapActions("ticketList", ["getTicketList"]),
  },
  computed: {
    ...mapGetters("ticketList", ["ticketList"]),
    deleteIcon(){
      return mdiDelete;
    }, 
    calenderIcon(){
      return mdiCalendarMonth;
    }
  },
};
</script>

<style>
.ticketsContainer {
  margin-top: 15px;
  margin-bottom: 15px;
}
</style>

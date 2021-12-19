<template>
<div>
  <v-card max-width="1200" min-height="860" class="mx-auto ticketsContainer">
    <v-container class="spinnerConteiner" v-if="tickets && tickets.length === 0">
      <v-progress-circular
        class="ticketListSpinner"
        :width="5"
        :size="80"
        indeterminate
        color="green"
      ></v-progress-circular>
    </v-container>
    <v-container fluid v-else>
      <v-row dense>
        <v-col v-for="ticket in tickets" :key="ticket.id" :cols="6">
          <v-card @click="onTicketClick(ticket)">
            <v-img
              src="https://picsum.photos/1920/1080?random"
              class="white--text align-end"
              gradient="to bottom, rgba(0,0,0,.1), rgba(0,0,0,.5)"
              height="200px"
            >
              <v-card-title v-text="ticket.name"></v-card-title>
            </v-img>

            <v-card-actions>
              <v-icon>{{ calenderIcon }}</v-icon>
              <span>{{ "03/12/2021" }}</span>
              <v-spacer></v-spacer>
            </v-card-actions>
          </v-card>
        </v-col>
      </v-row>
    </v-container>
    <TicketDetails 
    ref="TicketDetails"
    @deleted ="onDeleteTicket"
    />
  </v-card>
  </div>
</template>

<script>
import { mapActions, mapGetters } from "vuex";
import { mdiCloseCircleOutline , mdiCalendarMonth } from "@mdi/js";
import TicketDetails from "./components/ticketDetails/index.vue";

export default {
  components: {
    TicketDetails,
  },
  data: () => ({
    tickets: [],
    selectedTicket: null,
  }),
  async mounted() {
    await this.refreshPageData();
  },
  methods: {
    ...mapActions("ticketList", ["getTicketList", "deleteTicket"]),
    async onDeleteTicket(){
      await this.deleteTicket(this.selectedTicket.id)
      await this.refreshPageData();
    },
    onTicketClick(ticket){
      this.selectedTicket = ticket;
      this.$refs.TicketDetails.open(ticket)
    },
    async refreshPageData(){
      await this.getTicketList();
      this.tickets = this.ticketList;
    }

  },
  computed: {
    ...mapGetters("ticketList", ["ticketList"]),
    deleteIcon() {
      return mdiCloseCircleOutline ;
    },
    calenderIcon() {
      return mdiCalendarMonth;
    },
  },
};
</script>

<style>
.ticketsContainer {
  margin-top: 15px;
  margin-bottom: 15px;
}
.ticketListSpinner {
  margin-top: 50%;
}
.spinnerConteiner {
  text-align: center;
  width: 50%;
  height: 100%;
}
</style>

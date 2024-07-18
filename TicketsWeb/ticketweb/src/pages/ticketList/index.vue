<template>
  <div>
    <v-alert :value="alert" type="success" @click="alert = false"
      >Returned ticket</v-alert
    >
    <v-card max-width="1200" min-height="860" class="mx-auto ticketsContainer">
      <div class="basePageHeaderText">My Tickets</div>
      <div class="d-flex">
        <div class="ml-3 mr-auto p-2 d-flex">
          <v-text-field
            class="ml-1"
            label="Find Ticket"
            clearable
            dense
            outlined
            prepend-inner-icon="search"
            v-model="query"
          ></v-text-field>
        </div>
      </div>
      <v-container
        class="spinnerConteiner"
        v-if="tickets && tickets.length === 0"
      >
        <v-progress-circular
          class="ticketListSpinner"
          :width="5"
          :size="80"
          indeterminate
          color="green"
        ></v-progress-circular>
      </v-container>
      <v-container fluid v-else>
        <div
          v-if="filteredIteams && filteredIteams.length === 0"
          class="basePageHeaderText noResultText"
        >
          Brak wyników
        </div>
        <v-row dense>
          <v-col v-for="ticket in filteredIteams" :key="ticket.id" :cols="6">
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
      <TicketDetails ref="TicketDetails" @deleted="onDeleteTicket" />
    </v-card>
  </div>
</template>

<script>
import { mapActions, mapGetters } from "vuex";
import { mdiCloseCircleOutline, mdiCalendarMonth } from "@mdi/js";
import TicketDetails from "./components/ticketDetails/index.vue";

export default {
  components: {
    TicketDetails,
  },
  data: () => ({
    tickets: [],
    selectedTicket: null,
    query: "",
    alert: false,
  }),
  async mounted() {
    await this.refreshPageData();
  },
  methods: {
    ...mapActions("ticketList", ["getTicketList", "deleteTicket"]),
    ...mapActions("login", ["refreshUserData"]),

    async onDeleteTicket() {
      await this.deleteTicket(this.selectedTicket.id);
      await this.refreshUserData(this.userDetails.userId);
      await this.refreshPageData();
      this.alert = true;
    },
    onTicketClick(ticket) {
      this.selectedTicket = ticket;
      this.$refs.TicketDetails.open(ticket);
    },
    async refreshPageData() {
      await this.getTicketList(this.userDetails.userId);
      this.tickets = this.ticketList;
      this.alert = false;
    },
  },
  computed: {
    ...mapGetters("ticketList", ["ticketList"]),
    ...mapGetters("login", ["userDetails"]),
    deleteIcon() {
      return mdiCloseCircleOutline;
    },
    calenderIcon() {
      return mdiCalendarMonth;
    },
    filteredIteams() {
      return this.tickets.filter((s) =>
        s.name.toLowerCase().includes(this.query.toLowerCase())
      );
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

<template>
  <div>
    <v-card max-width="1200" min-height="860" class="mx-auto eventsContainer">
      <div class="basePageHeaderText">All Events</div>
        <div class="d-flex">
          <div class="ml-3 mr-auto p-2 d-flex">
            <v-text-field
              class="ml-1"
              label="Find Event"
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
        v-if="events && events.length === 0"
      >
        <v-progress-circular
          class="eventListSpinner"
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
          <v-col v-for="event in filteredIteams" :key="event.id" :cols="6">
            <v-card @click="onEventClick(event)">
              <v-img
                src="https://picsum.photos/1920/1080?random"
                class="white--text align-end"
                gradient="to bottom, rgba(0,0,0,.1), rgba(0,0,0,.5)"
                height="200px"
              >
                <v-card-title v-text="event.name"></v-card-title>
              </v-img>

              <v-card-actions>
                <v-icon>{{ icons.mdiCalendarMonth }}</v-icon>
                <span class="ml-2 mr-3">{{ event.eventDate}}</span>
                <v-spacer></v-spacer>
              </v-card-actions>
            </v-card>
          </v-col>
        </v-row>
      </v-container>
      <EventDetails ref="EventDetails" @buyTicket="onBuyTicketOnEvent" />
    </v-card>
  </div>
</template>

<script>
import { mapActions, mapGetters } from "vuex";
import { mdiCloseCircleOutline, mdiCalendarMonth, mdiAccount } from "@mdi/js";
import EventDetails from "./components/eventDetails/index.vue";
import AddTicketModel from "../../models/AddTicketModel";

export default {
  components: {
    EventDetails,
  },
  data: () => ({
    events: [],
    selectedEvent: null,
    icons: {
      mdiCloseCircleOutline,
      mdiCalendarMonth,
      mdiAccount,
    },
    query: "",
  }),
  async mounted() {
    await this.refreshPageData();
  },
  methods: {
    ...mapActions("eventList", ["getEventList", "deleteEvent"]),
    ...mapActions("ticketList", ["buyTicketOnEvent"]),
    async onBuyTicketOnEvent(selectedEvent) {
      const ticket = new AddTicketModel(
        selectedEvent.name,
        selectedEvent.category,
        3,
        selectedEvent.id
      );
      await this.buyTicketOnEvent(ticket);
      await this.refreshPageData();
    },
    onEventClick(event) {
      this.selectedEvent = event;
      this.$refs.EventDetails.open(event);
    },
    async refreshPageData() {
      await this.getEventList();
      this.events = this.eventList;
    },
  },
  computed: {
    ...mapGetters("eventList", ["eventList"]),
    filteredIteams() {
      return this.events.filter((s) =>
        s.name.toLowerCase().includes(this.query.toLowerCase())
      );
    },
  },
  watch: {
    searchValue: function () {
      this.changePaginationList();
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
.basePageHeaderText {
  font-size: 32px;
  font-weight: 900;
  font-size: 32px;
  padding-bottom: 8px;
  text-align: center;
  padding-top: 10px;
}
</style>

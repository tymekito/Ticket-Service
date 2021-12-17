<template>
<div>
  <v-card max-width="1200" min-height="860" class="mx-auto eventsContainer">
    <div>Moje wydarzenia</div>
    <v-container class="spinnerConteiner" v-if="events.length === 0">
      <v-progress-circular
        class="eventListSpinner"
        :width="5"
        :size="80"
        indeterminate
        color="green"
      ></v-progress-circular>
    </v-container>
    <v-container fluid v-else>
      <v-row dense>
        <v-col v-for="event in events" :key="event.id" :cols="6">
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
              <span class="ml-2 mr-3">{{ "03/12/2021" }}</span>
              <v-icon>{{ icons.mdiAccount }}</v-icon>
              <span class="ml-2 mr-2">{{ event.tickets.length}} / 10</span>
              <v-spacer></v-spacer>
            </v-card-actions>
          </v-card>
        </v-col>
      </v-row>
    </v-container>
    <EventDetails 
    ref="EventDetails"
    @deleted ="onDeleteEvent"
    />
  </v-card>
  </div>
</template>

<script>
import { mapActions, mapGetters } from "vuex";
import { mdiCloseCircleOutline , mdiCalendarMonth, mdiAccount } from "@mdi/js";
import EventDetails from "./components/eventDetails/index.vue";

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
        mdiAccount
    }
  }),
  async mounted() {
    await this.refreshPageData();
  },
  methods: {
    ...mapActions("eventList", ["getEventList", "deleteEvent"]),
    async onDeleteEvent(){
      await this.deleteEvent(this.selectedEvent.id)
      await this.refreshPageData();
    },
    onEventClick(event){
      this.selectedEvent = event;
      this.$refs.EventDetails.open(event)
    },
    async refreshPageData(){
      await this.getEventList();
      this.events = this.eventList;
    }

  },
  computed: {
    ...mapGetters("eventList", ["eventList"]),

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

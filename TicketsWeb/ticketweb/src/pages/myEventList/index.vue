<template>
  <div>
    <v-alert :value="alert" type="success" @click="alert = false"
      >Added event
    </v-alert>
    <v-alert :value="alertDelete" type="success" @click="alertDelete = false"
      >Deleted event
    </v-alert>
    <v-card max-width="1200" min-height="860" class="mx-auto">
      <div class="basePageHeaderText">My Events</div>
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
        <div class="p-2">
          <v-btn class="button-base addEventButton" @click="onAddEvent()"
            >Add Event</v-btn
          >
        </div>
      </div>
      <v-container class="spinnerConteiner" v-if="events === null">
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
                <span class="ml-2 mr-3">{{ event.eventDate }}</span>
                <v-icon>{{ icons.mdiAccount }}</v-icon>
                <span class="ml-2 mr-2"
                  >{{ event.tickets !== null ? event.tickets.length : 0 }}
                </span>
                <v-spacer></v-spacer>
              </v-card-actions>
            </v-card>
          </v-col>
        </v-row>
      </v-container>
      <EventDetails ref="EventDetails" @deleted="onDeleteEvent" />
      <AddEventDialog ref="AddEventDialog" @added="eventAdded" />
    </v-card>
  </div>
</template>

<script>
import { mapActions, mapGetters } from "vuex";
import { mdiCloseCircleOutline, mdiCalendarMonth, mdiAccount } from "@mdi/js";
import EventDetails from "./components/eventDetails/index.vue";
import AddEventDialog from "./components/addEventDialogWindow/index.vue";

export default {
  components: {
    EventDetails,
    AddEventDialog,
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
    alert: false,
    alertDelete: false,
  }),
  async mounted() {
    await this.refreshPageData();
  },
  methods: {
    ...mapActions("myEventList", ["getMyEventList", "deleteMyEvent"]),
    async onDeleteEvent() {
      await Promise.all([
        this.deleteMyEvent(this.selectedEvent.id),
        this.refreshPageData(),
      ]);
      this.alertDelete = true;
    },
    onEventClick(event) {
      this.selectedEvent = event;
      this.$refs.EventDetails.open(event);
    },
    async onAddEvent() {
      this.$refs.AddEventDialog.open();
    },
    async eventAdded() {
      await this.refreshPageData();
      this.alert = true;
    },
    async refreshPageData() {
      await this.getMyEventList(this.userDetails.userId);
      this.events = this.myEventList;
      this.alert = false;
      this.alertDelete = false;
    },
  },
  computed: {
    ...mapGetters("myEventList", ["myEventList"]),
    ...mapGetters("login", ["userDetails"]),
    filteredIteams() {
      return this.events.filter((s) =>
        s.name.toLowerCase().includes(this.query.toLowerCase())
      );
    },
  },
};
</script>
<style lang="scss" scoped>
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
.searchInput {
  justify-content: center;
  max-width: 400px;
}
.addEventButton {
  text-align: end;
}
.eventMenagerWrapper {
  width: 100%;
}
.noResultText {
  color: rgb(202, 65, 65);
}
</style>

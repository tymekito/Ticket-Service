<template>
  <v-dialog
    v-model="dialog"
    transition="dialog-bottom-transition"
    width="583"
    height="170"
  >
    <v-card>
      <v-card-title
        class="lighten-2 dialogWindow--header d-flex justify-space-between pt-3 pb-1 pb-6 pr-2"
        dark
      >
        <span class="headerText"> {{ selectedEvent.name }}</span>
        <v-icon class="ml-15" @click="onDialogCancel()">{{
          icons.mdiCloseCircleOutline
        }}</v-icon>
      </v-card-title>
      <v-card-text>
        <div class="dialogWindow--content pt-3">
          <div><b>Event Name:</b> {{ selectedEvent.name }}</div>
          <div><b>Event Category:</b> {{selectedEvent.Category}}</div>
          <div><b>Event realase date:</b> {{selectedEvent.eventDate}}</div>
          <div>
            <b>Number of participants:</b>  {{selectedEvent && selectedEvent.tickets ? selectedEvent.tickets.length : 0}}
          </div>
          <div>
            <b>Event description:</b>  {{selectedEvent.description}}
          </div>
        </div>
      </v-card-text>
      <v-card-actions class="d-flex justify-content-end dialogWindow--footer">
        <v-btn class="button-base button-remove" @click="onEventReturn()"
          >Dismiss event</v-btn
        >
      </v-card-actions>
    </v-card>
  </v-dialog>
</template>
<script>
import { mdiDelete,mdiCloseCircleOutline  } from "@mdi/js";
import EventModel from "../../../../models/EventModel";
export default {
  name: "EventDetails",
  data: () => ({
    dialog: false,
    headerText: 'null',
    eventText: null,
    selectedEvent: 'null',
    icons: {
      mdiDelete,
      mdiCloseCircleOutline
    },
  }),
  methods: {
    onEventReturn() {
      this.$emit("deleted");
      this.dialog = false;
    },
    onDialogCancel() {
      this.dialog = false;
    },
    open(item) {
      this.selectedEvent = new EventModel(item);
      this.dialog = true;
    },
  },
};
</script>

<style lang="scss" scoped>
.dialogWindow {
  &--header {
    max-height: 48px;
    text-align: center;
    background: #19cebf;
    .headerText {
      font-style: normal;
      font-weight: 600;
      font-size: 15px;
      line-height: 22px;
    }
    .headerIcon {
      min-width: 14px;
      padding: 0px, 8px, 0px, 8px;
    }
  }
  &--content {
    font-size: 18px;
    text-transform: none;
    letter-spacing: -0.015em;
  }
  &--footer {
    margin-left: 36%;
  }
}
</style>

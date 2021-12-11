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
        <span class="headerText"> {{ headerText }}</span>
        <v-icon class="ml-15" @click="onDialogCancel()">{{
          calenderIcon
        }}</v-icon>
      </v-card-title>
      <v-card-text>
        <div class="dialogWindow--content pt-3">
          <div><b>Event Name:</b> {{ ticketText }}</div>
          <div><b>Ticket Category:</b> Rozrywka</div>
          <div><b>Ticket realase date:</b> 01.01.2021</div>
          <div>
            <b>Ticket descripe:</b> Lorem Ipsum is simply dummy text of the
            printing and typesetting industry. Lorem Ipsum has been the
            industry's standard dummy text ever since the 1500s, when an unknown
            printer took a galley of type and scrambled it to make a type
            specimen book. It has
          </div>
        </div>
      </v-card-text>
      <v-card-actions class="d-flex justify-content-end dialogWindow--footer">
        <v-btn class="button-base button-remove" @click="onTicketReturn()"
          >Return Ticket</v-btn
        >
      </v-card-actions>
    </v-card>
  </v-dialog>
</template>
<script>
import { mdiDelete } from "@mdi/js";
export default {
  name: "EventDetails",
  data: () => ({
    dialog: false,
    headerText: null,
    ticketText: null,
  }),
  methods: {
    onTicketReturn() {
      this.$emit("deleted");
      this.dialog = false;
    },
    onDialogCancel() {
      this.dialog = false;
    },
    open(item) {
      this.headerText = item.name;
      this.ticketText = item.name;
      this.dialog = true;
    },
  },
  computed: {
    calenderIcon() {
      return mdiDelete;
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

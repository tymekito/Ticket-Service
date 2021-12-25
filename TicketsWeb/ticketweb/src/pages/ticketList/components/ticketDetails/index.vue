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
        <span class="headerText"> {{}}</span>
        <v-icon class="ml-15" @click="onDialogCancel()">{{
          icons.mdiCloseCircleOutline
        }}</v-icon>
      </v-card-title>
      <v-card-text>
        <div class="dialogWindow--content pt-3">
          <div><b>Event Name:</b> {{ ticketName }}</div>
          <div><b>Ticket Category:</b> {{ ticketCategory }}</div>
          <div><b>Ticket realase date:</b> {{ ticketDate }}</div>
          <div><b>Price: </b>{{ ticketPrice }} $</div>
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
import { mdiCloseCircleOutline } from "@mdi/js";
export default {
  name: "TicketDetails",
  data: () => ({
    dialog: false,
    ticketName: null,
    ticketCategory: null,
    ticketText: null,
    ticketPrice: null,
    ticketDate: null,

    icons: {
      mdiCloseCircleOutline,
    },
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
      console.log(item);
      this.ticketName = item.name;
      this.ticketCategory = item.category;
      this.ticketPrice = item.price;
      this.ticketDate = item.expirationDate;
      this.dialog = true;
    },
  },
  computed: {},
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

<template>
  <v-container fluid v-if="paginationEventList !== null">
    <v-row dense>
      <v-col v-for="event in paginationEventList" :key="event.id" :cols="3">
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
            <span class="ml-2 mr-3">Miejsce - {{ "03.12.2021" }}</span>

            <v-spacer></v-spacer>
          </v-card-actions>
        </v-card>
      </v-col>
    </v-row>
    <v-pagination
      v-if="paginationEventList !== null"
      v-model="pageNumber"
      :length="paginationLimit"
    ></v-pagination>
  </v-container>
</template>

<script>
import { mdiCalendarMonth } from "@mdi/js";
export default {
  name: "PaginationEventList",
  data: () => ({
    pageNumber: 1,
    paginationNumber: 4,
    paginationEventList: null,
    paginationLimit: 0,
    icons: {
      mdiCalendarMonth,
    },
  }),
  props: {
    events: [],
  },
  mounted() {
    this.refreshPageData();
  },
  methods: {
    refreshPageData() {
      if (this.events !== 0) {
        this.paginationLimit = this.events.length / 4;
        if (this.paginationLimit > this.paginationLimit.toPrecision(1)) {
          this.paginationLimit = this.paginationLimit.toPrecision(1);
          this.paginationLimit++;
        }
        this.paginationEventList = this.events.slice(0, this.paginationNumber);
      }
    },
    changePaginationList() {
      const min = this.paginationNumber * (this.pageNumber - 1);
      const max = this.paginationNumber * this.pageNumber;
      this.paginationEventList = this.events.slice(min, max);
    },
  },
    watch: {
    pageNumber: function () {
      this.changePaginationList();
    },
  },
};
</script>

<style></style>

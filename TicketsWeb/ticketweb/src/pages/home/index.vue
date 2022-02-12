<template>
  <div>
    <div class="white--text align-end">
      <v-img
        src="https://picsum.photos/1920/1080?random"
        class="white--text align-end"
        gradient="to bottom, rgba(0,0,0,.1), rgba(0,0,0,.5)"
        height="300px"
      >
        <div class="mainEvent ma-12">
          <div class="mainEvent--header">Books of the Year 2021</div>
          <div class="mainEvent--text">
            read the summary text of this year's edition of the plebiscite!
          </div>
          <v-btn class="mt-3" color="success"> Discover </v-btn>
        </div>
      </v-img>
    </div>
    <div class="popularEvents pt-8">Popular Books</div>
    <v-divider inset></v-divider>
  </div>
</template>

<script>
import { mdiCloseCircleOutline, mdiCalendarMonth, mdiAccount } from "@mdi/js";
export default {
  data: () => ({
    events: [],
    selectedEvent: null,
    pageNumber: 1,
    paginationNumber: 4,
    paginationEventList: null,
    paginationLimit: 0,
    icons: {
      mdiCloseCircleOutline,
      mdiCalendarMonth,
      mdiAccount,
    },
  }),
  async mounted() {
    await this.refreshPageData();
  },
  methods: {
    async refreshPageData() {
    },
  },
  computed: {
  },
};
</script>

<style lang="scss" scoped>
.homePage {
}
.mainEvent {
  max-width: 500px;
  &--header {
    font-size: 32px;
    font-weight: 900;
    font-size: 32px;
    padding-bottom: 8px;
  }
  &--text {
    font-weight: 600;
    font-size: 16px;
  }
}
.popularEvents {
  text-align: center;
  font-size: 23px;
  position: relative;
  margin: 0px;
  padding-bottom: 4px;
  font-weight: 900;
  text-transform: uppercase;
}
.popularEvents::before {
  text-align: center;
  position: absolute;
  bottom: 0px;
  right: 49%;
  display: block;
  width: 40px;
  border-bottom: 4px solid rgb(197, 107, 255);
  content: "";
}
.v-application--is-ltr .v-divider--inset:not(.v-divider--vertical) {
  margin-right: 72px;
}
</style>

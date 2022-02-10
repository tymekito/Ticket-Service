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
          <div class="mainEvent--header">Event of the Year</div>
          <div class="mainEvent--text">
            Znakomity kwartet smyczkowy z jedynym koncertem w Polsce! Kronos
            Quartet słynie z wirtuozerii, wszechstronności i kreatywnego
            podejścia do tradycji muzycznej globu.
          </div>
          <v-btn class="mt-3" color="success"> Custom Loader </v-btn>
        </div>
      </v-img>
    </div>
    <div class="popularEvents pt-8">Polularne wydarzenia</div>
    <v-divider inset></v-divider>
    <div>
      <div class="popularEvents pt-8">Odkrywaj</div>
    </div>
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

<template>
  <v-dialog
    v-model="dialog"
    transition="dialog-bottom-transition"
    width="800"
    height="300"
    persistent
  >
    <v-card class="pa-6">
      <v-container class="spinnerConteiner" v-if="sendForm">
        <v-progress-circular
          class="eventListSpinner"
          :width="5"
          :size="80"
          indeterminate
          color="green"
        ></v-progress-circular>
      </v-container>
      <v-form ref="form" v-else v-model="valid" lazy-validation>
        <v-text-field
          v-model="name"
          :counter="10"
          :rules="nameRules"
          label="Name"
          required
        ></v-text-field>

        <v-text-field
          v-model="description"
          :rules="descriptionRules"
          label="Description"
        ></v-text-field>

        <v-select
          v-model="selectedCategory"
          :items="categories"
          :rules="[(v) => !!v || 'Event Category is required']"
          label="Category"
          required
        ></v-select>

        <v-btn
          :disabled="!valid"
          color="success"
          class="mr-4"
          @click="addEvent"
        >
          Create
        </v-btn>
        <v-btn color="warning" class="mr-4" @click="resetValidation">
          Reset Form
        </v-btn>
        <v-btn color="error" @click="reset"> Cancel </v-btn>
      </v-form>
    </v-card>
  </v-dialog>
</template>
<script>
import EventCategories from "../../../../shared/constants";
import { mapActions } from "vuex";
import AddEventModel from "../../../../models/AddEventModel";
export default {
  name: "AddEventDialog",
  data: () => ({
    sendForm: false,
    valid: true,
    name: "",
    dialog: false,
    nameRules: [
      (v) => !!v || "Name is required",
      (v) => (v && v.length <= 50) || "Name must be less than 50 characters",
    ],
    description: "",
    descriptionRules: [
      (v) => (v && v.length <= 500) || "Name must be less than 500 characters",
    ],
    selectedCategory: null,
    categories: null,
    checkbox: false,
  }),

  methods: {
    ...mapActions("myEventList", ["addMyEvent"]),
    async addEvent() {
      if (this.$refs.form.validate()) {
        this.sendForm = true;
        const newEvent = new AddEventModel(
          this.name,
          this.description,
          this.selectedCategory,
          3
        );
        await this.addMyEvent(newEvent).then(
        this.$refs.form.reset(),
        this.$emit("added"),
        this.dialog = false,
        );
      }
    },

    reset() {
      this.$refs.form.reset();
      this.dialog = false;
    },
    resetValidation() {
      this.$refs.form.reset();
    },
    open() {
      this.prepareForm();
    },
    prepareForm() {
      this.sendForm = false;
      this.categories = EventCategories;
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

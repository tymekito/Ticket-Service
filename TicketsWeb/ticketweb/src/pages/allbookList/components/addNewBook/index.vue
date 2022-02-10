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
          class="bookListSpinner"
          :width="5"
          :size="80"
          indeterminate
          color="green"
        ></v-progress-circular>
      </v-container>
      <v-form ref="form" v-else v-model="valid" lazy-validation>
        <v-text-field
          v-model="name"
          :counter="50"
          :rules="nameRules"
          label="Name"
          required
        ></v-text-field>
        <v-select
          v-model="selectedCategory"
          :items="categories"
          :rules="[(v) => !!v || 'Book Category is required']"
          label="Category"
          required
        ></v-select>
        <v-text-field
          v-model="date"
          label="The day of the Book"
          readonly
          center
          @click="openDatePicker"
        ></v-text-field>
        <v-row v-if="showDatePicker" justify="center">
          <v-date-picker v-model="date" no-title scrollable>
            <v-btn text color="primary" @click="closeDataPicker">
              Cancel
            </v-btn>
            <v-btn text color="primary" @click="selectDate"> OK </v-btn>
          </v-date-picker>
        </v-row>
        <v-row v-else>
          <v-btn
            :disabled="!valid"
            color="success"
            class="mr-4"
            @click="addBook"
          >
            Create
          </v-btn>
          <v-btn color="warning" class="mr-4" @click="resetValidation">
            Reset Form
          </v-btn>
          <v-btn color="error" @click="reset"> Cancel </v-btn>
        </v-row>
      </v-form>
    </v-card>
  </v-dialog>
</template>
<script>
import BookCategories from "../../../../shared/constants";
import { mapActions, mapGetters } from "vuex";
import AddBookModel from "../../../../models/AddBookModel";
export default {
  name: "AddBookDialog",
  data: () => ({
    sendForm: false,
    valid: true,
    name: "",
    dialog: false,
    date: new Date(Date.now() - new Date().getTimezoneOffset() * 60000)
      .toISOString()
      .substr(0, 10),
    nameRules: [
      (v) => !!v || "Name is required",
      (v) => (v && v.length <= 50) || "Name must be less than 50 characters",
    ],
    selectedCategory: null,
    categories: null,
    checkbox: false,
    showDatePicker: false,
  }),

  methods: {
    ...mapActions("bookList", ["addMyBook"]),
    async addBook() {
      if (this.$refs.form.validate()) {
        this.sendForm = true;

        const newBook = new AddBookModel(
          this.name,
          this.selectedCategory,
          this.userDetails.userId,
          this.date,
        );
        await this.addMyBook(newBook).then(
          this.$refs.form.reset(),
          this.$emit("added"),
          (this.dialog = false)
        );
      }
    },
    closeDataPicker() {
      (this.date = new Date(Date.now() - new Date().getTimezoneOffset() * 60000)
        .toISOString()
        .substr(0, 10)),
        (this.showDatePicker = false);
    },
    selectDate() {
      this.showDatePicker = false;
    },
    openDatePicker() {
      this.showDatePicker = true;
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
      this.categories = BookCategories;
      this.dialog = true;
    },
  },
  computed: {
    ...mapGetters("login", ["userDetails"]),
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

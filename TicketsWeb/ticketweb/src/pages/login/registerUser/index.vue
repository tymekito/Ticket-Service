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
          v-model="login"
          :counter="20"
          :rules="nameRules"
          label="Login"
          required
        ></v-text-field>
        <v-text-field
          v-model="password"
          :counter="20"
          :rules="nameRules"
          label="Password"
          required
        ></v-text-field>        <v-text-field
          v-model="repeatPassword"
          :counter="20"
          :rules="nameRules"
          label="Repeat Password"
          required
        ></v-text-field>
        <v-text-field
          v-model="name"
          :counter="20"
          :rules="nameRules"
          label="Name"
          required
        ></v-text-field>
        <v-text-field
          v-model="lastName"
          :counter="20"
          :rules="nameRules"
          label="Last Name"
          required
        ></v-text-field>
        <v-text-field
          v-model="email"
          :counter="20"
          :rules="nameRules"
          label="E-mail"
          required
        ></v-text-field>
        <v-btn
          :disabled="!valid"
          color="success"
          class="mr-4"
          @click="onRegisterUser"
        >
          Create Account
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
import { mapActions } from "vuex";
export default {
  name: "RegisterUserDialog",
  data: () => ({
    sendForm: false,
    valid: true,
    login: "",
    password: "",
    repeatPassword: "",
    name: "",
    lastName: "",
    email: "",
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
    ...mapActions("login", ["registerUser"]),
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
      this.dialog = true;
    },
    async onRegisterUser() {
      if (this.$refs.form.validate()) {
        const userInfo = {
          login: this.name,
          password: this.password,
          name: this.name,
          lastName: this.lastName,
          email: this.email,
        };
        this.sendForm = true;
        await this.registerUser(userInfo).then(
        this.$refs.form.reset(),
        this.$emit("added"),
        this.dialog = false,
        );
      }
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

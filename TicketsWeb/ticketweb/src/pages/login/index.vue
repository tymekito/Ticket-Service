<template>
  <v-main>
    <v-card class="mx-auto my-15 login-layout" max-width="500" height="75%">
      <div class="basePageHeaderText pt-5">Log in</div>
      <form class="login-form ma-2">
        <v-text-field
          v-model="name"
          class="mr-5 ml-5"
          label="Name"
          type="login"
          outlined
          required
          color="green"
        ></v-text-field>
        <v-text-field
          v-model="password"
          class="mr-5 ml-5"
          label="Password"
          type="password"
          outlined
          @keyup.enter="onLoginClick"
          required
        ></v-text-field>
        <v-row>
          <v-col v-if="!logging" class="login-btn mb-5">
            <v-btn
              class="mr-5 base-button"
              color="green"
              elevation="2"
              text
              @click="onLoginClick"
            >
              Login
            </v-btn>
            <v-btn
              class="ml-5 base-button"
              color="blue"
              elevation="2"
              text
              @click="onRegisterClick"
              >Register
            </v-btn>
          </v-col>
          <v-col v-else>
            <v-container class="spinnerConteiner">
              <v-progress-circular
                class="eventListSpinner"
                :width="5"
                :size="80"
                indeterminate
                color="green"
              ></v-progress-circular>
            </v-container>
          </v-col>
        </v-row>
      </form>
      <RegisterUserDialog ref="RegisterUserDialog" @added="reloadPage" />
    </v-card>
  </v-main>
</template>

<script>
import { mapActions } from "vuex";
import router from "../../router";
import RegisterUserDialog from "./registerUser/index.vue";
export default {
  components: {
    RegisterUserDialog,
  },
  data: () => ({
    name: "",
    password: "",
    logging: false,
  }),
  methods: {
    ...mapActions("login", ["logInUser"]),
    async onLoginClick() {
      const userInfo = {
        login: this.name,
        password: this.password,
      };
      this.logging = true;
      const response = await this.logInUser(userInfo);
      this.logging = false;
      if (response !== null) {
        router.push("/");
      }
    },
    reloadPage() {
    },
    onRegisterClick() {
      this.$refs.RegisterUserDialog.open();
    },
  },
};
</script>

<style>
.login-layout {
}
.login-form {
  padding-top: 10px;
}
.login-btn {
  margin-left: 30%;
}
</style>

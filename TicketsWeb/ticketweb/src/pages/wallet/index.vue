<template>
  <v-main>
    <v-card class="mx-auto my-15" max-width="650px">
      <v-alert
        :value="paymentSuccess"
        type="success"
        @click="paymentSuccess = false"
        >Added moneys to your wallet</v-alert
      >
      <div class="ma-4">
        <v-card-title>Confirm Your Payment</v-card-title>
        <div class="bottom-conteiner">
          <v-row>
            <v-col>
              <div class="mb-2">Owner</div>
            </v-col>
            <v-col>
              <div class="mb-2">CVV</div>
            </v-col>
          </v-row>
        </div>
        <div class="bottom-conteiner">
          <v-text-field
            class="ml-1"
            label="Name on Card"
            clearable
            dense
            outlined
          ></v-text-field>
          <v-text-field
            class="ml-1"
            label="CVV Code"
            clearable
            dense
            outlined
          ></v-text-field>
        </div>
        <div class="mb-2">Card Number</div>
        <v-text-field
          class="ml-1"
          label="Number"
          clearable
          dense
          outlined
        ></v-text-field>
        <div class="mb-2">Card Number</div>
        <div class="bottom-conteiner pb-10">
          <v-row>
            <v-col class="select-conteiner" cols="3">
              <v-select :items="months" label="Month" outlined></v-select>
            </v-col>
            <v-col class="select-conteiner" cols="3">
              <v-select :items="years" label="Year" outlined></v-select>
            </v-col>
            <v-col class="image-conteiner" cols="6">
              <v-img
                src="../../assets/mc.png"
                class="mr-1"
                max-width="77px"
                max-height="50px"
              >
              </v-img>
              <v-img
                src="../../assets/vi.png"
                class="mr-1"
                max-width="77px"
                max-height="50px"
              >
              </v-img>
              <v-img
                src="../../assets/pp.png"
                class="mr-1"
                max-width="77px"
                max-height="50px"
              >
              </v-img>
            </v-col>
          </v-row>
        </div>
        <v-row>
          <v-col>
            <v-text-field
              class="ml-1 mr"
              label="Amount"
              clearable
              dense
              outlined
              v-model="amount"
            ></v-text-field>
          </v-col>
          <v-col>
            <v-btn class="button-base addEventButton" @click="onPaymentSubmit()"
              >Submit</v-btn
            >
          </v-col>
        </v-row>
      </div>
    </v-card>
  </v-main>
</template>

<script>
import { mapActions, mapGetters } from "vuex";
import Months from "../../shared/months";
import Years from "../../shared/years";
export default {
  data: () => ({
    months: Months,
    years: Years,
    amount: 0,
    paymentSuccess: false,
  }),
  methods: {
    ...mapActions("wallet", ["addMoneyToUserWallet"]),
    ...mapActions("login", ["refreshUserData"]),
    async onPaymentSubmit() {
      if (this.isLoggedIn) {
        const payment = {
          userId: this.userDetails.userId,
          amount: this.amount,
        };
        await this.addMoneyToUserWallet(payment);
        await this.refreshUserData(this.userDetails.userId);
        this.paymentSuccess = true;
      }
    },
  },
  computed: {
    ...mapGetters("login", ["isLoggedIn", "userDetails"]),
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
.bottom-conteiner {
  display: flex;
}
.image-conteiner {
  display: flex;
}
.select-conteiner {
  height: 20px !important;
}
</style>

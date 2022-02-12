<template>
  <div>
    <v-alert :value="alert" type="success" @click="alert = false"
      >Added book</v-alert
    >
    <v-card max-width="1200" min-height="860" class="mx-auto booksContainer">
      <div class="basePageHeaderText">Library</div>

      <div class="d-flex">
        <div class="ml-3 mr-5 p-2">
          <v-text-field
            class="ml-1"
            label="Find Book"
            clearable
            dense
            outlined
            prepend-inner-icon="search"
            v-model="query"
          ></v-text-field>
        </div>
        <div>
          <v-btn class="button-base addBookButton" @click="onAddBook()"
            >Add Book</v-btn
          >
        </div>
      </div>
      <v-container class="spinnerConteiner" v-if="books && books.length === 0">
        <v-progress-circular
          class="bookListSpinner"
          :width="5"
          :size="80"
          indeterminate
          color="green"
        ></v-progress-circular>
      </v-container>
      <v-container fluid v-else>
        <div
          v-if="filteredIteams && filteredIteams.length === 0"
          class="basePageHeaderText noResultText"
        >
          Brak wyników
        </div>
        <v-row dense>
          <v-col v-for="book in filteredIteams" :key="book.id" :cols="6">
            <v-card @click="onBookClick(book)">
              <v-img
                src="https://picsum.photos/1920/1080?random"
                class="white--text align-end"
                gradient="to bottom, rgba(0,0,0,.1), rgba(0,0,0,.5)"
                height="200px"
              >
                <v-card-title v-text="book.name"></v-card-title>
              </v-img>

              <v-card-actions>
                <v-icon>{{ calenderIcon }}</v-icon>
                <b class="ml-1 mr-1"  >Date of borrow</b>
                <span>{{ book.expirationDate ? book.expirationDate : "" }}</span>
                <v-spacer></v-spacer>
              </v-card-actions>
            </v-card>
          </v-col>
        </v-row>
      </v-container>
      <BookDetails ref="BookDetails" @borrowed="onBorrowBook" />
      <AddBookDialog ref="AddBookDialog" @added="bookAdded" />
    </v-card>
  </div>
</template>

<script>
import { mapActions, mapGetters } from "vuex";
import { mdiCloseCircleOutline, mdiCalendarMonth } from "@mdi/js";
import BookDetails from "./components/bookDetails/index.vue";
import AddBookDialog from "./components/addNewBook/index.vue";
export default {
  components: {
    BookDetails,
    AddBookDialog
  },
  data: () => ({
    books: [],
    selectedBook: null,
    query: "",
    alert: false,
  }),
  async mounted() {
    await this.refreshPageData();
  },
  methods: {
    ...mapActions("allbookList", ["getBookList", "borrowBook"]),
    ...mapActions("login", ["refreshUserData"]),

    async onBorrowBook() {
      await this.borrowBook({bookId: this.selectedBook.id,userId: this.userDetails.userId});
      await this.refreshUserData(this.userDetails.userId);
      await this.refreshPageData();
      this.alert = true;
    },
    onBookClick(book) {
      this.selectedBook = book;
      this.$refs.BookDetails.open(book);
    },
    async onAddBook() {
      this.$refs.AddBookDialog.open();
    },
    async bookAdded() {
      await this.refreshPageData();
      this.alert = true;
    },
    async refreshPageData() {
      await this.getBookList();
      this.books = this.bookList;
      console.log(this.books)
      this.alert = false;
    },
  },
  computed: {
    ...mapGetters("allbookList", ["bookList"]),
    ...mapGetters("login", ["userDetails"]),
    deleteIcon() {
      return mdiCloseCircleOutline;
    },
    calenderIcon() {
      return mdiCalendarMonth;
    },
    filteredIteams() {
      return this.books.filter((s) =>
        s.name.toLowerCase().includes(this.query.toLowerCase())
      );
    },
  },
};
</script>

<style>
.booksContainer {
  margin-top: 15px;
  margin-bottom: 15px;
}
.bookListSpinner {
  margin-top: 50%;
}
.spinnerConteiner {
  text-align: center;
  width: 50%;
  height: 100%;
}
.basePageHeaderText {
  font-size: 32px;
  font-weight: 900;
  font-size: 32px;
  padding-bottom: 8px;
  text-align: center;
}
</style>

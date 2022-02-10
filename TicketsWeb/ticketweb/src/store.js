import Vue from 'vue';
import Vuex from 'vuex';

import bookList from './pages/bookList/module';
import allbookList from './pages/allbookList/module';
import login from './pages/login/module';
Vue.use(Vuex);

export default new Vuex.Store({
    modules:{
        bookList,
        allbookList,
        login       
    }
})
import Vue from 'vue';
import Vuex from 'vuex';

import ticketList from './pages/ticketList/module';
import eventList from './pages/eventList/module';
import myEventList from './pages/myEventList/module';
import login from './pages/login/module';
import wallet from './pages/wallet/module';
Vue.use(Vuex);

export default new Vuex.Store({
    modules:{
        ticketList,
        eventList,
        myEventList,
        login,
        wallet
    }
})
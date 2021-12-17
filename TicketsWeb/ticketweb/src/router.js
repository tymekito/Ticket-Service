import Vue from 'vue';
import VueRouter from 'vue-router'
import ticketRoutes from './pages/ticketList/router'
import homeRoutes from './pages/home/router'
import eventsRoutes from './pages/eventList/router'
import myEventsRoutes from './pages/myEventList/router'

Vue.use(VueRouter);

const router = new VueRouter({
    routes:[
        ticketRoutes,
        homeRoutes,
        eventsRoutes,
        myEventsRoutes,
    ]
})

export default router;
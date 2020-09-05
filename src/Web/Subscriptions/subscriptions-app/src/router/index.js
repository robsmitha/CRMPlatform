
import Vue from 'vue';
import VueRouter from 'vue-router'
import Home from './../components/home/Home'
import OdicCallback from './../components/oidc/OidcCallback'
import Disclaimer from './../components/disclaimer/Disclaimer'
import Pricing from './../components/pricing/Pricing'
import goTo from 'vuetify/es5/services/goto'


Vue.use(VueRouter);

const routes = [
    { path: '/', component: Home },
    { path: '/oidc-callback', component: OdicCallback },
    { path: '/disclaimer', component: Disclaimer },
    { path: '/pricing', component: Pricing }
  ]
  
export default new VueRouter({
    routes,
    scrollBehavior: (to, from, savedPosition) => {
      let scrollTo = 0
  
      if (to.hash) {
        scrollTo = to.hash
      } else if (savedPosition) {
        scrollTo = savedPosition.y
      }
  
      return goTo(scrollTo)
    },
    mode: 'history'
})
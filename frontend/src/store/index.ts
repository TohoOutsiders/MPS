import Vue from 'vue'
import Vuex from 'vuex'
import modules from './modules'

const debug: boolean = process.env.NODE_ENV !== 'production'
if (debug) {
  console.log('%c█ store = ', 'background: rgba(0, 0, 255, 0.1);color: browm', modules)
}

Vue.use(Vuex)

let store = new Vuex.Store({
  modules
})

export default store

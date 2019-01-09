import Vue, { VNodeDirective } from 'vue'
import App from './App.vue'
import router from './route'
import store from './store'
import Axios from 'axios'

if (process.env.NODE_ENV === 'production') {
  console.log = () => {
    return false
  }
  Vue.config.productionTip = false
} else {
  Vue.config.devtools = true
}

/**
 * 自定义全局指令
 * */
// 自动聚焦focus
Vue.directive('focus', {
  inserted: (el: HTMLElement, binding: VNodeDirective) => {
    binding.value ? el.focus() : el.blur()
  }
})

Axios.interceptors.response.use(
  _response => {
    console.log('%c█ url    = ' + _response.config.url, 'background: rgba(0, 128, 0, 0.1); color: green')
    console.log('%c█ status = ' + _response.status, 'color: green')
    console.log('%c█ data   =', 'color: green', _response.data)

    if (_response.data.code != 200) {
      if (_response.data.hasOwnProperty('fields')) {
        for (const key in _response.data.fields) {
          if (_response.data.fields.hasOwnProperty(key)) {
            const element = _response.data.fields[key]
            return Promise.reject(key + element)
          }
        }
      } else {
        return Promise.reject(_response.data.message)
      }
    }
    return _response
  },
  _error => Promise.reject(_error)
)

new Vue({
  router,
  store,
  render: h => h(App)
}).$mount('#app')

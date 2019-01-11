const state = {
  value: 'is vuex!'
}

const mutations = {
  setValue(state: any, payload: any) {
    state.value = payload
  }
}

export default {
  namespaced: true,
  state,
  mutations
}

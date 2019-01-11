<template>
  <div class="home">
    <img alt="Vue logo" src="../assets/logo.png">
    <HelloWorld :msg="store_state_value"/>
  </div>
</template>

<script lang="ts">
import { Component, Vue } from 'vue-property-decorator'
import { State, Mutation, namespace } from 'vuex-class'
import HelloWorld from '@/components/HelloWorld.vue' // @ is an alias to /src

const HOME_STORE = namespace('home')

@Component({
  components: {
    HelloWorld
  }
})
export default class Home extends Vue {
  @HOME_STORE.State('value') private store_state_value!: string

  private created() {

  }
}
</script>

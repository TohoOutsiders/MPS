<template>
  <div class="hello">
    <h1>{{ msg }}</h1>
    <p>
      <a @click="clickMe($event)">Click Me!</a>
    </p>
    <h3>Installed CLI Plugins</h3>
  </div>
</template>

<script lang="ts">
import { Component, Prop, Vue } from 'vue-property-decorator'
import { Mutation, namespace } from 'vuex-class'

const HOME_STORE = namespace('home')

@Component
export default class HelloWorld extends Vue {
  @HOME_STORE.Mutation('setValue') private store_mu_setValue!: (value: string) => void

  @Prop() private msg!: string;

  private clickMe() {
    this.store_mu_setValue('is edit')
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped lang="stylus">
h3
  margin 40px 0 0

ul
  list-style-type none
  padding 0

li
  display inline-block
  margin 0 10px

a
  color #42b983
</style>

const files: __WebpackModuleApi.RequireContext = require.context('.', false, /\.ts$/)
let modules: any = {}

files.keys().forEach((key: string) => {
  if (key === './index.ts') return
  console.log(key)
  modules[key.replace(/(\.\/|\.ts)/g, '')] = files(key).default
})

export default modules

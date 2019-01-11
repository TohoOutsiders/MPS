const VUE_SERVE = require('./vue.serve')
const VUE_BUILD = require('./vue.build')

module.exports = {
  lintOnSave: true,
  css: {
    extract: false,
    sourceMap: process.env.NODE_ENV === 'production' ? false : true,
    loaderOptions: {}
  },
  devServer: {
    open: true,
    host: '0.0.0.0',
    port: 8899,
    https: false,
    hotOnly: false,
    proxy: null
  },
  productionSourceMap: process.env.NODE_ENV === 'production' ? false : true,
  chainWebpack: webpackConfig => {
    webpackConfig.module
      .rule('images')
      .test(/\.(png|jpe?g|gif|webp)(\?.*)?$/)
      .use('url-loader')
      .loader('url-loader')
      .options({
        limit: 10000,
        name: 'image/[name].[hash:8].[ext]'
      })
    webpackConfig.module
      .rule('js')
      .test(/\.js$/)
      .use('babel-loader')
      .loader('babel-loader')
    webpackConfig.module
      .rule('js')
      .test(/\.exec\.js$/)
      .use('script-loader')
      .loader('script-loader')
    webpackConfig.module
      .rule('svg')
      .test(/\.(svg)(\?.*)?$/)
      .use('file-loader')
      .loader('file-loader')
      .options({
        name: 'image/[name].[hash:8].[ext]'
      })
    process.env.NODE_ENV === 'production' ? VUE_BUILD(webpackConfig) : VUE_SERVE(webpackConfig)
  }
}

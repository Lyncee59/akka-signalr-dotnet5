const path = require('path');
const webpack = require('webpack');
const HtmlWebpackPlugin = require('html-webpack-plugin');

module.exports = {
  // bundling mode
  mode: 'production',

  // entry files
  entry: './src/index.tsx',

  // output bundles (location)
  output: {
    path: path.resolve(__dirname, 'dist'),
    filename: 'bundle.js',
  },

  // file resolutions
  resolve: {
    extensions: ['.ts', '.tsx', '.js'],
    alias: {
      components: path.resolve(__dirname, 'src/components'),
      config: path.resolve(__dirname, 'src/config'),
      layouts: path.resolve(__dirname, 'src/layouts'),
      modals: path.resolve(__dirname, 'src/modals'),
      providers: path.resolve(__dirname, 'src/providers'),
      scenes: path.resolve(__dirname, 'src/scenes'),
      services: path.resolve(__dirname, 'src/services'),

    },
  },

  // loaders
  module: {
    rules: [
      {
        test: /\.tsx?/,
        use: 'ts-loader',
        exclude: /node_modules/,
      },
    ],
  },

  plugins: [
    new HtmlWebpackPlugin({
      template: "src/index.html",
      hash: true, // This is useful for cache busting
      filename: 'index.html'
    }),
    new webpack.HotModuleReplacementPlugin()
  ],

  devServer: {
    open: true,
    contentBase: path.join(__dirname, 'dist'),
    publicPath: "http://website.behelit.com",
    disableHostCheck: true,   // That solved it
    compress: true,
    port: 9000,
    historyApiFallback: true,
    hot: true,
    inline: true,
    watchOptions:{
      poll: true,
      ignored: "/node_modules/"
    }
  },
};

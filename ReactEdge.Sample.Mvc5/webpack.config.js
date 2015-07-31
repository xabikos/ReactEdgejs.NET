var path = require('path');

module.exports = {
  context: path.join(__dirname, 'app'),
  entry: {
    server: './server'
    //client: './client'
  },
  output: {
    path: path.join(__dirname, 'app/generated'),
    filename: '[name].bundle.js'
  },
  module: {
    loaders: [
      // Transform JSX in .jsx files, ES6 code to ES5 using Babel
      { test: /\.jsx?$/, exclude: /(node_modules|bower_components)/, loader: 'babel-loader' }
    ],
  },
  resolve: {
    // Allow require('./blah') to require blah.jsx
    extensions: ['', '.js', '.jsx']
  }
};
require('expose?Index!./components/index');
require('expose?About!./components/about');
require('expose?Contact!./components/contact');
// Expose react in the global scope so Edge.js can access it to successfully render
require('expose?React!react');
require('expose?ReactRouter!react-router');
require('expose?Routes!./routes');
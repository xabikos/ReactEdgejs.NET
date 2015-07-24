return function (data, callback) {
  //callback(null, 'Node.js welcomes ' + data + ' ' + React);
  var result = React.renderToString(React.createElement(Components.TestComponent, data.dataProps));
    	
  callback(null, result);
}
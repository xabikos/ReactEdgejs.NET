var Location = require('react-router/lib/Location');
var Router = ReactRouter.Router;

return function (data, callback) {
  var result;
  var location = new Location(data.route.path, data.route.query);

  Router.run(Routes, location, function(error, initialState, transition) {
    result = React.renderToString(React.createElement(Router, React.__spread({},  initialState)));
  });
    	
  callback(null, result);
}
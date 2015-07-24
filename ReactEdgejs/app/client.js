import { Router } from 'react-router';
import BrowserHistory from 'react-router/lib/BrowserHistory';
import routes from './routes';
import { history } from 'react-router/lib/HashHistory';

React.render(<Router history={history} children={routes}/>, document.getElementById('app'));

//Router.run(routes, location, function(error, initialState, transition) {
//  React.render(<Router children={routes}/>, document.getElementById('app'));
//});
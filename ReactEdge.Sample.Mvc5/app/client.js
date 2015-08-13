import React from 'react';
import { Router } from 'react-router';
import routes from './routes';
import { history } from 'react-router/lib/HashHistory';

React.render((<Router history={history} children={routes}/>), document.getElementById('app'));
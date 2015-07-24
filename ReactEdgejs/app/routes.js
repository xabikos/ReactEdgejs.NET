import App from './components/app';
import About from './components/about';
import Inbox from './components/inbox';

const routes = {
  path: '/',
  component: App,
  childRoutes: [
    { path: 'about', component: About },
    { path: 'inbox', component: Inbox },
  ]
};

export default routes;
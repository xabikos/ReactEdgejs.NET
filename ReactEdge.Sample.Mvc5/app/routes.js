import Index from './components/index';
import About from './components/about';
import Contact from './components/contact';

const routes = {
  path: '/',
  component: Index,
  childRoutes: [
    { path: 'about', component: About },
    { path: 'contact', component: Contact },
  ]
};

export default routes;
import React from 'react';
import {Jumbotron, Button} from 'react-bootstrap';

class Index extends React.Component {S

  constructor(props) {
    super(props);
  }

  render(){
    return (
      <Jumbotron>
        <h1>ASP.NET</h1>
        <p class="lead">ASP.NET is a free web framework for building great Web sites and Web applications using HTML, CSS and JavaScript.</p>
        <p><Button href='http://asp.net' bsStyle='primary' bsSize='large'>Learn more &raquo;</Button></p>
      </Jumbotron>
    );
  }
}

export default Index;
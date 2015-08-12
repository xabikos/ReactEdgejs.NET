import React from 'react';
import {Jumbotron, Button, Row, Col} from 'react-bootstrap';

class Index extends React.Component {S

  constructor(props) {
    super(props);
  }

  render(){
    return (
      <div>
        <Jumbotron>
          <h1>ASP.NET</h1>
          <p class="lead">ASP.NET is a free web framework for building great Web sites and Web applications using HTML, CSS and JavaScript.</p>
          <p><Button href='http://asp.net' bsStyle='primary' bsSize='large'>Learn more &raquo;</Button></p>
        </Jumbotron>
        <Row>
          <Col md={4}>
            <h2>Getting started</h2>
            <p>ASP.NET MVC gives you a powerful, patterns-based way to build dynamic websites that enables a clean separation of concerns and gives you full control over markup for enjoyable, agile development.</p>
            <p><Button href='http://go.microsoft.com/fwlink/?LinkId=301865'>Learn more &raquo;</Button></p>
          </Col>
          <Col md={4}>
            <h2>Get more libraries</h2>
            <p>NuGet is a free Visual Studio extension that makes it easy to add, remove, and update libraries and tools in Visual Studio projects.</p>
            <p><Button href='http://go.microsoft.com/fwlink/?LinkId=301866'>Learn more &raquo;</Button></p>
          </Col>
          <Col md={4}>
            <h2>Web Hosting</h2>
            <p>You can easily find a web hosting company that offers the right mix of features and price for your applications.</p>
            <p><Button href='http://go.microsoft.com/fwlink/?LinkId=301867'>Learn more &raquo;</Button></p>
          </Col>
        </Row>
      </div>
    );
  }
}

export default Index;
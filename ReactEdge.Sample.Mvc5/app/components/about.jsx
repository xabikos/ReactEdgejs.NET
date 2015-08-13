import React from 'react';

class About extends React.Component {S

  constructor(props) {
    super(props);
  }

  render(){
    return (
      <div>
        <h3>{this.props.message}</h3>
        <p>Use this area to provide additional information.</p>
      </div>
    );
  }
}

export default About;
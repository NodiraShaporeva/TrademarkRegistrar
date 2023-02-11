import React, { Component } from 'react';

export class Register extends Component {
  static displayName = Register.name;

  constructor(props) {
    super(props);
    this.state = { };
    this.register = this.register.bind(this);
  }

  async register() {
      const element = document.getElementById("search");
      const response = await fetch('trademark?name=' + element.value);
      //const data = await response.json();
      const result = document.getElementById("result");
      result.innerText = response.ok ? "Trademark successfully registered" : "Trademark registration attempt failed";
  }

  render() {
    return (
      <div>
        <h1>Register</h1>

        <p>Enter a trademark you want to register and press button</p>

        <input type="text" id="search"/>

        <button className="btn btn-primary" onClick={this.register}>Register</button>
         <hr/> 
        <p id="result"></p>
      </div>
    );
  }
}

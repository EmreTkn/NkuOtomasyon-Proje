import './App.css';
import {
  BrowserRouter as Router,
  Switch,
  Route
} from "react-router-dom";
import Cover from './pages/Cover/Cover'
import LoginPage from './pages/LoginPage/Login'
import TeacherPage from './pages/TeacherPage/TeacherPage'
import StudentPage from './pages/StudentPage/StudentPage'
import AdminPage from './pages/AdminPage/AdminPage'
import Logout from './pages/Logout/Logout'


import React, { Component } from 'react'
export const STATE_LOGGED_IN = 'logged';
export const STATE_LOGGED_OUT = 'no-login';
export default class App extends Component {
  constructor(){
    super();

    this.state = {
      loggedIn: STATE_LOGGED_OUT,
      user:{},
    };
  }

  handleLogin = (data) => {
    this.setState({
      loggedIn: data.type,
      user: data.token, 
    });
  };

  handleLogout = () => {
    localStorage.removeItem("authToken")
    localStorage.removeItem("authRole")
    this.setState({
      loggedIn: STATE_LOGGED_OUT,
      user: {},
    });
  };

  isLoggedin = (data) => {
    const token = localStorage.getItem('authToken');
    const role = localStorage.getItem('authRole');
    if (this.state.loggedIn === STATE_LOGGED_OUT && token) {
      this.setState({
        loggedIn: role,
        user: token,
      });
    }
  };

  componentDidMount() {
    this.isLoggedin();
  }
  
  render() {
    return (
      <div className="App">
      <Router>
        <Switch>
          <Route path="/" exact><Cover></Cover></Route>
          <Route exact path="/logout" render={props => ( <Logout {... props} handleLogout={this.handleLogout}/>)} />
          <Route exact path="/login" render={props => ( <LoginPage {... props} handleLogin={this.handleLogin}  loggedIn={this.state.loggedIn}/>)} />
          <Route exact path="/student" render={props => (<StudentPage {... props} user={this.state.user} loggedIn={this.state.loggedIn}/>)} />
          <Route exact path="/teacher" render={props => (<TeacherPage {... props} user={this.state.user}  loggedIn={this.state.loggedIn}/>)} />
          <Route exact path="/admin" render={props => (<AdminPage {... props} user={this.state.user}  loggedIn={this.state.loggedIn}/>)} />

          
          <script src="https://unpkg.com/react/umd/react.production.min.js"></script>

          <script
            src="https://unpkg.com/react-dom/umd/react-dom.production.min.js"
            ></script>

          <script
            src="https://unpkg.com/react-bootstrap@next/dist/react-bootstrap.min.js"
          ></script>
       </Switch>
      </Router>
    </div>
    )
  }
}

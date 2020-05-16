import React, { Component } from 'react';
import './App.css';

import { withRouter } from 'react-router';

//Layouts
import LayoutRoute from './components/_layout/LayoutRoute';


import { Home } from './components/Home';
import { UserProvider } from './contexts/UserContext'
import { Authorize } from './components/Authorize';
import { SignOut } from './components/SignOut';

class App extends Component {

  componentWillMount() {
    this.unlisten = this.props.history.listen((location, action) => {
      window.scrollTo(0,0)
    });
  }
  componentWillUnmount() {
      this.unlisten();
  }
  render(){
    return (
      <UserProvider>
        <LayoutRoute exact path='/' component={Home} />
        <LayoutRoute exact path='/sign-out' component={SignOut} />
        <LayoutRoute exact path='/authorize' component={Authorize} />
      </UserProvider>
    )
  }
}
export default  withRouter(App)

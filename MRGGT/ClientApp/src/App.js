import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Customer } from './components/Customer';
import { AddCustomerA } from './components/AddCustomerA';

import './custom.css'

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Layout>
            <Route exact path='/' component={Customer} />
            <Route path='/customer' component={Customer} />
            <Route path='/addcustomera' component={AddCustomerA} />
      </Layout>
    );
  }
}

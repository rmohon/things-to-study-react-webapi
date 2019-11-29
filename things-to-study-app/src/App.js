import React from 'react';
import './App.css';
import {Home} from './components/Home';
import {Category} from './components/Category';
import {Technology} from './components/Technology';
import {Navigation} from './components/Navigation';
import {BrowserRouter, Route, Switch} from 'react-router-dom';

function App(){

  return(
    <BrowserRouter>
    <div className="container">
      <h3 className="m-3 d-flex justify-content-center">
        React App with Web API
      </h3>
      <h5 className="m-3 d-flex justify-content-center">
        Things To Study Index
      </h5>

      <Navigation/>

      <Switch>
        <Route path='/'component={Home} exact />
        <Route path='/category' component={Category}/>
        <Route path='/technology' component={Technology}/>
      </Switch>
    </div>
    </BrowserRouter>
  );
}

export default App;
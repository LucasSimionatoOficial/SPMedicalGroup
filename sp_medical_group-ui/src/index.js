import React from 'react';
import ReactDOM from 'react-dom';
import './index.css';
import reportWebVitals from './reportWebVitals';

import {Route, BrowserRouter as Router, Switch, Redirect} from 'react-router-dom'
import Login from "./pages/login/login.js"
import Paciente from "./pages/paciente/paciente.js"
import Medico from "./pages/medico/medico.js"
import Administrador from "./pages/administrador/administrador.js"

import {usuarioAutenticado, parseJwt, usuarioExpirado} from "./services/auth.js"

const Permissao = ({ component : Component  }) => {
  let a = "login"

  if (usuarioAutenticado()) {
    if (usuarioExpirado().getTime() <= new Date().getTime()) {
      localStorage.clear()
      a = "login"
    } else {
      switch (parseJwt().role)
      {
        case "1":
          a = "paciente"
          break
        case "2":
          a = "medico"
          break
        case "3":
          a = "administrador"
          break
        default:
          a = "login"
          break
      }
    }
  }
    return <Redirect to = {a} />
}

const routing = (
  <Router>
    <Switch>
      <Route exact path="/login" component={Login} />
      <Route exact path="/paciente" component={Paciente} />
      <Route exact path="/medico" component={Medico}/>
      <Route exact path="/administrador" component={Administrador} />
      <Permissao/>
    </Switch>
  </Router>
)

ReactDOM.render(
  routing,
  document.getElementById('root')
);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();

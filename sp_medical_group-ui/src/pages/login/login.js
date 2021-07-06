import React, {Component, Fragment} from "react"
import {Link} from "react-router-dom"
import axios from "axios"

import {usuarioAutenticado} from "../../services/auth.js"

export default class Login extends Component {
    constructor(props) {
        super(props)
        this.state = {
            email : "",
            senha : "",
            tipo : 0,
            erro : "",
            loading : false
        }

        if (usuarioAutenticado()) {
            this.props.history.push("/")
        }
    }
    
    login = (event) => {
        event.preventDefault()
        this.setState({ loading : true })
        axios.post("http://localhost:5000/api/login", {
            Email: this.state.email,
            Senha: this.state.senha
        })
        .then(response => {
            if (response.status === 200){
                localStorage.setItem("jwt_key", response.data.token)
                this.setState({ erro : ""})
                this.props.history.push("/")
            }
        })
        .catch(error => {
            console.log(error)
            this.setState({
                erro : "Email ou senha incorretos",
                loading : false
            })
        })
    }

    atualizarState = (campo) => {
        this.setState({ [campo.target.name] : campo.target.value})
    }

    componentDidMount() {
        
    }

    componentWillUnmount() {

    }

    render() {
        return (
            <Fragment>
                <form onSubmit={this.login}><div className="form">
                    <h1>Faca login para continuar</h1>
                    <input className="inform" name="email" type="email" value={this.state.email} onChange={this.atualizarState} placeholder="email"/>
                    <input className="inform" name="senha" type="password" value={this.state.senha} onChange={this.atualizarState} placeholder="senha"/>
                    {this.state.loading ? 
                    <button className="inform" disabled>loading</button> :
                    <button type="submit">Login</button>}</div>
                    <span className="error">{this.state.erro}</span>
                </form>
            </Fragment>
        )
    }
}
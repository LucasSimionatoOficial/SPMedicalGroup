import React, {Component} from 'react'
import axios from 'axios'

import {usuarioAutenticado, usuarioExpirado, parseJwt} from '../../services/auth.js'

export default class Paciente extends Component
{
    constructor(props)
    {
        super(props)
        this.state = {
            consultas : []
        }

        if(usuarioAutenticado() === false) {
            this.props.history.push("/")
        }
        else if(usuarioExpirado().getTime <= new Date().getTime() || parseJwt().role !== "1") {
            this.props.history.push("/")
        }
    }

    sair = () => {
        localStorage.clear()
        this.props.history.push("/login")
    }

    componentDidMount() {
        axios("http://localhost:5000/api/consultas", {
            headers: {
                "Authorization" : "Bearer " + localStorage.getItem('jwt_key')
            }
        })
        .then(response => {
            if(response.status === 200) {
                this.setState({consultas : response.data})
                console.log(this.state.consultas)
            }
        })
        .catch(error => {
            console.log(error)
        })
    }

    componentWillUnmount() {

    }

    render() {
        return (
            <main>
            <div className="content">
                <div className="flex"><h1>Consultas</h1><a onClick={this.sair}>sair</a></div>
                {/* <button onClick={sair}>sair</button> */}
                {
                this.state.consultas[0] === undefined ?
                <h2>nao ha consultas cadastradas</h2>
                :
                <table>
                    <thead>
                        <tr>
                            <th>Descricao</th>
                            <th>Horario</th>
                        </tr>
                    </thead>
                    <tbody>
                    {this.state.consultas.map( consulta => {
                        return <tr key={consulta.idConsulta}>
                                    <td>{consulta.descricao}</td>
                                    <td>{consulta.dataConsulta}</td>
                                </tr>
                            }
                        )
                    }
                    </tbody>
                </table>
                }
            </div>  
            </main>
        )
    }
}
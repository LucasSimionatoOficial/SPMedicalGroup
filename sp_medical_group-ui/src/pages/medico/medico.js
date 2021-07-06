import React, {Component} from 'react'
import axios from 'axios'
import '../../assets/style.css'
import {usuarioAutenticado, parseJwt, usuarioExpirado} from '../../services/auth.js'

export default class Paciente extends Component
{
    constructor(props)
    {
        super(props)
        this.state = {
            consultas : [],
            descricao : "",
            idConsulta : 0,
            consulta : "",
            load : false
        }

        if((usuarioAutenticado()) === false) {
            this.props.history.push("/")
        }
        else if(usuarioExpirado().getTime() <= new Date().getTime() || parseJwt().role !== "2") {
            this.props.history.push("/")
        }
    }

    sair = () => {
        localStorage.clear()
        this.props.history.push("/login")
    }

    atualizarCampo = (campo) => {
        campo.preventDefault()
        this.setState({ [campo.target.name]: campo.target.value})
        console.log(this.state.descricao)
    }

    componentDidMount() {
        // this.idDescricao = setInterval(this.Descricao(), 100)

        axios("http://localhost:5000/api/consultas/agendadas", {
            headers: {
                "Authorization" : "Bearer " + localStorage.getItem('jwt_key')
            }
        })
        .then(response => {
            if(response.status === 200) {
                this.setState({
                    consultas : response.data,
                    load: true
                })
                console.log(this.state.consultas)
            }
        })
        .catch(error => {
            console.log(error)
        })
    }

    update = (campo) => {
        campo.preventDefault()
        console.log(localStorage.getItem("jwt_key"))
        axios.patch("http://localhost:5000/api/consultas/editar/" + this.state.idConsulta, 
        {
            descricao : this.state.descricao},
        {
            headers: {
                "Authorization" : "Bearer " + localStorage.getItem("jwt_key"),
                "Access-Control-Allow-Origin" : "*"
            }
        })
        .then(response => {
            if(response.status === 200) {

            }
        })
        .catch(error => {
            console.log(error)
        })
    }

    Descricao = () =>  {
        if(this.consulta === {}) {
            return 
        }
    }

    componentWillUnmount() {

    }

    render() {
        return (
            this.state.load === false ?
            <h2>Loading...</h2>
            :
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
                                    <td className="flex"><p>{consulta.descricao}</p> <button className="buttonEditar" value ={consulta.idConsulta} name="idConsulta" onClick={this.atualizarCampo}>Editar</button></td>
                                    <td>{consulta.dataConsulta}</td>
                                </tr>
                            }
                        )
                    }
                    </tbody>
                    
                </table>
                }
                <div className={this.state.idConsulta == 0 ?
                    "none": "editarConsulta"
                    }>
                    <h2>Editar consulta</h2>
                    <p></p>
                    <form onSubmit={this.update}>
                        <input type="text" name="descricao" value={this.state.descricao} onChange={this.atualizarCampo} />
                        <div>
                            <button type="submit" className="buttonEditar">Editar</button>
                            <button name="idConsulta" value={0} className="buttonEditar"onClick={this.atualizarCampo}>Cancelar</button>
                        </div>
                    </form>
                </div>
            </div>
            </main>
        )
    }
}
import React, {Component} from 'react'
import axios from 'axios'
import '../../assets/style.css'
import {usuarioAutenticado, parseJwt, usuarioExpirado} from '../../services/auth.js'

function data (data, hora) {
    console.log(parseInt(data.toString().split("-")[2]))
    var a = new Date(
        parseInt(data.toString().split("-")[0]), 
        parseInt(data.toString().split("-")[1]) - 1, 
        parseInt(data.toString().split("-")[2]), 
        parseInt(hora.toString().split(":")[0]), 
        parseInt(hora.toString().split(":")[1]),
        0,
        0
    )
    console.log(a)
    return a
}

export default class Paciente extends Component
{
    constructor(props)
    {
        super(props)
        this.state = {
            consultas : [],
            pacientes : [],
            medicos : [],
            idConsulta : 0,
            idPaciente : 0,
            idMedico : 0,
            descricao : "",
            data : new Date(),
            hora : new Date(),
            load : false
        }

        if(usuarioAutenticado() === false) {
            this.props.history.push("/")
        }
        else if(usuarioExpirado().getTime() <= new Date().getTime() || parseJwt().role !== "3") {
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
    }

    componentDidMount() {
        // this.idDescricao = setInterval(this.Descricao(), 100)

        this.lista()
    }

    lista = () => {
        axios("http://localhost:5000/api/consultas/listaradm", {
            headers: {
                "Authorization" : "Bearer " + localStorage.getItem('jwt_key')
            }
        })
        .then(response => {
            if(response.status === 200) {
                this.setState({
                    consultas : response.data,
                })
                console.log(this.state.consultas)
            }
        })
        .catch(error => {
            console.log(error)
        })
        
        axios("http://localhost:5000/api/pacientes", {
            headers: {
                "Authorization" : "Bearer " + localStorage.getItem("jwt_key")
            }
        })
        .then(response => {
            if(response.status === 200) {
                this.setState({
                    pacientes : response.data
                })
            }
        })
        .catch(error => {
            console.log(error)
        })

        axios("http://localhost:5000/api/medicos", {
            headers: {
                "Authorization" : "Bearer " + localStorage.getItem("jwt_key")
            }
        })
        .then(response => {
            if(response.status === 200) {
                this.setState({
                    medicos : response.data,
                    load: true
                })
            }
        })
        .catch(error => {
            console.log(error)
        })
    }

    update = (campo) => {
        campo.preventDefault()
        console.log(localStorage.getItem("jwt_key"))
        axios.patch("http://localhost:5000/api/consultas/id" + this.state.idConsulta, 
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

    create = (campo) => {
        campo.preventDefault()
        axios.post("http://localhost:5000/api/consultas/", {
            idPaciente : this.state.idPaciente,
            idMedico : this.state.idPaciente,
            idSituacao : 2,
            descricao : this.state.descricao,
            dataConsulta : data(this.state.data, this.state.hora)
        }, {
            headers : {
                "Authorization" : "Bearer " + localStorage.getItem("jwt_key")
            }
        })
        .then(response => {
            if(response.status === 200) {
                console.log(response)
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
                <table id="administador">
                    <thead>
                        <tr>
                            <th>Paciente</th>
                            <th>Medico</th>
                            <th>Descricao</th>
                            <th>Horario</th>
                            <th>Situacao</th>
                        </tr>
                    </thead>
                    <tbody>
                    {this.state.consultas.map( consulta => {
                        return <tr key={consulta.idConsulta}>
                                    <td>{this.state.medicos.map(medico => {
                                        if(consulta.idMedico == medico.idMedico) {
                                            return medico.idUsuarioNavigation.nome
                                        }
                                    })}</td>
                                    <td>{this.state.pacientes.map(paciente => {
                                        if(consulta.idPacienteNavigation.idUsuario == paciente.idPaciente) {
                                            return paciente.idUsuarioNavigation.nome
                                        }
                                    })}</td>
                                    <td>{consulta.descricao}</td>
                                    <td>{consulta.dataConsulta}</td>
                                    <td>{consulta.idSituacaoNavigation.situacao1}</td>
                                </tr>
                            }
                        )
                    }
                    </tbody>
                    
                </table>
                }
                {/* <div className={this.state.idConsulta == 0 ?
                    "none": "editarConsulta"
                    }> */}
                    <form onSubmit={this.create} className="form">
                        <h2>Criar consulta</h2>
                        <div>
                            <select name="idPaciente" value={this.state.paciente} onChange={this.atualizarCampo} required>
                                <option value="">Paciente</option>
                                {this.state.pacientes.map(paciente => {
                                    return <option value={paciente.idPaciente}>{paciente.idUsuarioNavigation.nome}</option>
                                })}
                            </select>
                            <select name="idMedico" value={this.state.medico} onChange={this.atualizarCampo} required>
                                <option value="">Medico</option>
                                {this.state.medicos.map(medico => {
                                    return <option value={medico.idMedico}>{medico.idUsuarioNavigation.nome} - {medico.idEspecialidadeNavigation.especialidade1}</option>
                                })}
                            </select>
                        </div>
                        <div>
                            <input type="text" id="input" placeholder="descricao" name="descricao" value={this.state.descricao} onChange={this.atualizarCampo} required />
                        </div>
                        <div>
                            <input type="date" name="data" value={this.state.data} onChange={this.atualizarCampo} pattern="^([0-9]{2})[/]([0-1][0-9])[/]([2][0-9]{3})" required/>
                            <input type="time" name="hora" value={this.state.hora} onChange={this.atualizarCampo} required />
                        </div>
                        <button>Criar</button>
                    </form>
                {/* </div> */}
                
            </div>
            </main>
        )
    }
}
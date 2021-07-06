using SP_Medical_Group.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SP_Medical_Group.WebApi.Interfaces
{
    interface IConsultumRepository
    {
        /// <summary>
        /// Cria consulta
        /// </summary>
        /// <param name="consulta">consulta</param>
        void Criar(Consultum consulta);

        /// <summary>
        /// Lista consulta
        /// </summary>
        /// <returns>Lista de consultas</returns>
        List<Consultum> Listar();

        /// <summary>
        /// Atualiza consulta
        /// </summary>
        /// <param name="id">id da consulta</param>
        /// <param name="consulta">consulta</param>
        void Atualizar(int id, Consultum consulta);

        /// <summary>
        /// Deleta consulta
        /// </summary>
        /// <param name="id">id da consulta</param>
        void Deletar(int id);

        /// <summary>
        /// Busca consulta pelo id
        /// </summary>
        /// <param name="id">id da consulta</param>
        /// <returns>consulta</returns>
        Consultum BuscarPorId(int id);

        List<Consultum> ListarMed(int id);

        List<Consultum> ListarPa(int id);
    }
}

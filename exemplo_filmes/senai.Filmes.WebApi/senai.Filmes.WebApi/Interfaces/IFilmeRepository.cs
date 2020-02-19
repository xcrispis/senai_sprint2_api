using senai.Filmes.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.Filmes.WebApi.Interfaces
{
    interface IFilmeRepository
    {
        /// <summary>
        /// Listar filmes
        /// </summary>
        /// <returns></returns>
        List<FilmeDomain> Listar();

        /// <summary>
        /// Busca filmes por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        FilmeDomain BuscarFilmeId(int id);

        /// <summary>
        /// Cadastra um novo filme
        /// </summary>
        /// <param name="filme"></param>
        void Cadastrar(FilmeDomain filme);

        /// <summary>
        /// Atualiza um filme
        /// </summary>
        /// <param name="filme"></param>
        void AtualizarIdCorpo(FilmeDomain filme);

        /// <summary>
        /// Deletar filme pelo id
        /// </summary>
        /// <param name="id"></param>
        void Deletar(int id);



    }
}

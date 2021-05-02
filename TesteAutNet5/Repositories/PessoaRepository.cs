using TesteAutNet5.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using TesteAutNet5.Repositories;

using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;

namespace TesteAutNet5.Repositories
{
    public class PessoaRepository
    {
        private static List<Pessoa> pessoas = new List<Pessoa>();

        //  Insere a pessoa na lista

        public static Pessoa inserir(PessoaRecebida pessoaR)
        {
            Pessoa p = new Pessoa();

            p.Nome = pessoaR.Nome;
            p.Uf = pessoaR.Uf;
            p.Data = pessoaR.Data;
            p.Cpf = pessoaR.Cpf;

            p.Id = pessoas.Count + 1;

            pessoas.Add(p);
            return p;
        }

        //  Retorna a lista de pessoas

        public static List<Pessoa> All()
        {
            return pessoas;
        }

        // Pesquisa uma pessoa pelo ID

        public static ActionResult<Pessoa> Id(int id)
        {
            var searchID = pessoas.Where(item => item.Id == id).FirstOrDefault();
            //Pessoa p = pessoas.First(x => x.Id.Equals(id));
            if (searchID != null)
            {
                return searchID;
            }

            return null;
        }

        //  Pesquisa as pessoas de um UF

        public static List<Pessoa> UF(string uf)
        {
            List<Pessoa> pessoasUF = new List<Pessoa>();

            foreach (Pessoa p in pessoas)
            {
                if (p.Uf.Equals(uf))
                {
                    pessoasUF.Add(p);
                }
            }

            return pessoasUF;
        }


        //  Atualiza uma pessoa pelo Cpf.

        public static ActionResult<Pessoa> Atualizar(Pessoa p)
        {
            var pessoa = Id(p.Id);
            if (pessoa != null)
            {
                int index = pessoas.IndexOf(pessoas.First(x => x.Id.Equals(p.Id)));

                pessoas[index].Nome = p.Nome;
                pessoas[index].Cpf = p.Cpf;
                pessoas[index].Uf = p.Uf;
                pessoas[index].Data = p.Data;

                return pessoas[index];
            }
            return null;
        }

        //  Deleta uma pessoa pelo Id.

        public static ActionResult<Pessoa> Deletar(int id)
        {
            var pessoa = Id(id);
            if (pessoa != null)
            {
                pessoas.RemoveAt(pessoas.IndexOf(pessoas.First(x => x.Id.Equals(id))));
                return pessoa;
            }
            return null;
            
        }

    }
}
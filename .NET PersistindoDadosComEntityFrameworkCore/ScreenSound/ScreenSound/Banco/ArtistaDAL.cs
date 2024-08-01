using Microsoft.EntityFrameworkCore;
using ScreenSound.Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenSound.Banco
{
    internal class ArtistaDAL : DAL
    {
        private readonly ScreenSoundContext context;

        public ArtistaDAL(ScreenSoundContext context)
        {
            this.context = context;
        }

        public IEnumerable<Artista> Listar()
        {
            //SQLConnection - representa a conexão com o banco de dados;
            //SQLComand - representa a instrução SQL que será executada no banco de dados;
            // SQLDataReader - fornece um modo de ler as linhas do banco de dados.
            return context.Artistas.ToList();
        }
        
        public void Adicionar(Artista artista)
        {
            context.Artistas.Add(artista);
            context.SaveChanges(); //salva as alterações da tabela
        }
        
        public void Atualizar(Artista artista)
        {
            context.Artistas.Update(artista);
            context.SaveChanges(); //salva as alterações da tabela
        }
        
        public void Deletar(Artista artista)
        {
            context.Artistas.Remove(artista);
            context.SaveChanges(); //salva as alterações da tabela
        }

        public Artista? RecuperarPeloNome(string nome)
        {
            return context.Artistas.FirstOrDefault(artista => artista.Nome.Equals(nome));

        }
    }
}

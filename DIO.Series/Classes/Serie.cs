using System;

namespace DIO.Series
{
    public class Serie : EntidadeBase
    {
        public Serie(int codigo,
                      Genero genero, 
                      string titulo, 
                      string descricao, 
                      int ano)
        {
          Codigo = codigo;
          Genero = genero;
          Titulo = titulo;
          Descricao = descricao;
          Ano = ano;
          Excluido = false;
        }

        public int Codigo { get; set; }
        public Genero Genero { get; private set; }
        public string Titulo { get; private set; }
        public string Descricao { get; private set; }
        public int Ano { get; private set; }
        public bool Excluido { get; private set; }

        public override string ToString()
        {
            string retorno = string.Empty;
            retorno = string.Concat("Gênero: ", this.Genero, Environment.NewLine,
                "Título: ", this.Titulo, Environment.NewLine,
                "Descrição: ", this.Descricao, Environment.NewLine,
                "Ano de Início: ", this.Ano, Environment.NewLine,
                this.Excluido ? "*Excluido*" : "");
            return retorno;
        }

        public string retornarTitulo()
        {
            return this.Titulo;
        }

        public Guid retornarId()
        {
            return this.Id;
        }

        public int retornarCodigo()
        {
            return this.Codigo;
        }

        public void Excluir()
        {
            this.Excluido = true;
        }

        public void Atualizar(Serie serie)
        {
            this.Genero = !string.IsNullOrEmpty(serie.Genero.ToString())
                ? serie.Genero
                : this.Genero;
            
            this.Titulo = !string.IsNullOrEmpty(serie.Titulo.ToString())
                ? serie.Titulo
                : this.Titulo;
            
            this.Descricao = !string.IsNullOrEmpty(serie.Descricao.ToString())
                ? serie.Descricao
                : this.Descricao;

            this.Ano = !string.IsNullOrEmpty(serie.Ano.ToString())
                && serie.Ano > 0 ? serie.Ano : this.Ano;
        }
    }
}
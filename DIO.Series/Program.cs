using System;

namespace DIO.Series
{
    class Program
    {
        static void Main(string[] args)
        {
            AcoesMenuUsuario acoesMenuUsuario = new AcoesMenuUsuario();

            string opcaoUsuario = acoesMenuUsuario.ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        acoesMenuUsuario.ListarSeries();
                        break;
                    case "2":
                        acoesMenuUsuario.InserirSerie();
                        break;
                    case "3":
                        acoesMenuUsuario.AtualizarSerie();
                        break;
                    case "4":
                        acoesMenuUsuario.ExcluirSerie();
                        break;
                    case "5":
                        acoesMenuUsuario.VisualizarSerie();
                        break;
                    case "6":
                        acoesMenuUsuario.GerarRelatorio();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();

                }

                opcaoUsuario = acoesMenuUsuario.ObterOpcaoUsuario();
            }
        }
    }
}

using System;
using System.IO;

namespace DIO.Series
{
    public class AcoesMenuUsuario
    {
        private readonly SerieRepositorio _repositorio ;

        public AcoesMenuUsuario()
        {
            _repositorio = new SerieRepositorio();
        }

        public string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Séries a seu dispor");
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1 - Listar séries");
            Console.WriteLine("2 - Inserir nova série");
            Console.WriteLine("3 - Atualizar série");
            Console.WriteLine("4 - Excluir série");
            Console.WriteLine("5 - Visualizar série");
            Console.WriteLine("6 - Gerar Relatorio");
            Console.WriteLine("C - Limpar tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            var opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }

        public void ListarSeries()
        {
            Console.WriteLine("Listar séries");

            var lista = _repositorio.Listar();

            if (lista.Count > 0)
            {
                foreach (var item in lista)
                {
                    var excluido = item.Excluido ? " - *Excluido*" : "";
                    Console.WriteLine($@"#Código {item.retornarCodigo()} - {item.retornarTitulo()}{excluido}");
                }
            }

            Console.WriteLine("Nenhuma série cadastrada");
        }

        public void InserirSerie()
        {
            Console.WriteLine("Inserir nova série");
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {   
                Console.WriteLine($"{i} - {Enum.GetName(typeof(Genero), i)}");
            }

            Console.WriteLine("Digite o genêro entre as opções acima: ");
            int genero = ValidarTryParseInt(Console.ReadLine(), 1);

            Console.WriteLine("Digite o Título da Série: ");
            string titulo = Console.ReadLine();

            Console.WriteLine("Digite o Ano de Início da Série: ");
            int ano = ValidarTryParseInt(Console.ReadLine(), DateTime.Now.Year);

            Console.WriteLine("Digite a Descrição da Série: ");
            string descricao = Console.ReadLine();

            Serie novaSerie = new Serie(codigo: _repositorio.ProximoCodigo(),
                                        genero: (Genero)genero,
                                        titulo,
                                        descricao,
                                        ano);

            _repositorio.Inserir(novaSerie);

        }

        public void AtualizarSerie()
        {
            Console.WriteLine("Digite o código da série: ");
            int codigo = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {   
                Console.WriteLine($"{i} - {Enum.GetName(typeof(Genero), i)}");
            }

            Console.WriteLine("Digite o genêro entre as opções acima: ");
            int genero = ValidarTryParseInt(Console.ReadLine(), 1);

            Console.WriteLine("Digite o Título da Série: ");
            string titulo = Console.ReadLine();

            Console.WriteLine("Digite o Ano de Início da Série: ");
            int ano = ValidarTryParseInt(Console.ReadLine(), DateTime.Now.Year);

            Console.WriteLine("Digite a Descrição da Série: ");
            string descricao = Console.ReadLine();

            Serie serieAlterada = new Serie(codigo,
                                        genero: (Genero)genero,
                                        titulo,
                                        descricao,
                                        ano);

            _repositorio.Atualizar(codigo, serieAlterada);
        }

        public void VisualizarSerie()
        {
            Console.WriteLine("Digite o código da série: ");
            int codigo = int.Parse(Console.ReadLine());

            Console.WriteLine(_repositorio.RetornarPorCodigo(codigo).ToString());
        }

        public void ExcluirSerie()
        {
            Console.WriteLine("Digite o código da série: ");
            int codigo = int.Parse(Console.ReadLine());

            var serie = _repositorio.RetornarPorCodigo(codigo).ToString();

            if (string.IsNullOrEmpty(serie))
            {
                Console.WriteLine("Não existe serie com o codigo informado");
            }

            _repositorio.Excluir(codigo);
        }

        public void GerarRelatorio()
        {
            string diretorio = Path
                .GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory
                    .ToString());
            string arquivo = string.Concat(diretorio, 
                        @"\", 
                        Guid.NewGuid().ToString().Replace("-",""), 
                        ".txt");
            StreamWriter sw = new StreamWriter(arquivo);
            
            var series = _repositorio.Listar();

            foreach (var item in series)
            {
                sw.WriteLine(item.ToString());
                sw.WriteLine();
            }

            sw.Close();

            System.Diagnostics.Process.Start("notepad.exe", arquivo);

        }

        private int ValidarTryParseInt(string valor, int valorPadrao)
        {
            if (int.TryParse(valor, out int retornoValor))
            {
                return retornoValor;
            }
            else
            {
                return valorPadrao;
            }
        }
    }
}
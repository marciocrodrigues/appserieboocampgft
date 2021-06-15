using System.Collections.Generic;
using System.Linq;

namespace DIO.Series
{
  public class SerieRepositorio : IRepositorio<Serie>
  {

    private readonly List<Serie> _series;

    public SerieRepositorio()
    {
        _series = new List<Serie>();
    }
    public void Atualizar(int codigo, Serie entidade)
    {
        _series[this.RetornarIndice(codigo)].Atualizar(entidade);
    }   
    public void Excluir(int codigo)
    {
        _series[this.RetornarIndice(codigo)].Excluir();
    }   
    public void Inserir(Serie entidade)
    {
        _series.Add(entidade);
    }   
    public List<Serie> Listar()
    {
        return _series.ToList();
    }   
    public int ProximoCodigo()
    {
      return _series.Count + 1;
    }   
    public Serie RetornarPorCodigo(int codigo)
    {
        return _series
            .Where(x => x.Codigo == codigo)
            .FirstOrDefault();
    }

    private int RetornarIndice(int codigo)
    {
        var serie = _series
            .Where(x => x.Codigo == codigo)
            .FirstOrDefault();
        
        return _series.IndexOf(serie);
    }
  }
}
using System;
using System.Collections.Generic;

namespace DIO.Series
{
    public interface IRepositorio<T> where T : class
    {
         List<T> Listar();
         T RetornarPorCodigo(int codigo);
         void Inserir(T entidade);
         void Excluir(int codigo);
         void Atualizar(int codigo, T entidade);
         int ProximoCodigo();
    }
}
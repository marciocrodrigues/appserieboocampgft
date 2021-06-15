using System;

namespace DIO.Series
{
    public abstract class EntidadeBase
    {
        public EntidadeBase()
        {
          Id = Guid.NewGuid();
        }

        public Guid Id { get; protected set; }
    }
}
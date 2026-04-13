using Excepciones;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaNegocio.ValueObjects
{
    public class DescripcionTema : IEquatable<DescripcionTema>
    {

        public string Valor { get; private set; }

        public DescripcionTema(string valor)
        {
            Valor = valor;
            Validar();
        }

        private void Validar()
        {
            if (Valor != null && Valor.Length > 100) throw new DatosInvalidosException("La descripción debe tener como máximo 100 caracteres");
        }

        public bool Equals(DescripcionTema? other)
        {
            if (other == null) return false;
            return this.Valor.Equals(other.Valor);
        }
    }
}

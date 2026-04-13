using Excepciones;
using System;
using System.Collections.Generic;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LogicaNegocio.ValueObjects
{
    
    public class NombreTema : IEquatable<NombreTema>
    {
        // NO TIENE ID

        public string Valor { get; private set; } // ES INMUTABLE (SET PRIVADO)

        public NombreTema(string valor)
        {
            Valor = valor;
            Validar(); // SE VALIDA AL MOMENTO DE CREARSE
        }       

        private void Validar() // SE AUTOVALIDA (ENCAPSULA LA REGLA DE NEGOCIO DE VALIDACIÓN)
        {
            if (string.IsNullOrEmpty(Valor)) throw new DatosInvalidosException("El nombre del tema es obligatorio");
            if (Valor.Length < 3) throw new DatosInvalidosException("El nombre del tema debe tener al menos 3 caracteres");

        }


        // REDEFINE EQUALS PARA COMPARAR VALOR (ES VALUE OBJECT)
        public bool Equals(NombreTema? other)
        {
            if (other == null) return false;
            return this.Valor.Equals(other.Valor);
        }
    }
}

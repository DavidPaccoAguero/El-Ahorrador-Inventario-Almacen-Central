using System;
using System.Collections.Generic;
using System.Text;

namespace ElAhorrador.Negocio.Dominio
{
    public class Categoria
    {
        public int IdCategoria { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public bool Estado { get; set; }
        public int? IdCategoriaSuperior { get; set; }
    }

    public class UnidadControlStock
    {
        public int IdUnidadMedida { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Simbolo { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public byte DecimalesPermitidos { get; set; }
        public bool Estado { get; set; }

        public string EtiquetaCombo
        {
            get { return Simbolo; }
        }
    }

    public class Ubicacion
    {
        public int IdUbicacion { get; set; }
        public string Codigo { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public int IdZona { get; set; }
        public string NombreZona { get; set; } = string.Empty;
        public string ClasificacionZona { get; set; } = string.Empty;
        public string TipoConservacion { get; set; } = string.Empty;
        public bool Estado { get; set; }

        public string EtiquetaCombo
        {
            get { return $"{Codigo} - {Nombre}"; }
        }
    }

    public class Local
    {
        public int IdLocal { get; set; }
        public string Nombre { get; set; } = string.Empty;
    }
}

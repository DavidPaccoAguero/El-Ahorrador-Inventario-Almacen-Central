using System;
using System.Collections.Generic;
using System.Text;
using ElAhorrador.Negocio.Dominio;

namespace ElAhorrador.Negocio.Intercambio
{
    public class ResultadoSesion
    {
        public bool Exito { get; set; }
        public string Mensaje { get; set; } = string.Empty;
        public Usuario? Usuario { get; set; }
    }

    public class ResultadoRegistro
    {
        public bool Exito { get; set; }
        public string Mensaje { get; set; } = string.Empty;
        public int IdGenerado { get; set; }
        public string CodigoFormateado { get; set; } = string.Empty;
    }

    public class DatosProducto
    {
        public string Codigo { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public string PresentacionFisica { get; set; } = string.Empty;
        public int IdCategoria { get; set; }
        public string Clasificacion { get; set; } = "ALIMENTO";
        public string ConservacionRequerida { get; set; } = "SECO";
        public bool ControlLote { get; set; } = true;
        public bool ControlVencimiento { get; set; } = true;
        public int IdUnidadMedidaInicial { get; set; }
        public int IdUbicacionInicial { get; set; }
    }

    public class ComandoEntrada
    {
        public int NumeroConfirmacion { get; set; }
        public string Tipo { get; set; } = "COMPRA_PROVEEDOR";
        public string? Proveedor { get; set; }
        public int? IdLocalOrigen { get; set; }
        public string Conductor { get; set; } = string.Empty;
        public string Placa { get; set; } = string.Empty;
        public string? Observaciones { get; set; }

        public int IdProducto { get; set; }
        public int IdUnidadMedida { get; set; }
        public int IdUbicacion { get; set; }
        public decimal CantidadEsperada { get; set; }
        public decimal CantidadRecibida { get; set; }
        public decimal CantidadAceptada { get; set; }
        public string? Lote { get; set; }
        public DateOnly? Vencimiento { get; set; }
        public bool VencimientoComprobado { get; set; } = true;
        public string? ObservacionIncidencia { get; set; }
    }

    public class DetalleEntradaCalculado
    {
        public decimal CantidadFaltante { get; set; }
        public decimal CantidadNoAceptada { get; set; }
        public string ResultadoVerificacion { get; set; } = "CONFORME";
        public string? LoteFinal { get; set; }
        public string? OrigenLote { get; set; }
        public DateOnly? VencimientoFinal { get; set; }
        public string EstadoVerificacionVencimiento { get; set; } = "NO_REQUERIDO";
    }

    public class FiltroStock
    {
        public int? IdProducto { get; set; }
        public int? IdUbicacion { get; set; }
    }

    public class FilaStock
    {
        public int IdProducto { get; set; }
        public string CodigoProducto { get; set; } = string.Empty;
        public string NombreProducto { get; set; } = string.Empty;
        public int IdUnidadMedida { get; set; }
        public string UnidadControl { get; set; } = string.Empty;
        public int IdUbicacion { get; set; }
        public string CodigoUbicacion { get; set; } = string.Empty;
        public decimal Registrada { get; set; }
        public decimal Habilitada { get; set; }
    }

    public class FilaGrupoStock
    {
        public int IdGrupo { get; set; }
        public string GrupoLote { get; set; } = string.Empty;
        public string Recepcion { get; set; } = string.Empty;
        public string Vencimiento { get; set; } = string.Empty;
        public string Verificacion { get; set; } = string.Empty;
        public decimal Cantidad { get; set; }
        public bool Habilitado { get; set; }
        public string CondicionDespacho { get; set; } = string.Empty;
    }
}

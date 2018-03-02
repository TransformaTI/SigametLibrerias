using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GasMetropolitano.Runtime.Negocio
{
    public interface IDatosFiscales
    {
        int IDEmpresa { get; set; }

        int IDDatosFiscales { get; set; }
        string RFC { get; set; }
        string CURP { get; set; }
        string RazonSocial { get; set; }
        string NombreComercial { get; set; }
        string NombreCuenta { get; set; }
        string Calle { get; set; }
        string Colonia { get; set; }
        string NumExterior { get; set; }
        string Estado { get; set; }
        string AbreviaturaEstado { get; set; }
        string Municipio { get; set; }
        string CP { get; set; }
        string Ciudad { get; set; }
        string Pais { get; set; }
        string Telefono1 { get; set; }
        string Telefono2 { get; set; }
        string Telefono3 { get; set; }
        string Contacto { get; set; }
        string TipoPersona { get; set; }
        string Nombre { get; set; }
        string SegundoNombre { get; set; }
        string ApellidoPaterno { get; set; }
        string ApellidoMaterno { get; set; }
        int CopiasCFD { get; set; }
        bool? EnvioCFDCorreo { get; set; }
        string Email { get; set; }
        string Email2 { get; set; }
        string Email3 { get; set; }
        string FormaPagoSAT { get; set; }
        string FormaPagoSATDescripcion { get; set; }
        string NumeroCuentaPago { get; set; }
        string UsoCFD { get; set; }
        string UsoCFDDescripcion { get; set; }
        string WebSite { get; set; }
        Dictionary<string, string> PreferenciasCliente { get; set; }
        void Consultar();
        void ConsultarPreferenciasUsuario();
    }
}

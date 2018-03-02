using GasMetropolitano.Runtime.Negocio;
using System;
using System.Collections.Generic;

namespace GasMetropolitano.Runtime.Negocio
{
    public interface IDireccionEntrega
    {
        Fuente FuenteDatos { get; set; }

        int IDEmpresa { get; set; }
        int IDDireccionEntrega { get; set; }
        int? IDAutotanque { get; set; }

        DateTime? FechaConsulta { get; set; }

        int DigitoVerificador { get; set; }
        string ReferenciaBancaria { get; set; }
        string Nombre { get; set; }
        string NumExterior { get; set; }
        string Manzana { get; set; }
        string NumInterior { get; set; }
        string Lote { get; set; }
        string Status { get; set; }
        string StatusCalidad { get; set; }
        string Lada { get; set; }
        string Telefono1 { get; set; }
        string Telefono2 { get; set; }
        string Telefono3 { get; set; }
        string TelefonoCelular { get; set; }
        Georreferencia Georreferencia { get; set; }
        string Observaciones { get; set; }
        string Email { get; set; }
        string DireccionCompleta { get; set; }
        DatosFiscales DatosFiscales { get; set; }
        int IDCalle { get; set; }
        string CalleNombre { get; set; }
        int IDColonia { get; set; }
        string ColoniaNombre { get; set; }
        int IDMunicipio { get; set; }
        string MunicipioNombre { get; set; }
        string CP { get; set; }
        string EstadoNombre { get; set; }
        int? IDEntreCalle1 { get; set; }
        string EntreCalle1Nombre { get; set; }
        int? IDEntreCalle2 { get; set; }
        string EntreCalle2Nombre { get; set; }
        decimal? ConsumoPromedio { get; set; }
        bool VIP { get; set; }
        bool ContratoAprobado  { get; set; }
        CondicionesCredito CondicionesCredito { get; set; }
        Precio PrecioPorDefecto { get; set; }
        ConfiguracionSuministro ConfiguracionSuministro { get; set; }
        bool? NoSuministrar { get; set; }
        string MotivoNoSuministrar { get; set; }
        string MotivoNoSuministrarCyC { get; set; }
        string MotivoNoSuministrarST { get; set; }

        Zona ZonaSuministro { get; set; }
        Ruta Ruta { get; set; }
        Empleado SupervisorComercial { get; set; }
        string QuejaActiva { get; set; } //MODIIFCAR PARA CONTENER EL DETALLE DE LA QUEJA ACTIVA, AGREGAR UNA CLASE PARA CONTENER LOS DETALLES
        ZonaEconomica ZonaEconomica { get; set; }
        ProgramacionSuministro ProgramacionSuministro { get; set; }

        RamoCliente Ramo { get; set; }
        TipoCliente TipoCliente { get; set; }
        OrigenCliente OrigenCliente { get; set; }

        TipoFacturacion TipoFacturacion { get; set; }
        
        List<TarjetaCredito> TarjetasCredito { get; set; }
        List<Descuento> Descuentos { get; set; }
        List<int> IDClientesRelacionados { get; set; }

        //DireccionEntrega DireccionEntregaPadre { get; set; }
        string NombreContacto { get; set; }
        DateTime? FAlta { get; set; }

        bool Consultar();
        bool ConsultarRestriccionesSuministro(int? IDAutotanque = null);
        bool ConsultarTarjetasCredito();
        bool ConsultarDescuentos();
        bool ConsultarClientesRelacionados();
    }
}
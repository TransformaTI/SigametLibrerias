namespace GasMetropolitano.Runtime.Negocio
{
    public interface IAutoanque
    {
        int IdAutotanque { get; set; }
        int IdCelula { get; set; }
        int IdRuta { get; set; }

        bool Eliminar();
        bool Guardar();
        bool Modificar();
    }
}
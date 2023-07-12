namespace CajeroAutomatico.DTO
{
    public class SesionDTO
    {
        public int IdCliente { get; set; }

        public int IdCuenta { get; set; }

        public string Nombre { get; set; } = null!;

        public string ApellidoPaterno { get; set; } = null!;

        public string ApellidoMaterno { get; set; } = null!;

        public string? RolDescripcion { get; set; }


    }
}

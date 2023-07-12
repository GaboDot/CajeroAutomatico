namespace CajeroAutomatico.DTO
{
    public class ClienteDTO
    {
        public int IdCliente { get; set; }

        public string Nombre { get; set; } = null!;

        public string ApellidoPaterno { get; set; } = null!;

        public string ApellidoMaterno { get; set; } = null!;

        public int IdRol { get; set; }

        public string RolDescripcion { get; set; } = null!;
    }
}

namespace CajeroAutomatico.DTO
{
    public class TarjetaClienteDTO
    {
        public int IdTarjeta { get; set; }

        public string NumeroTarjeta { get; set; } = null!;

        public DateTime FechaExpedicion { get; set; }

        public DateTime FechaExpiracion { get; set; }

        public string Nip { get; set; } = null!;

        public int IdCuenta { get; set; }
    }
}

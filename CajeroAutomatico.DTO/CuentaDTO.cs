namespace CajeroAutomatico.DTO
{
    public class CuentaDTO
    {
        public int IdCuenta { get; set; }

        public DateTime FechaCreacion { get; set; }

        public decimal Saldo { get; set; }

        public int IdCliente { get; set; }

        public int IdTarjeta { get; set; }
    }
}

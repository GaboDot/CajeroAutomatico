namespace CajeroAutomatico.DTO
{
    public class MovimientoDTO
    {
        public int IdMovimiento { get; set; }

        public DateTime FechaMovimiento { get; set; }

        public int Accion { get; set; }

        public decimal Cantidad { get; set; }

        public int IdCuenta { get; set; }
    }
}

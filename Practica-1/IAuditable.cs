namespace RedMeteorologica
{
    public interface IAuditable
    {
        void Auditar(string evento, string detalle)
        {
            string mensaje = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - {evento}: {detalle}";
            Console.WriteLine($"[AUDITORÍA] {mensaje}");
        }
    }
}
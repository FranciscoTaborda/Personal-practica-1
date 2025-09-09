namespace RedMeteorologica
{
    public class EstacionUrbana : Estacion, IAuditable
    {
        public override void RegistrarLectura(Lectura nuevaLectura)
        {
            try
            {
                // Filtrar datos atípicos
                if (nuevaLectura.Temperatura < 20 || nuevaLectura.Temperatura > 45)
                {
                    Auditar("error", "Temperatura atípica: " + nuevaLectura.Temperatura + " °C");
                    return;
                }

                if (nuevaLectura.Humedad < 20 || nuevaLectura.Humedad > 95)
                {
                    Auditar("error", "Humedad atípica: " + nuevaLectura.Humedad + "%");
                    return;
                }
                if (nuevaLectura.VelViento < 0 || nuevaLectura.VelViento > 90)
                {
                    Auditar("error", "Velocidad del viento atípica: " + nuevaLectura.VelViento + "km/h");
                    return;
                }
                if (nuevaLectura.Lluvia < 0 || nuevaLectura.Lluvia > 120)
                {
                    Auditar("error", "Precipitación atípica: " + nuevaLectura.Lluvia + "mm/h");
                    return;
                }
                if (nuevaLectura.Presion < 970 || nuevaLectura.Presion > 1050)
                {
                    Auditar("error", "Presión atmosférica atípica: " + nuevaLectura.Presion + "hPa");
                    return;
                }

                UltimaLectura = nuevaLectura;
                Auditar("lectura registrada", "Temp: " + nuevaLectura.Temperatura + "°C, Hum: " +   nuevaLectura.Humedad + "%, VelVien: " +   nuevaLectura.VelViento + " km/h, Lluv: " +   nuevaLectura.Lluvia + " mm/h, Pres: " +   nuevaLectura.Presion + "hPa");
            }
            catch (Exception ex)
            {
                Auditar("error", $"Error: {ex.Message}");
            }
        }

        public override void CalcularResumen()
        {
            // TODO: Implementar cálculo de resumen
        }

        public override void MostrarInformacion()
        {
            // TODO: Mostrar información de la estación
        }

        public void Auditar(string evento, string detalle)
        {
            // TODO: Registrar auditoría
        }
    }
}

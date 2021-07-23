using Xamarin.Forms.Maps;

namespace AgendaMujer.Apps.Mobile.Models
{
    public class CentroAyuda
    {
        public string Tipo { get; set; }
        public string Nombre { get; set; }
        public string Region { get; set; }
        public string Provincia { get; set; }
        public string Distrito { get; set; }
        public string Direccion { get; set; }
        public string Coordinador { get; set; }
        public string Telefono1 { get; set; }
        public string Telefono2 { get; set; }
        public string Telefono3 { get; set; }
        public string Celular1 { get; set; }
        public string Celular2 { get; set; }
        public string Celular3 { get; set; }
        public string Correo1 { get; set; }
        public string Correo2 { get; set; }
        public string Correo3 { get; set; }
        public double Latitud { get; set; }
        public double Longitud { get; set; }

        public Position Posicion
        {
            get => new Position(Latitud, Longitud);
        }
        public double CurrentDistance { get; set; }
        public string Distance => CurrentDistance.ToString("0.00") + " KM";
    }
}
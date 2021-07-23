namespace AgendaMujer.Apps.Mobile.Models
{
    using System.Collections.Generic;
    using Xamarin.Forms.Bootstrap.Icons;

    public class MarcoLegislativo
    {
        public string Titulo { get; set; }
        public Icon Icono { get; set; }
        public List<Derecho> Derechos { get; set; }
    }
}
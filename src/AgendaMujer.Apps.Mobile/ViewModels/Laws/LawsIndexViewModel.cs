using AgendaMujer.Apps.Mobile.Models;
using AgendaMujer.Apps.Mobile.Services.Platform;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Bootstrap.Icons;

namespace AgendaMujer.Apps.Mobile.ViewModels.Laws
{
    public class LawsIndexViewModel : BaseViewModel
    {
        private IEnumerable<MarcoLegislativo> marcosLegislativos;

        public IEnumerable<MarcoLegislativo> MarcosLegislativos
        {
            get => marcosLegislativos;
            set { SetProperty(ref marcosLegislativos, value); }
        }

        public Command AbrirEnlaceCommand { get; }

        public LawsIndexViewModel(NavigationService navigationService) : base(navigationService)
        {
            AbrirEnlaceCommand = new Command<string>(AbrirEnlaceExecute);
        }

        public void AbrirEnlaceExecute(string parameter)
        {
            _ = Browser.OpenAsync(parameter, new BrowserLaunchOptions
            {
                LaunchMode = BrowserLaunchMode.SystemPreferred,
                TitleMode = BrowserTitleMode.Default,
                PreferredToolbarColor = Color.FromHex("#FF95B1")
            });
        }

        public override void Initialize(object data = null)
        {
            base.Initialize(data);

            var derechos = new List<Derecho>();
            derechos.Add(new Derecho { Marco = "Marco universal", Titulo = "Convención sobre la eliminación de todas formas de discriminación contra la mujer (CEDAW)", Enlace = "https://www.ohchr.org/sp/professionalinterest/pages/cedaw.aspx" });
            derechos.Add(new Derecho { Marco = "Marco universal", Titulo = "Declaración de las Naciones Unidas sobre la eliminación de la violencia contra la mujer ", Enlace = "https://www.ohchr.org/sp/professionalinterest/pages/violenceagainstwomen.aspx" });
            derechos.Add(new Derecho { Marco = "Marco regional", Titulo = "Convención interamericana para prevenir, sancionar y erradicar la violencia contra la mujer (Convención Belem do Para)", Enlace = "https://www.oas.org/juridico/spanish/tratados/a-61.html" });
            derechos.Add(new Derecho { Marco = "Nivel nacional", Titulo = "Ley Nº 28983, de igualdad de oportunidades entre mujeres y hombres.", Enlace = "https://leyes.congreso.gob.pe/Documentos/Leyes/28983.pdf" });
            derechos.Add(new Derecho { Marco = "Nivel nacional", Titulo = "Ley Nº 303604, para prevenir, sancionar y erradicar la violencia contra las mujeres y los integrantes del grupo familiar.", Enlace = "https://leyes.congreso.gob.pe/Documentos/Leyes/30364.pdf" });
            derechos.Add(new Derecho { Marco = "Nivel nacional", Titulo = "Ley Nº 30862, que fortalece diversas normas para prevenir, sancionar y erradicar a violencia.", Enlace = "https://leyes.congreso.gob.pe/Documentos/2016_2021/ADLP/Normas_Legales/30862-LEY.pdf" });
            derechos.Add(new Derecho { Marco = "Nivel nacional", Titulo = "Decreto Legislativo Nº 1323, que fortalece la lucha contra el feminicidio, la violencia familiar y la violencia de género.", Enlace = "https://busquedas.elperuano.pe/normaslegales/decreto-legislativo-que-fortalece-la-lucha-contra-el-feminic-decreto-legislativo-n-1323-1471010-2" });
            derechos.Add(new Derecho { Marco = "Nivel nacional", Titulo = "Decreto Legislativo Nº 1408, de fortalecimiento de las familias y prevención de la violencia.", Enlace = "https://busquedas.elperuano.pe/normaslegales/decreto-legislativo-para-el-fortalecimiento-y-la-prevencion-decreto-legislativo-n-1408-1690482-1" });
            derechos.Add(new Derecho { Marco = "Nivel nacional", Titulo = "Decreto de Urgencia Nº 005-2020, que establece una asistencia económica para contribuir a la protección social y el desarrollo integral de las víctimas indirectas de feminicidio.", Enlace = "https://busquedas.elperuano.pe/normaslegales/decreto-de-urgencia-que-establece-una-asistencia-economica-p-decreto-de-urgencia-n-005-2020-1843652-1" });
            derechos.Add(new Derecho { Marco = "Nivel nacional", Titulo = "Decreto de Urgencia Nº 023-2020, que aprueba mecanismos de prevención de la violencia contra las mujeres e integrantes del grupo familia desde el conocimiento de los antecedentes policiales.", Enlace = "https://busquedas.elperuano.pe/normaslegales/decreto-de-urgencia-que-crea-mecanismos-de-prevencion-de-la-decreto-de-urgencia-n-023-2020-1848881-2/" });
            derechos.Add(new Derecho { Marco = "Nivel nacional", Titulo = "Ley Nº 30963, que modifica el código penal respecto a las sanciones del delito la explotación sexual en sus diversas modalidades y delitos conexos, para proteger con especial énfasis a las niñas, niños, adolescentes y mujeres.", Enlace = "https://leyes.congreso.gob.pe/Documentos/2016_2021/ADLP/Texto_Consolidado/30963-TXM.pdf" });
            derechos.Add(new Derecho { Marco = "Nivel nacional", Titulo = "Decreto Legislativo Nº 1470, que establece medidas para garantizar la atención y protección de las víctimas de violencia durante el Covid.", Enlace = "https://busquedas.elperuano.pe/normaslegales/decreto-legislativo-que-establece-medidas-para-garantizar-la-decreto-legislativo-n-1470-1865791-1" });
            derechos.Add(new Derecho { Marco = "Nivel nacional", Titulo = "Decreto Legislativo  Nº 1410, que sanciona los actos de acoso en todas sus modalidades, incluidos el acoso sexual y chantaje sexual, así como la difusión de imágenes, materiales audiovisuales o audios con contenido sexual.", Enlace = "https://busquedas.elperuano.pe/normaslegales/decreto-legislativo-que-incorpora-el-delito-de-acoso-acoso-decreto-legislativo-n-1410-1690482-3/" });
            derechos.Add(new Derecho { Marco = "Nivel nacional", Titulo = "Ley Nº 30314, para prevenir y sancionar el acoso sexual en espacios públicos. ", Enlace = "https://leyes.congreso.gob.pe/Documentos/ExpVirPal/Ficha_Tecnica_Espanol/30314.FTE.pdf" });
            derechos.Add(new Derecho { Marco = "Nivel nacional", Titulo = "Ley Nº 31155, que previene y sanciona el acoso contra las mujeres en la vida política.", Enlace = "https://busquedas.elperuano.pe/normaslegales/ley-que-previene-y-sanciona-el-acoso-contra-las-mujeres-en-l-ley-n-31155-1941276-2/" });

            var groups = derechos.GroupBy(x => x.Marco).ToList();
            MarcosLegislativos = groups.Select(x => new MarcoLegislativo
            {
                Titulo = x.Key,
                Icono = x.Key == "Marco universal" ? Icon.Globe2 : (x.Key == "Marco regional" ? Icon.Hexagon : (x.Key == "Nivel nacional" ? Icon.Flag : throw new KeyNotFoundException())),
                Derechos = x.ToList()
            });
        }
    }
}
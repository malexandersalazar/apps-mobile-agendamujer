using AgendaMujer.Apps.Mobile.Models;
using AgendaMujer.Apps.Mobile.Services.Platform;
using System.Collections.Generic;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace AgendaMujer.Apps.Mobile.ViewModels.HelpCenters
{
    public class HelpCentersDetailViewModel : BaseViewModel
    {
        private CentroAyuda helpCenter;

        public CentroAyuda HelpCenter
        {
            get => helpCenter;
            set => SetProperty(ref helpCenter, value);
        }

        private Command sendEmailCommand;

        public Command SendEmailCommand => sendEmailCommand ?? (sendEmailCommand = new Command<string>(SendEmailExecute));

        private Command callPhoneCommand;

        public Command CallPhoneCommand => callPhoneCommand ?? (callPhoneCommand = new Command<string>(CallPhoneExecute));

        public HelpCentersDetailViewModel(NavigationService navigationService) : base(navigationService)
        {
        }

        public override void Initialize(object data = null)
        {
            base.Initialize(data);
            HelpCenter = (CentroAyuda)data;
        }

        private async void SendEmailExecute(string email)
        {
            var message = new EmailMessage
            {
                Subject = "Necesito ayuda",
                Body = "Mi nombre es [Indicar tu nombre], identificada con DNI [Indicar tu DNI], con domicilio en [Indicar tu dirección] y número celular [Indicar celular].\n\nAcudo a ustedes por el siguiente motivo: [Indicar lo que esta ocurriendo].",
                To = new List<string> { email }
            };
            await Email.ComposeAsync(message);
        }

        private void CallPhoneExecute(string phone)
        {
            PhoneDialer.Open(phone);
        }
    }
}
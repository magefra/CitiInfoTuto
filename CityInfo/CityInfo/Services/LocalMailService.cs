using System.Diagnostics;

namespace CityInfo.Services
{
    /// <summary>
    /// inyectamos el archivo de configuración que contiene un Json con las variables que vamos a utilizar.
    /// </summary>
    public class LocalMailService : IMailService
    {
        private string _mailTo = Startup.Configuration["mailSettings:mailToAddress"];
        private string _mailFrom = Startup.Configuration["mailSettings:mailFromAddress"];


        public void Send(string subject, string mensaje)
        {
            Debug.WriteLine($"Mail from {_mailFrom} to {_mailTo}, with LocalMainService.");
            Debug.WriteLine($"Subject: {subject}");
            Debug.WriteLine($"Message: {mensaje}");
        }
    }
}

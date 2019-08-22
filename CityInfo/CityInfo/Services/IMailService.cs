namespace CityInfo.Services
{
    public interface IMailService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="subject"></param>
        /// <param name="mensaje"></param>
        void Send(string subject, string mensaje);
    }
}

namespace Web.Services
{
    public abstract class DataServiceBase
    {
        protected readonly HttpClient? HttpClient;

        public DataServiceBase(HttpClient? httpClient)
        {
            HttpClient = httpClient;
        }
    }
}

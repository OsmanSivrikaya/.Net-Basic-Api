namespace Case.Helper.Api
{
    public interface IApiHelper
    {
        Task<string> GetAsync(string url);
    }
}

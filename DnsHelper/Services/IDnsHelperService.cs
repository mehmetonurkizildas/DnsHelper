namespace DnsHelper.Services
{
    public interface IDnsHelperService
    {
        IEnumerable<string> GetARecords(string domain);
        IEnumerable<string> GetMxRecords(string domain);
        IEnumerable<string> GetNsRecords(string domain);

    }
}

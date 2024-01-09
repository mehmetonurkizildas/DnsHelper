using DnsClient;

namespace DnsHelper.Services
{
    public class DnsHelperService(ILookupClient client) : IDnsHelperService
    {
        private readonly ILookupClient _client = client ?? throw new ArgumentNullException(nameof(client));

        public IEnumerable<string> GetARecords(string domain)
        {
            foreach (var aRecord in _client.Query(domain, QueryType.A).Answers.ARecords())
            {
                yield return aRecord.ToString();
            }
        }

        public IEnumerable<string> GetMxRecords(string domain)
        {
            foreach (var mxRecord in _client.Query(domain, QueryType.MX).Answers.MxRecords())
            {
                yield return mxRecord.ToString();
            }
        }

        public IEnumerable<string> GetNsRecords(string domain)
        {
            foreach (var nsRecord in _client.Query(domain, QueryType.NS).Answers.NsRecords())
            {
                yield return nsRecord.ToString();
            }
        }
    }

}

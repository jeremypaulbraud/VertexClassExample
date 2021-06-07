    internal class _accessTokenCache
    {
        internal static void Add(string vertexBearerTokenKey, BearerToken updatedToken)
        {
            BearerToken btoken = new BearerToken();
            btoken = _accessTokenCache.Get(updatedToken.TokenValue);
        }

        internal static BearerToken Get(string vertexBearerTokenKey)
        {
            BearerToken btoken = new BearerToken();
            btoken.TokenValue = vertexBearerTokenKey;
            btoken.Expiration = DateTime.UtcNow.AddMinutes(15);
            return btoken;
        }
    }

    public class TokenResponse
    {
        public string access_token { get; set; }
        public string token_type { get; set; }
        public int expires_in { get; set; }
        public string error { get; set; }
    }

    public class AddressResponse
    {
        public string streetAddress1 { get; set; }
        public string streetAddress2 { get; set; }
        public string city { get; set; }
        public string mainDivision { get; set; }
        public string subDivision { get; set; }
        public string postalCode { get; set; }
        public string country { get; set; }
        public string lookupResult { get; set; }
        public int taxAreaId { get; set; }
        public string asOfDate { get; set; }
        public string confidenceIndicator { get; set; }
    }

    public class VertexAddressInfo
    {
        public string postalCode { get; set; }
        public string mainDivision { get; set; }
        public string streetAddress1 { get; set; }
        public string streetAddress2 { get; set; }
        public string country { get; set; }
        public string city { get; set; }
    }

    public class VertexAddress
    {
        public DateTime asOfDate { get; set; }
        public VertexAddressInfo postalAddress { get; set; }
    }

    public class BearerToken
    {
        public string TokenValue { get; set; }
        public DateTime Expiration { get; set; }
    }


    public class AddressValidationResponse
    {
        public AddressValidationResponse()
        {
            var enumVals = new List<object>();
            foreach (var item in Enum.GetValues(typeof(SelectionType)))
            {
                enumVals.Add(new
                {
                    id = (int)item,
                    name = item.ToString()
                });
            }

            SelectedOperationOptions = enumVals;
        }

        public Address RequestedAddress { get; set; }
        public Address SuggestedAddress { get; set; }
        public bool HasAddressSuggestion { get; set; }
        public bool MalformedAddress { get; set; }
        public bool EndpointFailure { get; set; }
        public SelectionType SelectedOperation { get; set; }

        public List<object> SelectedOperationOptions { get; set; }
    }
    public enum SelectionType
    {
        Suggested,
        Original,
        Edited
    }

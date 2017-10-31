namespace ClimateMeter.Web.Hubs
{
    public class SignalRJwtParsingOptions
    {
        public string TokenQueryStringParameter { get; set; }
        public string JwtAuthenticationSchemeName { get; set; }
    }
}
using System;
namespace ResourceServer.Models
{
	public class JwtTokenModal
	{
        public string KeyId { get; }
        public string Issuer { get; }
        public List<string> Audience { get; }
        public List<(string Type, string Value)> Claims { get; }
        public DateTime ValidTo { get; }
        public string SignatureAlgorithm { get; }
        public string RawData { get; }
        public string Subject { get; }
        public DateTime ValidFrom { get; }
        public string EncodedHeader { get; }
        public string EncodedPayload { get; }

        public JwtTokenModal(string keyId, string issuer, List<string> audience, List<(string Type, string Value)> claims, DateTime validTo, string signatureAlgorithm, string rawData, string subject, DateTime validFrom, string encodedHeader, string encodedPayload)
        {
            this.KeyId = keyId;
            this.Issuer = issuer;
            this.Audience = audience;
            this.Claims = claims;
            this.ValidTo = validTo;
            this.SignatureAlgorithm = signatureAlgorithm;
            this.RawData = rawData;
            this.Subject = subject;
            this.ValidFrom = validFrom;
            this.EncodedHeader = encodedHeader;
            this.EncodedPayload = encodedPayload;
        }
    }
}
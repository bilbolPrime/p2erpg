using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BilbolStack.Boonamai.P2ERPG.Api.Models.Requests.Security
{
    public class SignInRequest
    {
        [JsonPropertyName("signature")]
        [Required]
        public string Signature { get; set; }
    }
}

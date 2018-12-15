using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Application.IO.Core.Identity.Authorization
{
    public class SigningCredentialsConfiguration
    {
        private const string SecretKey = "rrelawyers@plan.Jwtoken";
        public static readonly SymmetricSecurityKey Key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(SecretKey));
        public SigningCredentials SigningCredentials { get; }

        public SigningCredentialsConfiguration()
        {
            SigningCredentials = new SigningCredentials(Key, SecurityAlgorithms.HmacSha256);
        }
    }
}

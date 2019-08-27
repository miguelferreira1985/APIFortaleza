using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Entities;
using Repository;
using System.Security.Claims;

namespace APIFortaleza
{
    public class ApplicationOAuthProvider : OAuthAuthorizationServerProvider
    {

        UserRepository userRepository = new UserRepository();


        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {

            var user = userRepository.validateUser(context.UserName, context.Password);

            if (user == null)
            {
                context.SetError("invalid_grant", "Usario y Password son incorrectos");
                return;
            }

            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            identity.AddClaim(new Claim(ClaimTypes.Role, user.UserRoles));
            identity.AddClaim(new Claim(ClaimTypes.Name, user.UserName));

            context.Validated(identity);
        }

    }
}
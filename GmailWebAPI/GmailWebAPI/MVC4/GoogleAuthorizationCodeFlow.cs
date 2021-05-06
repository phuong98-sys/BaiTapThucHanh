using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

using Google.Apis.Auth.OAuth2.Requests;
using Google.Apis.Auth.OAuth2.Responses;
using Google.Apis.Json;
using Google.Apis.Auth.OAuth2.Flows;
using Google.Apis.Auth.OAuth2;

namespace GmailWebAPI.MVC4
{
    public class GoogleAuthorizationCodeFlow : AuthorizationCodeFlow
    {
        /// <summary>
        /// The project ID associated with the credential using this flow.
        /// </summary>
        public string ProjectId { get; private set; }

        private readonly string revokeTokenUrl;

        /// <summary>Gets the token revocation URL.</summary>
        public string RevokeTokenUrl { get { return revokeTokenUrl; } }

        /// <summary>Gets the include granted scopes indicator.
        /// Do not use, use <see cref="IncludeGrantedScopes"/> instead.</summary>
        public readonly bool? includeGrantedScopes;

        /// <summary>Gets the include granted scopes indicator.</summary>
        public bool? IncludeGrantedScopes { get { return includeGrantedScopes; } }

        /// <summary>Gets the login_hint.</summary>
        public string LoginHint { get; private set; }

        /// <summary>
        /// Gets the prompt for consent behaviour.
        /// Value can be <c>null</c>, <c>"none"</c>, <c>"consent"</c>, or <c>"select_account"</c>.
        /// See <a href="https://developers.google.com/identity/protocols/OpenIDConnect#prompt">OpenIDConnect documentation</a>
        /// for details.
        /// </summary>
        public string Prompt { get; private set; }

        /// <summary>Gets the nonce.</summary>
        public string Nonce { get; private set; }

        private readonly IEnumerable<KeyValuePair<string, string>> userDefinedQueryParams;

        /// <summary>Gets the user defined query parameters.</summary>
        public IEnumerable<KeyValuePair<string, string>> UserDefinedQueryParams
        {
            get { return userDefinedQueryParams; }
        }

        /// <summary>Constructs a new Google authorization code flow.</summary>
        public GoogleAuthorizationCodeFlow(Initializer initializer)
            : base(initializer)
        {
            ProjectId = initializer.ProjectId;
            revokeTokenUrl = initializer.RevokeTokenUrl;
            includeGrantedScopes = initializer.IncludeGrantedScopes;
            LoginHint = initializer.LoginHint;
            Prompt = initializer.Prompt;
            Nonce = initializer.Nonce;
            userDefinedQueryParams = initializer.UserDefinedQueryParams;
        }

        /// <inheritdoc/>
        public override AuthorizationCodeRequestUrl CreateAuthorizationCodeRequest(string redirectUri)
        {
            return new GoogleAuthorizationCodeRequestUrl(new Uri(AuthorizationServerUrl))
            {
                ClientId = ClientSecrets.ClientId,
                Scope = string.Join(" ", Scopes),
                RedirectUri = redirectUri,
                IncludeGrantedScopes = IncludeGrantedScopes.HasValue
                    ? IncludeGrantedScopes.Value.ToString().ToLower() : null,
                LoginHint = LoginHint,
                Prompt = Prompt,
                Nonce = Nonce,
                UserDefinedQueryParams = UserDefinedQueryParams
            };
        }

        /// <inheritdoc/>
       

        /// <inheritdoc/>
        public override bool ShouldForceTokenRetrieval()
        {
            return IncludeGrantedScopes.HasValue && IncludeGrantedScopes.Value;
        }

        /// <summary>An initializer class for Google authorization code flow. </summary>
        public new class Initializer : AuthorizationCodeFlow.Initializer
        {
            /// <summary>
            /// The project ID associated with the credential using this flow.
            /// </summary>
            public string ProjectId { get; set; }

            /// <summary>Gets or sets the token revocation URL.</summary>
            public string RevokeTokenUrl { get; set; }

            /// <summary>
            /// Gets or sets the optional indicator for including granted scopes for incremental authorization.
            /// </summary>
            public bool? IncludeGrantedScopes { get; set; }

            /// <summary>Gets or sets the login_hint.</summary>
            public string LoginHint { get; set; }

            /// <summary>
            /// Gets or sets the prompt for consent behaviour.
            /// Value can be <c>null</c>, <c>"none"</c>, <c>"consent"</c>, or <c>"select_account"</c>.
            /// See <a href="https://developers.google.com/identity/protocols/OpenIDConnect#prompt">OpenIDConnect documentation</a>
            /// for details.
            /// </summary>
            public string Prompt { get; set; }

            /// <summary>Gets or sets the nonce.</summary>
            public string Nonce { get; set; }

            /// <summary>Gets or sets the optional user defined query parameters.</summary>
            public IEnumerable<KeyValuePair<string, string>> UserDefinedQueryParams { get; set; }

            /// <summary>
            /// Constructs a new initializer. Sets Authorization server URL to 
            /// <see cref="Google.Apis.Auth.OAuth2.GoogleAuthConsts.OidcAuthorizationUrl"/>, and Token server URL to 
            /// <see cref="Google.Apis.Auth.OAuth2.GoogleAuthConsts.OidcTokenUrl"/>.
            /// </summary>
            public Initializer() : this(
                GoogleAuthConsts.OidcAuthorizationUrl, GoogleAuthConsts.OidcTokenUrl, GoogleAuthConsts.RevokeTokenUrl)
            {
            }

            /// <summary>Constructs a new initializer.</summary>
            /// <param name="authorizationServerUrl">Authorization server URL</param>
            /// <param name="tokenServerUrl">Token server URL</param>
            /// <param name="revokeTokenUrl">Revocation server URL</param>
            /// <remarks>
            /// This is mainly for internal testing at Google, where we occasionally need
            /// to use alternative oauth endpoints. This is not for general use.
            /// </remarks>
            protected Initializer(string authorizationServerUrl, string tokenServerUrl, string revokeTokenUrl)
                : base(authorizationServerUrl, tokenServerUrl)
            {
                RevokeTokenUrl = revokeTokenUrl;
            }
        }
    }
}
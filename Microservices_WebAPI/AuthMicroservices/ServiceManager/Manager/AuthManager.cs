using Auth.JWT;
using Auth.JWT.Common;
using Auth.JWT.Model;
using DataAccess.IRepository;
using Microsoft.Extensions.Configuration;
using Model;
using ServiceManager.IManager;

namespace ServiceManager.Manager
{
    public class AuthManager : IAuthManager
    {
        private readonly IAuthRepository _authRepository;
        private readonly IConfiguration _configuration;
        private readonly JWTModule _module;
        private readonly TokenRequestModel _reqModel;
        public AuthManager(IAuthRepository authRepository, JWTModule module, TokenRequestModel reqModel, IConfiguration configuration)
        {
            this._authRepository = authRepository;
            this._configuration = configuration;
            this._module = module;
            this._reqModel = reqModel;
        }

        public TokenResponseModel CreateToken(AuthModel auth)
        {
            TokenResponseModel tokenResult = new TokenResponseModel();
            if (_authRepository.ValidateUser(auth))
            {
                string secrect = _configuration.GetSection("AuthJWT").GetSection("Secrect").Value;

                _reqModel.Issuer = "authjwt_team";
                _reqModel.ExpiryInSeconds = "18000";
                //Below fuction would create the token.
                tokenResult = _module.CreateToken(_reqModel, secrect, AlgorithmType.SHA256);
            }

            return tokenResult;
        }       
    }
}

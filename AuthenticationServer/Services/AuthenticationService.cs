using System.Security.Claims;
using AuthenticationServer.Models;
using AuthenticationServer.Repository;
using AuthServer.Entity;
using AuthServer.Models;
using AuthServer.Repository;
using AuthServer.Services.JwtTokenService;

namespace AuthenticationServer.Services
{
	public class AuthenticationService : IAuthenticationService
	{
        private readonly UserRepository repository;
        private readonly AccessTokenRepository tokenRepository;
        private readonly AccountVerificationRepository accountVerificationRepository;
        private readonly IEmailService emailService;

		public AuthenticationService(UserRepository _repository, AccountVerificationRepository _accountVerificationRepo, IEmailService _emailService, AccessTokenRepository _tokenRepo)
		{
            repository = _repository;
            accountVerificationRepository = _accountVerificationRepo;
            emailService = _emailService;
            tokenRepository = _tokenRepo;
		}

        

        public bool Login(AuthenticationModel model)
        {
            var user = repository.GetByEmail(model.Email);
            if( user != null && EncryptionService.Verify(model.Password, user.Password))
            {
                var token = JwtGenerator.CreateToken(model);
                AccessToken accessToken = new AccessToken(model.Email, token);
                tokenRepository.Add(accessToken);
                return true;
            }
            return false;
        }

        public bool Register(AuthenticationModel model)
        {
            try {
                model.Password = EncryptionService.Encrypt(model.Password);

                User user = new(model.Email, model.Password);

                var token = JwtGenerator.CreateToken(model);

                AccountVerification accountVerification = new AccountVerification(model.Email, token);

                repository.Add(user);
                accountVerificationRepository.Add(accountVerification);

                MailData mailData = new MailData();
                mailData.EmailToId = model.Email;
                mailData.EmailToName = model.Email;
                mailData.EmailToSubject = "Account Verification";
                mailData.VerificationURL = "https://localhost:7012/api/verifyaccount?token=" + token;

                emailService.SendEmail(mailData);

                return true;

            }catch(Exception e)
            {
                Console.WriteLine("Error while registering user: " + e);
                return false;
            }
        }

        public void VerifyAccount(string token)
        {
            JwtTokenModal decodedToken = JwtDecoder.DecodeJwt(token);
            string email = JwtDecoder.GetClaimValue(decodedToken, ClaimTypes.Email);
            AccountVerification account = accountVerificationRepository.GetActiveTokenByEmail(email);
            if(account.TokenValid && account.Token.Equals(token))
            {
                repository.ValidateUserByAccount(email);
                accountVerificationRepository.UpdateTokenStatusByEmail(email);
            }
        }
    }
}


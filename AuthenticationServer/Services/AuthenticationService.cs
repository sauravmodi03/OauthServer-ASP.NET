using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using AuthenticationServer.Models;
using AuthenticationServer.Repository;
using AuthServer.Dto;
using AuthServer.Entity;
using AuthServer.Models;
using AuthServer.Repository;
using AuthServer.Services.JwtTokenService;
using AuthServer.Utility;

namespace AuthenticationServer.Services
{
	public class AuthenticationService : IAuthenticationService
	{
        private readonly UserRepository userRepository;
        private readonly AccessTokenRepository tokenRepository;
        private readonly AccountVerificationRepository accountVerificationRepository;
        private readonly IEmailService emailService;

		public AuthenticationService(UserRepository _repository, AccountVerificationRepository _accountVerificationRepo, IEmailService _emailService, AccessTokenRepository _tokenRepo)
		{
            userRepository = _repository;
            accountVerificationRepository = _accountVerificationRepo;
            emailService = _emailService;
            tokenRepository = _tokenRepo;
		}

        public AuthResponseDto Login(string BasicEncodedAuth)
        {

            var logindto = GetLoginDto(BasicEncodedAuth);

            var user = userRepository.GetByEmail(logindto.Email);

            if( user != null && EncryptionService.Verify(logindto.Password, user.Password!))
            {
                var token = JwtGenerator.CreateToken(logindto.Email);
                AccessToken accessToken = new(logindto.Email, token);
                tokenRepository.Add(accessToken);
                return new AuthResponseDto(logindto.Email, token, "Success");
            }
            return new AuthResponseDto(logindto.Email, "", "Error");
        }

        public AuthResponseDto Register(UserDto dto)
        {
            try {

                if(userRepository.CheckUserExists(dto.Email))
                {
                    return new AuthResponseDto(dto.Email, "", "User already Exist.");
                }

                dto.Password = EncryptionService.Encrypt(dto.Password);
                var token = JwtGenerator.CreateToken(dto.Email);

                User user = new(dto);
                AccountVerification accountVerification = new(dto.Email, token);

                userRepository.Add(user);
                accountVerificationRepository.Add(accountVerification);

                SendEmail(dto, token);

            }catch(Exception e)
            {
                Console.WriteLine("Error while registering user: " + e);
            }

            return new AuthResponseDto(dto.Email, "", "Success");
        }

        public void VerifyAccount(string token)
        {
            JwtTokenModal decodedToken = JwtDecoder.DecodeJwt(token);
            string email = JwtDecoder.GetClaimValue(decodedToken, JwtRegisteredClaimNames.Aud);
            AccountVerification account = accountVerificationRepository.GetActiveTokenByEmail(email);
            if(account.TokenValid && account.Token.Equals(token))
            {
                userRepository.ValidateUserByAccount(email);
                accountVerificationRepository.UpdateTokenStatusByEmail(email);
            }
        }


        private LoginDto GetLoginDto(string encodedAuth)
        {
            var encoded = encodedAuth.Replace("Basic ", "");
            var decodedAuth = Base64Helper.DecodeBase64(encoded);
            var creds = decodedAuth.Split(":");
            LoginDto auth = new(creds[0], creds[1]);

            return auth;
        }

        private void SendEmail(UserDto dto, string token)
        {
            MailData mailData = new MailData();
            mailData.EmailToId = dto.Email;
            mailData.EmailToName = dto.Email;
            mailData.EmailToSubject = "Account Verification";
            mailData.VerificationURL = "https://localhost:7012/api/verifyaccount?token=" + token;
            emailService.SendEmail(mailData);
        }

    }
}


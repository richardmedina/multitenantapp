using Microsoft.Extensions.Logging;
using MultiTenantApi.Infrastructure.Mfa.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwoFactorAuthNet;
using TwoFactorAuthNet.Providers.Qr;

namespace MultiTenantApi.Infrastructure.Mfa
{
    public class MfaService : IMfaService
    {
        private readonly ILogger _logger;
        private string Issuer = "multitenantapp";

        public MfaService(ILogger<MfaService> logger)
        {
            _logger = logger;
        }

        public async Task<bool> ValidateCodeAsync(string secret, string code)
        {
            await Task.Yield();
            var twoFactorAuth = new TwoFactorAuth(Issuer, 6, 30, Algorithm.SHA256);
            var isValid = twoFactorAuth.VerifyCode(secret, code);
            return isValid;
        }

        public async Task<QrCodeData> GenerateQrCodeDataAsync(string userName, string secret)
        {
            await Task.Yield();
            var twoFactorAuth = new TwoFactorAuth(Issuer, 6, 30, Algorithm.SHA256, new ImageChartsQrCodeProvider());
            var ensuredSecret = secret = ensureValidSecret(twoFactorAuth, secret);

            var base64EncodedImage = twoFactorAuth.GetQrCodeImageAsDataUri(userName, ensuredSecret);

            var qrCodeText = twoFactorAuth.GetQrText(userName, secret);
            byte[] imageByteArray = convertBase64EncodedImageToByteArray(base64EncodedImage);

            return new QrCodeData
            {
                Secret = ensuredSecret,
                Text = qrCodeText,
                Base64EncodedImage = base64EncodedImage,
                ImageByteArray = imageByteArray
            };
        }

        private static byte[] convertBase64EncodedImageToByteArray(string base64EncodedImage)
        {
            var imgQr = base64EncodedImage.Replace("data:image/png;base64,", "");
            byte[] byteArray = Convert.FromBase64String(imgQr);
            return byteArray;
        }

        private string ensureValidSecret(TwoFactorAuth twoFactorAuth, string secret)
        {
            if (string.IsNullOrEmpty(secret))
            {
                return twoFactorAuth.CreateSecret(160);
            }

            return secret;
        }
    }
}

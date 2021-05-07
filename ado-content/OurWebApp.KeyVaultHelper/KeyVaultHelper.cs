using Microsoft.Azure.KeyVault;
using Microsoft.Azure.Services.AppAuthentication;
using System;

namespace OurWebApp.KeyVaultHelper
{
    public class KeyVaultHelper
    {
        public static string GetSecret(string vaultName, string key)
        {
            AzureServiceTokenProvider azureServiceTokenProvider = new AzureServiceTokenProvider();
            var keyVaultClient = new KeyVaultClient(new KeyVaultClient.AuthenticationCallback(azureServiceTokenProvider.KeyVaultTokenCallback));

            return keyVaultClient.GetSecretAsync("https://" + vaultName + ".vault.azure.net/secrets/" + key).Result.Value;
        }
    }
}

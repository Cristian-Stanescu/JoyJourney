
using Azure.Identity;

namespace JoyJourney.Services;
public class AppAzureCredential : DefaultAzureCredential
{
    private static readonly AppAzureCredential _instance = new();
    private static readonly DefaultAzureCredentialOptions _options = new()
    {
        ExcludeEnvironmentCredential = true,
        ExcludeManagedIdentityCredential = true,
        ExcludeSharedTokenCacheCredential = true,
        ExcludeVisualStudioCodeCredential = true,
        ExcludeAzureDeveloperCliCredential = true,
        ExcludeAzurePowerShellCredential = true,
        ExcludeInteractiveBrowserCredential = true
    };

    public static AppAzureCredential Instance => _instance;

    private AppAzureCredential() : base(_options)
    {
    }
}

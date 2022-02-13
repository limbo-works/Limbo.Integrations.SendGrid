# Limbo.Integrations.SendGrid

.NET wrapper for the SendGrid API.

## Installation

The package is only available via [NuGet](https://www.nuget.org/packages/Limbo.Integrations.SendGrid/1.0.0-beta001). To install the package, you can use either .NET CLI:

```
dotnet add package Limbo.Integrations.SendGrid --version 1.0.0-beta001
```

or the older NuGet Package Manager:

```
Install-Package Limbo.Integrations.SendGrid -Version 1.0.0-beta001
```

# Examples

## Initializing a new HTTP service

The `SendGridHttpService` is the entry class for accessing the SendGrid API. Access to the API requires an API key, so you can get a new instance of the `SendGridHttpService` class like this:

```cshtml
@using Limbo.Integrations.SendGrid
@{

    // Initialize a new HTTP service based on your API key
    SendGridHttpService service = SendGridHttpService.CreateFromApiKey("Your API key");

}
```








## Request a list of all API keys

It's recommended to set up one or more API keys to access your SendGrid account. You can get a list of all existing API keys of the authenticated user like in the example below.

Notice that the API doesn't return the actual API key, but only the ID and name of each API key.

```cshtml
@using Limbo.Integrations.SendGrid
@using Limbo.Integrations.SendGrid.Models.ApiKeys
@using Limbo.Integrations.SendGrid.Responses.ApiKeys

@inherits WebViewPage<SendGridHttpService>

@{

    // Make the request to the API
    SendGridApiKeyListResponse response = Model.ApiKeys.GetApiKeys();

    // Get the API keys from the response body
    SendGridApiKeyItem[] apiKeys = response.Body.Result;

    // Write out the amount of API keys returned
    <p>Found <strong>@apiKeys.Length</strong> API keys</p>

    // Iterate through the API keys
    foreach (SendGridApiKeyItem apiKey in apiKeys) {
        <hr />
        <p>ID: @apiKey.ApiKeyId</p>
        <p>Name: @apiKey.Name</p>
    }

}
```





## Request a specific API key

With the ID of a given API key, you can also request information about the API key specifically. When doing so, the returned `SendGridApiKey` will also contain a list of the scopes granted to the API key (`SendGridApiKeyItem` in the list based response doesn't have this information).

```cshtml
@using Limbo.Integrations.SendGrid
@using Limbo.Integrations.SendGrid.Models.ApiKeys
@using Limbo.Integrations.SendGrid.Responses.ApiKeys

@inherits WebViewPage<SendGridHttpService>

@{

    // Make the request to the API
    SendGridApiKeyResponse response = Model.ApiKeys.GetApiKey("a6lE6VFHGwL89g0kvoXcv8");

    // Get the API key from the response body
    SendGridApiKey apiKey = response.Body;

    <p>ID: @apiKey.ApiKeyId</p>
    <p>Name: @apiKey.Name</p>
    <p>Scopes: @string.Join(", ", apiKey.Scopes)</p>

}
```







## Request a list of allowed IP addresses

You may set up your SendGrid account to require IP adresses to be allow before they can access the account. When enabled, you can add new IP addresses to your accounts allow list (generally referred to as whitelist at the API level), and subsequently request a list of allowed IP addresses like in the example below:

```cshtml
@using Limbo.Integrations.SendGrid
@using Limbo.Integrations.SendGrid.Models.AccessSettings
@using Limbo.Integrations.SendGrid.Responses.AccessSettings

@inherits WebViewPage<SendGridHttpService>

@{

    // Make the request to the API
    SendGridWhitelistResponse response = Model.AccessSettings.GetWhitelist();

    // Get the API keys from the response body
    SendGridWhitelistRule[] rules = response.Body.Result;

    // Write out the amount of rules returned
    <p>Found <strong>@rules.Length</strong> whitelist rules</p>

    // Iterate through the rules
    foreach (SendGridWhitelistRule rule in rules) {
        <hr />
        <p>ID: @rule.Id</p>
        <p>IP: @rule.Ip</p>
        <p>Created at: @rule.CreatedAt</p>
        <p>Updated at: @rule.UpdatedAt</p>
    }

}
```



## Request a list of recent access attempts

```cshtml
@using Limbo.Integrations.SendGrid
@using Limbo.Integrations.SendGrid.Models.AccessSettings
@using Limbo.Integrations.SendGrid.Responses.AccessSettings

@inherits WebViewPage<SendGridHttpService>

@{

    // Make the request to the API
    SendGridAccessAttemptListResponse response = Model.AccessSettings.GetRecentAccessAttempts();

    // Get the access attempts from the response body
    IList<SendGridAccessAttempt> attempts = response.Body.Result;

    // Write out the amount of access attempts returned
    <p>Found <strong>@attempts.Count</strong> recent access attempts</p>

    // Iterate through the rules
    foreach (SendGridAccessAttempt attempt in attempts) {
        <hr />
        <p>IP address: @attempt.Ip</p>
        <p>Is allowed: @attempt.IsAllowed</p>
        <p>Auth method: @attempt.AuthMethod</p>
        <p>First seen: @attempt.FirstAt</p>
        <p>Last seen: @attempt.LastAt</p>
        <p>Location: @attempt.Location</p>
    }

}
```

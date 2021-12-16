# Enable.Exceptionless.Extensions

Reusable extensions for the Exceptionless client library.

---

## Hosting extensions example

### Project.csproj

```xml
<PackageReference Include="Enable.Exceptionless.Extensions.Hosting" Version="1.0.0" />
```

### Program.cs

```c#
private static async Task Main(string[] args)
{
    var builder = new HostBuilder()
        .ConfigureAppConfiguration(config => config.AddJsonFile("appsettings.json"))
        .ConfigureServices((host, services) => services.AddExceptionless(host.Configuration.GetSection("Exceptionless")));

    using (var host = builder.Build())
    {
        await host.RunAsync();
    }
}
```

### appsettings.json

```json
{
    "Exceptionless": {
        "ApiKey": "???",
        "Enabled": true,
        "ServerUrl": "https://collector.exceptionless.io"
    }
}
```


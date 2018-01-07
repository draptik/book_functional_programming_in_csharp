## Initial setup

```
cd chapter04
dotnet new xunit -o Scratch
cd Scratch
dotnet new sln
dotnet sln add Scratch.csproj
dotnet restore
```

## Testing

```
cd chapter04/Scratch
dotnet test
```

## Test watcher: dotnet watch

See https://docs.microsoft.com/en-us/aspnet/core/tutorials/dotnet-watch for details.

Add the following line to the `csproj` file:

```xml
<DotNetCliToolReference Include="Microsoft.DotNet.Watcher.Tools" Version="2.0.0" />
```

Running watcher:

```
dotnet watch test
```

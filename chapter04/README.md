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

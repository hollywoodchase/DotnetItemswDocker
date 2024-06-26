# Use the latest .NET 8.0 SDK image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["RazorPagesApp.csproj", ""]
RUN dotnet restore "./RazorPagesApp.csproj"
COPY . .
WORKDIR "/src/"
RUN dotnet build "RazorPagesApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RazorPagesApp.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RazorPagesApp.dll"]

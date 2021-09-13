FROM mcr.microsoft.com/dotnet/aspnet:5.0

ENV ASPNETCORE_ENVIRONMENT="${EnvironmentName}"
ARG TARGET_VERSION
ARG source
WORKDIR /app
COPY . /app

CMD ["dotnet", "AspNetCoreSpa.IdentityServer.dll"]
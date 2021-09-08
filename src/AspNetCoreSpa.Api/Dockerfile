FROM mcr.microsoft.com/dotnet/aspnet:5.0

LABEL org.label-schema.vcs-url="https://git.vpgrp.io/supply-chain/lni"
LABEL org.label-schema.vendor="vp.dsi.supply"
LABEL org.label-schema.name="lni"

ENV ASPNETCORE_ENVIRONMENT="${EnvironmentName}"
ARG TARGET_VERSION
ARG source
WORKDIR /app
COPY . /app

CMD ["dotnet", "AspNetCoreSpa.Api.dll"]
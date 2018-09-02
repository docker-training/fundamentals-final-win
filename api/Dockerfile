# escape=`
FROM microsoft/dotnet-framework:4.7.1-sdk AS build-env
SHELL ["powershell", "-Command", "$ErrorActionPreference = 'Stop'; $ProgressPreference = 'SilentlyContinue';"]
WORKDIR /sln/api

# Steps required to build .NET Framework app
COPY *.csproj ./
COPY packages.config ./
RUN nuget restore -PackagesDirectory /sln/packages -Verbosity Detailed -NonInteractive

# project has dependency on Microsoft.ApplicationInsights.Web, Newtonsoft.Json, Antlr3.Runtime packages.
RUN nuget install Microsoft.ApplicationInsights.Web -Version 2.2.0 -OutputDirectory /sln/packages; `
    nuget install Newtonsoft.Json -Version 6.0.4 -OutputDirectory /sln/packages; `
    nuget install Antlr -Version 3.4.1.9004 -OutputDirectory /sln/packages;

# Copy everything else and build
COPY . ./
RUN msbuild /p:Configuration=Release

FROM microsoft/aspnet:4.7.1
WORKDIR /inetpub/wwwroot
COPY --from=build-env /sln/api .
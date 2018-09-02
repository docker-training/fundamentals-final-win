# escape=`
FROM microsoft/dotnet-framework:4.7.1-sdk AS build-env
SHELL ["powershell", "-Command", "$ErrorActionPreference = 'Stop'; $ProgressPreference = 'SilentlyContinue';"]

WORKDIR /sln/api

# Steps required to build .NET Framework app
# Copy csproj and restore as distinct layers
#COPY ../*.sln .
COPY *.csproj ./
COPY packages.config ./
RUN nuget restore -PackagesDirectory /sln/packages -Verbosity Detailed -NonInteractive

# project has dependency on Microsoft.ApplicationInsights.Web, Newtonsoft.Json, Antlr3.Runtime packages.
RUN nuget install Microsoft.ApplicationInsights.Web -Version 2.2.0 -OutputDirectory /sln/packages; `
    nuget install Newtonsoft.Json -Version 6.0.4 -OutputDirectory /sln/packages; `
    nuget install Antlr -Version 3.4.1.9004 -OutputDirectory /sln/packages;

#RUN echo "[DEBUG]"; ls; ls /sln; ls /sln/packages;


# Copy everything else and build
COPY . ./
RUN msbuild /p:Configuration=Release
#RUN echo "[DEBUG]"; ls /sln/api/bin; ls /sln/api/obj/Release

# install Microsoft.AI dependencies. this would require packageSource configuration.
#RUN Install-Package Microsoft.ApplicationInsights.Web


FROM microsoft/aspnet:4.7.1
WORKDIR /inetpub/wwwroot
#ARG site_root=.
#ADD ${site_root} /inetpub/wwwroot
COPY --from=build-env /sln/api .

#RUN echo "Contents of workdir"; ls;

# docker build -t api .
# docker run -d -p 8000:80 api
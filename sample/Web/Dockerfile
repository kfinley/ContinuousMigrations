FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
ARG buildconfig
ENV DOCKERIZE_VERSION v0.6.1
EXPOSE 80

WORKDIR /app

RUN if [ "${buildconfig}" = "Debug" ]; then \
        apt-get update && apt-get -y install wget procps && \
        wget https://github.com/jwilder/dockerize/releases/download/$DOCKERIZE_VERSION/dockerize-alpine-linux-amd64-$DOCKERIZE_VERSION.tar.gz && \
        tar -C /usr/local/bin -xzvf dockerize-alpine-linux-amd64-$DOCKERIZE_VERSION.tar.gz && \
        rm dockerize-alpine-linux-amd64-$DOCKERIZE_VERSION.tar.gz; \
        # To skip downloading the command line debugger run the following and uncomment the volume in docker-compose.debug.yml
        # curl -sSL https://aka.ms/getvsdbgsh | bash /dev/stdin -v latest -l ~/vsdbg-linux-64 -r linux-64
        apt-get update; \
        apt-get install -y --no-install-recommends apt-utils && \
        apt-get install curl unzip -y && \
        curl -sSL https://aka.ms/getvsdbgsh | bash /dev/stdin -v latest -l /vsdbg; \
    fi

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS publish
ARG buildconfig
WORKDIR /src

COPY . ./

WORKDIR /src/sample/Web

RUN if [ "${buildconfig}" = "Debug" ]; then \
        dotnet publish -o /publish -c Debug; \
    else \
        dotnet publish -o /publish -c Release; \
    fi

FROM base AS final
WORKDIR /app

COPY --from=publish /publish .

CMD ["dotnet", "Web.dll"]
#ENTRYPOINT ["dotnet", "Web.dll"]

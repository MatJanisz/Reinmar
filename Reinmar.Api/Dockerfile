
FROM microsoft/dotnet:2.1-sdk as builder

COPY ./src/Reinmar.Infrastructure/. /source/Reinmar.Infrastructure/
COPY ./src/Reinmar.Api/. /source/Reinmar.Api/

WORKDIR /source/Reinmar.Api

RUN dotnet publish -o ../artifacts

FROM microsoft/dotnet:2.1-aspnetcore-runtime

COPY --from=builder /source/artifacts/. app/

ENV ASPNETCORE_URLS="http://+:5000"

WORKDIR /app

ENTRYPOINT dotnet Reinmar.Api.dll
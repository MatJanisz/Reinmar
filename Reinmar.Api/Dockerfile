
FROM microsoft/dotnet:2.1-sdk as builder

COPY ./src/Reinmar.DA/. /source/Reinmar.DA/
COPY ./src/Reinmar.BL/. /source/Reinmar.BL/
COPY ./src/Reinmar.Api/. /source/Reinmar.Api/

WORKDIR /source/Reinmar.Api

RUN dotnet publish -o ../artifacts

FROM microsoft/dotnet:2.1-aspnetcore-runtime

COPY --from=builder /source/artifacts/. app/

ENV ASPNETCORE_URLS="http://+:5000"

WORKDIR /app

ENTRYPOINT dotnet Reinmar.Api.dll
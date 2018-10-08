FROM microsoft/dotnet:2.1.403-sdk-alpine3.7 AS buildimg
WORKDIR /app
COPY . .
RUN dotnet restore
RUN dotnet build
WORKDIR /app/src/Travis-CI.Api
RUN dotnet publish -c  Release -o output

FROM microsoft/dotnet:2.1.5-aspnetcore-runtime-alpine3.7
WORKDIR output
COPY --from=buildimg /app/src/Travis-CI.Api/output .
ENTRYPOINT ["dotnet","Travis-CI.Api.dll"]

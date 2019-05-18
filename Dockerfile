FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY . .
WORKDIR /src/EduNote.API
RUN dotnet restore
RUN dotnet build --no-restore -c Release -o /app

FROM build AS publish
RUN dotnet publish --no-restore -c Release -o /app

FROM base AS final
WORKDIR /app
COPY ./appsettings.json.prod /app/appsettings.json
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "EduNote.API.dll"]
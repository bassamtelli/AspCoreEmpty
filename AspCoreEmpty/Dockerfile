FROM microsoft/aspnetcore:2.1-sdk AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.1-sdk AS build
WORKDIR /src
COPY AspCoreEmpty.sln ./
COPY AspCoreEmpty/AspCoreEmpty.csproj AspCoreEmpty/
RUN dotnet restore -nowarn:msb3202,nu1503
COPY . .
WORKDIR /src/AspCoreEmpty
RUN dotnet build -c Release -o /app

FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "AspCoreEmpty.dll"]
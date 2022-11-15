FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["UsefulLinksDuringWarUa/UsefulLinksDuringWarUa.csproj", "UsefulLinksDuringWarUa/"]
RUN dotnet restore "UsefulLinksDuringWarUa/UsefulLinksDuringWarUa.csproj"
COPY . .
WORKDIR "/src/UsefulLinksDuringWarUa"
RUN dotnet build "UsefulLinksDuringWarUa.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "UsefulLinksDuringWarUa.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "UsefulLinksDuringWarUa.dll"]

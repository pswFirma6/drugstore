FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY . .
RUN dotnet restore "Pharmacy/Pharmacy.csproj"

WORKDIR /src
COPY . .
RUN dotnet build "Pharmacy/Pharmacy.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Pharmacy/Pharmacy.csproj" -c Release -o /app/publish

FROM base AS final
RUN useradd -u 1234 nonrootuser
USER nonrootuser
WORKDIR /app
COPY --from=publish /app/publish .
EXPOSE 80
ENV PORT 80
CMD ASPNETCORE_URLS=http://*:$PORT dotnet Pharmacy.dll
ENTRYPOINT ["dotnet", "Pharmacy.dll"]

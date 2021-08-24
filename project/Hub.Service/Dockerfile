FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build-env
WORKDIR /app

# Copy everything and build
COPY . ./

RUN dotnet restore "./Hub.Service.csproj"
RUN dotnet publish "Hub.Service.csproj" -c Release -o out
FROM microsoft/dotnet:aspnetcore-runtime
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "Hub.Service.dll"]
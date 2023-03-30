FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env

WORKDIR /src
COPY ["Foosball.FSharp.API/Foosball.FSharp.API.fsproj", "Foosball.FSharp.API/"]
RUN dotnet restore "Foosball.FSharp.API/Foosball.FSharp.API.fsproj"

# Copy everything
COPY . .

# Build and publish a release
RUN dotnet publish "Foosball.FSharp.API/Foosball.FSharp.API.fsproj" -c Release -o /app -p:UseAppHost=false

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
COPY --from=build-env /app .

ENV DOTNET_EnableDiagnostics=0 

ENTRYPOINT ["dotnet", "Foosball.FSharp.API.dll"]

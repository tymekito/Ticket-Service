# Use the official .NET image as the base image
FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 44365

# Use the SDK image to build the application
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["TicketsAPI/TicketsAPI.csproj", "TicketsAPI/"]
RUN dotnet restore "TicketsAPI/TicketsAPI.csproj"
COPY TicketsAPI/. TicketsAPI/
WORKDIR "/src/TicketsAPI"
RUN dotnet build "TicketsAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TicketsAPI.csproj" -c Release -o /app/publish

# Create the final image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TicketsAPI.dll"]

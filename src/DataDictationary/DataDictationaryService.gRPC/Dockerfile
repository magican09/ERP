FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/DataDictationary/DataDictationary.gRPC/DataDictationary.gRPC.csproj", "src/DataDictationary/DataDictationary.gRPC/"]
RUN dotnet restore "src/DataDictationary/DataDictationary.gRPC/DataDictationary.gRPC.csproj"
COPY . .
WORKDIR "/src/src/DataDictationary/DataDictationary.gRPC"
RUN dotnet build "DataDictationary.gRPC.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "DataDictationary.gRPC.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DataDictationary.gRPC.dll"]

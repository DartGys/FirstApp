FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["TaskBoard.WebAPI/TaskBoard.WebAPI.csproj", "TaskBoard.WebAPI/"]
COPY ["TaskBoard.BLL/TaskBoard.BLL.csproj", "TaskBoard.BLL/"]
COPY ["TaskBoard.DAL/TaskBoard.DAL.csproj", "TaskBoard.DAL/"]
RUN dotnet restore "TaskBoard.WebAPI/TaskBoard.WebAPI.csproj"
COPY . .
WORKDIR "/src/TaskBoard.WebAPI"
RUN dotnet build "TaskBoard.WebAPI.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "TaskBoard.WebAPI.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TaskBoard.WebAPI.dll"]

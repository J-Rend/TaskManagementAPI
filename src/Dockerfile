# Etapa base de runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# Etapa de build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copia apenas o projeto e restaura dependências
COPY ["TaskManagement.Api/TaskManagement.Api.csproj", "TaskManagement.Api/"]
RUN dotnet restore "TaskManagement.Api/TaskManagement.Api.csproj"

# Copia todo o código-fonte
COPY . .

WORKDIR "/src/TaskManagement.Api"
RUN dotnet build "TaskManagement.Api.csproj" -c Release -o /app/build

# Etapa de publicação
FROM build AS publish
RUN dotnet publish "TaskManagement.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Etapa final (imagem leve de runtime)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TaskManagement.Api.dll"]

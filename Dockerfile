FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /app

COPY TaskList/TaskList.sln ./
COPY TaskList/TaskList.API.csproj ./TaskList/
COPY TaskList.Data/TaskList.Data.csproj ./TaskList.Data/
COPY TaskList.Services/TaskList.Services.csproj ./TaskList.Services/

RUN dotnet restore "./TaskList/"
RUN dotnet restore "./TaskList.Data/"
RUN dotnet restore "./TaskList.Services/"

COPY . .

RUN dotnet publish "./TaskList/TaskList.API.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app

COPY --from=build-env /app/publish .

FROM mcr.microsoft.com/dotnet/sdk:6.0
WORKDIR /app

COPY --from=build-env /app/publish .
COPY --from=build-env /app/TaskList.Data ./TaskList.Data
COPY --from=build-env /app/TaskList ./TaskList
COPY --from=build-env /app/TaskList.Services ./TaskList.Services
COPY --from=build-env /app/TaskList.Services.Test ./TaskList.Services.Test

RUN dotnet restore "/app/TaskList/TaskList.sln"

RUN dotnet tool install --version 6.0.35 --global dotnet-ef
ENV PATH="$PATH:/root/.dotnet/tools"

EXPOSE 80

CMD ["dotnet", "TaskList.API.dll"]

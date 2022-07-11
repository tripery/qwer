FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["MatrixDemo/MatrixDemo.csproj", "MatrixDemo/"]
RUN dotnet restore "MatrixDemo/MatrixDemo.csproj"
COPY . .
WORKDIR "/src/MatrixDemo"
RUN dotnet build "MatrixDemo.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MatrixDemo.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MatrixDemo.dll"]

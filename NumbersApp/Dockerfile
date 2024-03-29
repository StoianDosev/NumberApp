FROM mcr.microsoft.com/dotnet/aspnet:5.0-focal AS base
WORKDIR /app
EXPOSE 8000

ENV ASPNETCORE_URLS=http://+:8000

# Creates a non-root user with an explicit UID and adds permission to access the /app folder
# For more info, please refer to https://aka.ms/vscode-docker-dotnet-configure-containers
RUN adduser -u 5678 --disabled-password --gecos "" appuser && chown -R appuser /app
USER appuser

FROM mcr.microsoft.com/dotnet/sdk:5.0-focal AS build
WORKDIR /src
COPY ["NumbersApp/NumbersApp.csproj", "NumbersApp/"]
RUN dotnet restore "NumbersApp/NumbersApp.csproj"
COPY . .
WORKDIR "/src/NumbersApp"
RUN dotnet build "NumbersApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "NumbersApp.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NumbersApp.dll"]

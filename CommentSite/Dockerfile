# Build stage
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY . .
WORKDIR /src/CommentSite
RUN dotnet restore "CommentSite.csproj"
RUN dotnet build "CommentSite.csproj" -c Release -o /app/build
RUN dotnet publish "CommentSite.csproj" -c Release -o /app/publish

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "CommentSite.dll"]

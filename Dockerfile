FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /source

COPY . .
RUN dotnet restore "./LibraryAPI.sln"
RUN dotnet publish "./LibraryAPI.sln" -c release -o /app --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
COPY --from=build /app ./

EXPOSE 5000
ENV ServicePort 5000
ENV ASPNETCORE_ENVIRONMENT Docker
ENTRYPOINT ["dotnet", "Library.Web.dll", "--launch-profile", "Docker"]
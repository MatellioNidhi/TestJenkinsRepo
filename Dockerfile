FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
# copy csproj and restore as distinct layers
COPY */*.csproj ./
RUN for file in $(ls *.csproj); do mkdir -p ${file%.*}/ && mv $file ${file%.*}/; done

RUN echo "<configuration><packageSources><add key=\"LocalNuget\" value=\"http://192.168.103.142:8081/nuget\" /></packageSources></configuration>" > nuget.config
RUN dotnet restore DashboardService.API/DashboardService.API.csproj
COPY . .

RUN dotnet publish DashboardService.API/DashboardService.API.csproj -c Release -o /app

#Build runtime image
FROM base AS final
WORKDIR /app
COPY --from=build /app .
EXPOSE 8080/tcp
ENTRYPOINT ["dotnet", "DashboardService.API.dll"]

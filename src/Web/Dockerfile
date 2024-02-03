FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /source

COPY . ./src/Web/
WORKDIR /source/src/Web
RUN dotnet publish -c release -o /app

FROM mcr.microsoft.com/dotnet/aspnet:8.0
#Create a user in containser to improve security
RUN groupadd -r app_user && useradd -r -g app_user app_user
USER app_user

WORKDIR /home/app_user/app
COPY --from=build /app /home/app_user/app/

HEALTHCHECK --interval=30s --timeout=30s --start-period=5s --retries=3 CMD [ "curl --fail http://localhost:8080 || exit 1" ]

#Expose port 80
#This is important in order for the Azure App Service to pick up the app
ENV PORT 8080
EXPOSE 8080

#Start the app
ENTRYPOINT [ "dotnet", "Web.dll" ]
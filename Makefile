# Project Variables
PROJECT_NAME ?= SolarCoffee
ORG_NAME ?= SolarCoffee
REPO_NAME ?= SolarCoffee

.PHONY: migrations db

migrations: 
    CD ./SolarCoffee.Data && DOTNET dotnet-ef -s ../SolarCoffee.Web/ Migrations Add $(mname) && CD ..

db:
    CD ./SolarCoffee.Data && DOTNET dotnet-ef -s ../SolarCoffee.Web/ Database Update && CD ..
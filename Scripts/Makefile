######## Requirements. Command 'make' needs to be installed.

# Install Chocolately, a Package Manager for Windows, to get 'make' command available (can be omitted if make exists already).
# https://chocolatey.org/install

# Then, install 'make' command via Chocolately.
# choco install make

######## Variables Definition.

Port := 5432
ContainerName := PostgreSQL
ServiceName := com.docker.service
PSQLImage := postgres:latest

UserName := solardev
CommandPath := psql
PostgresUser := postgres
DatabaseName := solardev
CreateFile := Create.sql
InsertFile := Insert.sql
PSQLPath := /var/opt/scripts/
EnvFile := .env

FrontendProject := ../solarcoffee.frontend
StartupProject := ../SolarCoffee.Web
DataAccessProject := ../SolarCoffee.Data
ScriptFolder := ./DB

# Definition: Get Arguments, after getting first command.
RUN_ARGS := $(wordlist 2, $(words $(MAKECMDGOALS)),$(MAKECMDGOALS))

# Commands Definition:
# % = Rule that will match any task name.
# @ = Argument data.
# %:
# 	@ECHO Command not found, using as Argument: "$(@)".

commands:
	@ECHO === Solution shortcuts available ===
	@ECHO start: Starting steps.
	@ECHO vue_run: Run Vue Frontend.
	@ECHO dotnet_run: Quick reload for $(StartupProject) project.
	
	@ECHO === DOCKER shortcuts available ===
	@ECHO docker_desktop: Start Docker Desktop.
	@ECHO docker_start: Start Container.
	@ECHO docker_run: Create an specific Container.
	@ECHO docker_psql: Download Docker PostgreSQL image.
	
	@ECHO === Postgres shortcuts available ===
	@ECHO psql_query: Execute SQL commands, if provided, then get into SQL cmd.
	@ECHO psql_insert: Insert mock data.
	@ECHO psql_create: Create DB and user.

	@ECHO === Entity Frameworks shortcuts available ===
	@ECHO ef_install: Install Entity Framework tool.
	@ECHO ef_drop: Drop DB.
	@ECHO ef_update: Update DB based on latest defined Migrations.
	@ECHO ef_add: Create new Migration with latest changes, require an argument to be used as Migration Name.

######## Solution commands execution.
start: docker_run start_psql
start_psql: psql_create ef_update psql_insert

# Execute 2 jobs concurrently.
dev: 
	make -j 2 vue_run dotnet_run

vue_run:
	@ECHO ######## Running Vue. 
	CD $(FrontendProject) && NPM run serve

dotnet_run:
	@ECHO ######## Run Dotnet Project.
	DOTNET run --project $(StartupProject) --launch-profile SolarCoffee.Web

######## Docker commands execution.

docker_desktop:
	@ECHO ######## Start Docker Desktop.
	DOCKER desktop start

docker_start: docker_desktop
	@ECHO ######## Start Container.
	DOCKER start $(ContainerName)

docker_run: docker_desktop
	@ECHO ######## Create Container based on image.
	DOCKER rm -f $(ContainerName)
# PG_Password it's required as environment variable.
	DOCKER run -d -p $(Port):$(Port) --name $(ContainerName) --env-file $(EnvFile) $(PSQLImage)
	docker exec -t $(ContainerName) bash -c "until psql -U $(PostgresUser) -c 'select 1'>/dev/null 2>&1; \
			do\
				echo 'Waiting Postgres server....';\
				sleep 1;\
				done;\
			exit;\
		"
		echo DB ready

docker_psql:
	@ECHO ######## Download Postgres Image.
	DOCKER pull $(PSQLImage)

######## Postgres commands execution. 
psql_query:
# Input example: 'SELECT * FROM \"Products\";'
	@ECHO ######## Connect to PSQL and execute query if arguments provided.
	DOCKER exec -t $(ContainerName) $(CommandPath) -U $(UserName) -d $(DatabaseName) -c '$(RUN_ARGS)'
	
psql_insert:
	@ECHO ######## Inserting mock data.
	DOCKER exec $(ContainerName) mkdir -p $(PSQLPath)
	DOCKER cp "$(ScriptFolder)/$(InsertFile)" "$(ContainerName):$(PSQLPath)$(InsertFile)"
	DOCKER exec -t $(ContainerName) $(CommandPath) -U $(UserName) -d $(DatabaseName) -f "$(PSQLPath)$(InsertFile)"

psql_create:
	@ECHO ######## Creating DB.
	DOCKER exec $(ContainerName) mkdir -p $(PSQLPath)
	DOCKER cp "$(ScriptFolder)/$(CreateFile)" "$(ContainerName):$(PSQLPath)$(CreateFile)"
	DOCKER exec -t $(ContainerName) $(CommandPath) -U $(PostgresUser) -f "$(PSQLPath)$(CreateFile)"

######## Entity Framework commands execution.
ef_install:
	@ECHO ######## Installing Dotnet Entity Framework.
	DOTNET new tool-manifest --force
	DOTNET tool install dotnet-ef

ef_update: ef_install
	@ECHO ######## Update Database based on Migrations.
	DOTNET dotnet-ef Database Update --project $(DataAccessProject) -s $(StartupProject)

ef_drop: ef_install
	@ECHO ######## Drop DB.
	DOTNET dotnet-ef Database Drop -f --project $(DataAccessProject) -s $(StartupProject)

ef_add: ef_install
	@ECHO ######## Add Migrations.
	DOTNET dotnet-ef Migrations Add $(RUN_ARGS) --project $(DataAccessProject) -s $(StartupProject)
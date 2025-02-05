-- REMOVE Warning Messages. Example: "NOTICE: database|role 'name' does not exist, skipping".
SELECT set_config('client_min_messages', 'warning', false);

--DROP OWNED, DB & USER IF ALREADY EXISTS.
DROP OWNED BY solardev;
DROP DATABASE IF EXISTS solardev;
DROP USER IF EXISTS solardev;

-- CREATE USER, DATABASE & GRANT PRIVILEGES WITH JUST CREATED USER & DATABASE.
CREATE USER solardev with PASSWORD 'solar123';
CREATE DATABASE solardev;
GRANT ALL PRIVILEGES ON DATABASE solardev TO solardev;

\c solardev postgres
-- You are now connected to database "solardev" as user "postgres".
GRANT ALL ON SCHEMA public TO solardev;
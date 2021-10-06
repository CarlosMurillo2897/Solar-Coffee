-- REMOVE Warning Messages. Example: "NOTICE: database|role 'name' does not exist, skipping".
SELECT set_config('client_min_messages', 'warning', false);

--DROP DB & USER IF ALREADY EXISTS.
DROP DATABASE IF EXISTS solardev;
DROP USER IF EXISTS solardev;

-- CREATE USER, DATABASE & GRANT PRIVILEGES WITH JUST CREATED USER & DATABASE.
CREATE USER solardev with PASSWORD 'solar123';
CREATE DATABASE solardev;
GRANT ALL PRIVILEGES ON DATABASE solardev TO solardev;
### .Net 5.0 API using Mongo DB and Docker Compose

**Prerequisites:**
- [Docker Desktop](https://www.docker.com/products/docker-desktop)
- .Net 5
- Mongo DB Driver
- [Robo 3T: the hobbyist GUI](https://robomongo.org/download) (optional)


**How to setup:**

- Clone the repo locally.
- Using a console (powershell, bash etc) cd into the project folder
- run the command `docker-compose up`
- This will spin up two separate containers. One for the Mongo database and another for the .Net 5.0 API.  
- You can access the api on http://localhost:5000/
- The Mongo DB runs off http://localhost:27017.  
- The docker compose uses volumes to auto create a database called ProductsDB with one collection called Products by running the [/db/init_db.sh](project/db/init_db.sh) script once the container starts up.
- This script will use the data in [db.json](project/db/dump/db.json) to populate the Products collection.
- You can use a tool such as [Robo 3T: the hobbyist GUI](https://robomongo.org/download) to connect to the DB and manage the database and collections.


**How to test:**

- The API uses Open API V3 Swagger integration.  You can browse and test endpoints here: http://localhost:5000/swagger/index.html

**Useful command:**

- `docker exec -it <containername> bash` - allows you to run commands in the containers. See [here](https://docs.docker.com/engine/reference/commandline/exec/) for more info.


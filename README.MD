### .Net 5.0 API using Mongo DB and Docker Compose

**Based on this tutorial:**
https://medium.com/@kristaps.strals/docker-mongodb-net-core-a-good-time-e21f1acb4b7b


**Prerequisites:**
- [Docker Desktop](https://www.docker.com/products/docker-desktop)
- [Robo 3T: the hobbyist GUI](https://robomongo.org/download)
- Also useful to use Postman to test


**How to setup:**

- Clone the repo locally.
- Using a console (powershell, bash etc) cd into the project folder
  - run the command `docker-compose up`
- This will spin up two separate containers. One for the Mongo database and another for the .Net 5.0 API.  You can access the api on http://localhost:5000/
- The Mongo DB runs off http://localhost:27017.  You can use a tool such as [Robo 3T: the hobbyist GUI](https://robomongo.org/download) to connect to the DB and manage the database and collections.

**How to test:**

- The API uses Open API V3 Swagger integration.  You can browse and test endpoints here: http://localhost:5000/swagger/index.html


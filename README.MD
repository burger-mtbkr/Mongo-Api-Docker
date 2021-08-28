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
___

**Pushing to Docker Hub Repo:**

If you want to push this to your own Docker Hub repository: you can follow these steps:

1. You may need log out first `docker logout` then log back in using `docker login`.
2. You need to include the namespace for Docker Hub to associate it with your account.  The namespace is the same as your Docker Hub account name.
3. If your image does not include your account name, you can rename it by tagging it. You can do this using `docker tag SOURCE_IMAGE[:TAG] TARGET_IMAGE[:TAG]`. e.g. `docker tag dotnet-mongo-docker YOUR_DOCKERHUB_NAME/dotnet-mongo-docker:tag`.
4. You can then push your image by running this command: `docker push YOUR_DOCKERHUB_NAME/dotnet-mongo-docker:tag`.

___
**Useful command:**

- `docker exec -it <containername> bash` - allows you to run commands in the containers. See [here](https://docs.docker.com/engine/reference/commandline/exec/) for more info.
- `docker tag --help` - Help info to tag an image

**Helpful Links:**
- [This project image on Docker hub](https://hub.docker.com/repository/docker/loanburger/dotnet-mongo-docker/general)
- [Pushing Docker images to a private registry with Docker Compose](https://medium.com/@stoyanov.veseline/pushing-docker-images-to-a-private-registry-with-docker-compose-d2797097751)

**Troubleshooting**

- For "requested access to the resource is denied" [see this solution](https://stackoverflow.com/questions/41984399/denied-requested-access-to-the-resource-is-denied-docker)




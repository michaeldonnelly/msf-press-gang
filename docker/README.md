## Publishing a new Docker image

This will make an image and publish it to Docker Hub [https://hub.docker.com/repository/docker/michaeldonnelly/pressgang-bot]. The image is published with 2 tags, one with a timestamp and the other tagged "latest."


### Build the code and create the image

```
cd docker
./build.sh
```

### Publish to Docker Hub

```
./publish.sh
```

### Deploy to staging and prod

Go to the server and follow the instructions to deploy the bot [https://github.com/michaeldonnelly/msf-press-gang/blob/master/Deploy/README.md]

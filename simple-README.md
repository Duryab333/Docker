## Why do we need Docker?
We need docker because we have a operating system, which might need some other libraries & dependiencies to run one applicaion and it can cause conflights when runing diffenert applicaion
which needed differnt version of dependencies or packages.So to run anything on any platform we need docker.So that it can create containerization.( a virtual enviornment so that applicaions can run without dependency conflicts)

## What is Docker?
It is a containerization tool which allows you to rull/ create images to run containers.
Docker pakages applicaion code, dependicies, runtime & configuraion into a container that can run same everywhere.

**Docker Engin**  : Its the complete system, it contains Docker Demon, Docker Client.

**Docker Client** : Its Docker CLI, use to talk Docker Demon.

**Docker Demon**  : Its a background-service that builds images, runing containers, and managing them behind the scenes. 


## How to use Docker?
1- Install Docker
2- Ensure Docker Demone is running
3- Pull images
4- Finally run contianers

## Important Comands
- To install docker:

  ```
  sudo apt-get update
  sudo apt-get install docker.io
  sudo usermod -aG $USER
  newgrp docker
  ```
- Containers:

  ```
  docker ps
  docker ps -a # Shows all the containers even not runing
  docker rm <container-id>

  docker stop <container-id>
  docker start <container-id>
  
  docker system prune # remove all the stoped contianers, networks, dangling images & build cache 
  ```
  
- Images:
  ```
  
  docker images
  docker rmi <image-id>
  ```
- Container Inspect: 
  ```
  
  docker logs <container-id>
  docker exect -it  <container-id> bash # to go instide container
  docker images

  ```
- Volume:
  ```
  docker volume ls
  docker volume create <volume-name>
  docker volume inspect <volume-name> # to see deails about volume,  where volume is created etc.
  ```
  Example of attaching volume at container run-time:(know at which location container stores the data and map that with volume)

  ```
  docker run -d  -v mysql_data:/var/lib/mysql -e MYSQL_ROOT_PASSWORD=root mysql

  ```

  if any Image have it child image so ` docker rm <container-id>` wouldn't work.  `docker system prune` it will all the stoped container, the unused network and the images that are damgling images (whoes inheriting other images but no contianer is runing on them ) and build cashes.

**Example 1 (UBUNTU)**
- To run an ubuntu container: ` docker run -itd ubuntu ` or  ` docker run -it ubuntu bash`
- To go instide of that container: ``docker exec -it <container-id> bash`
  
**Example 2 (Nginx)**
  - To run Nginx container: `docker run -d -p 80:80 nginx`
  - Port mapping: to run application on host, we do port mapping.
    
**Example 3 (MYSQL)**
- To run an mysql container: ` docker run -d --name mysql-demo -e MYSQL_ROOT_PASSWORD=admin mysql  `
- To go instide of that container: ``docker exec -it <container-id> bash`
- `mysql -u root -p`
- mysql> `show databases;`
- mysql> `use <database-name>;`
- mysql> `show tables;`
- mysql> `select * from <tables-name>;`

### Docker File:

Everything is build in layers.(it pull or build layers when we run Docker file.
- To run a docker file: docker build -t flask-app .

  
## Advanced:
- How to reduce and secure Docker images? [ Multi-stage Docker Build ]
- How to persist data? [ Docker volumes ]
- How to run multi-tire project which has frountend, Backend, Database, AL LLM integration [ Docker Compose - Docker Network, Docker Volumes, Health Checks]
- Docker Hardened Images
- Docker Scout
- Docker Hub


###  Multi-stage Docker Build

`vim Dockerfile.multistage`
- Use slim images instread of full size image(builder stage). e.g. `FROM python:3.14-slim AS builder`
- Only copy the requirments first. eg `COPY req.txt .` 
- Then install the requirments and store the packeges in container file. e.g `RUN pip install -r req.txt --target /app/libraries`
- Now copy the rest. e.g . `COPY . .`
- Use Distroless imge: Now till here python work is done we dont need pyhton image. we just need the run time. e.g. `FROM gcr.io/distroless/python3-debian12 AS deployer`
- WORKDIR /app
- Copy the work done in installing the requirments line: e.g. `COPY --from=builder /app/libraries /app/libraries`
- Copy the rest of things from stage 1. e.g. `COPY --from=builder /app .`
- To tell where are the libraties e.g `ENV PYTHONPATH="/app/libraties"
- `Expose 80`
- `CMD [ "run.py"]`

  Now build the docker image: e.g `docker build -f Docker.multistage -p 80:80 -t app-mini .`
  To run container : `docker run <container-id>`
  Now you can not go instide the container.
  To see whats happeining inside conttainer: docker attach <container-id>


### Docker Volume
 Docker storage is mapped to Host machine. So that when Docker crashes the information will be still stored on host.
 ````
 Docker volume create <volume-name>
 Docker volume ls
 Docker volume inspect <volume-name> # to check location of volume in Host
 ```
 Before mapping find out that where is the data store in container-name container path. e.g. for mysql its /var/lib/mysql
 Now map the host volume to data-store location of container at the time of creation e.g. `docker run -d mysql -v <volume-name>:/var/lib/mysql -e MYSQL_ROOT_PASSWORD=admin mysql .`
 Another example of nginx: `docker run -it -v /home/<host-path>:/app -p 83:80 <image-name> /bin/sh`
Now if the container crashed/rmoved and make new container it will still have the data stored on host.
Now data is Persist
another stratergy is instread of creating new volum you can just make a directory and use it as volume with -v e.g.  `docker run -d -v </home/ubuntu/project/data>:/app/data e MYSQL_ROOT_PASSWORD=admin mysql .`

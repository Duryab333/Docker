## Why do we need Docker? 
We need docker because we have a operating system, which might need some other libraries & dependiencies to run one applicaion and it can cause conflights when runing diffenert applicaion
which needed differnt version of dependencies or packages.So to run anything on any platform we need docker.So that it can create containerization.( a virtual enviornment so that applicaions can run without dependency conflicts)

## What is Docker?
It is a containerization tool which allows you to rull/ create images to run containers.
Docker pakages applicaion code, dependicies, runtime & configuraion into a container that can run same everywhere.

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
  docker ps
  ```
**Example 1 (UBUNTU)**
- To run an ubuntu container: ` docker run -itd ubuntu `
- To go instide of that container: ``docker exec -it <container-id> bash`
  
**Example 2 (MYSQL)**
- To run an mysql container: ` docker run -d --name mysql-demo -e MYSQL_ROOT_PASSWORD=admin mysql  `
- To go instide of that container: ``docker exec -it <container-id> bash`
-  `mysql -u root -p`
- mysql> `show databases;`
- mysql> `use <database-name>;`
- mysql> `show tables;`
- mysql> `select * from <tables-name>;`


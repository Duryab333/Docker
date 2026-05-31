# Steps to run the project
1- Clone the repository 
2- go inside the directory: "docker-file-1st-project"
3- build the image from dockerfile using: ` docker build -t nginx-demo .`
4- Now to run container : `docker run  --name nginx -d -p 80:80 nginx-demo`

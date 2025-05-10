# Docker

## Container 

Containers are lightweight, standalone software packages that bundle an application and all its dependencies, allowing it to run consistently across different computing environments

![Screenshot 2023-02-07 at 7 18 10 PM](https://user-images.githubusercontent.com/43399466/217262726-7cabcb5b-074d-45cc-950e-84f7119e7162.png)



## Containers vs Virtual Machine 

Containers and virtual machines are both technologies used to isolate applications and their dependencies, but they have some key differences:

    1. Resource Utilization: Containers share the host operating system kernel, making them lighter and faster than VMs. VMs have a full-fledged OS and hypervisor, making them more resource-intensive.

    2. Portability: Containers are designed to be portable and can run on any system with a compatible host operating system. VMs are less portable as they need a compatible hypervisor to run.

    3. Security: VMs provide a higher level of security as each VM has its own operating system and can be isolated from the host and other VMs. Containers provide less isolation, as they share the host operating system.

    4.  Management: Managing containers is typically easier than managing VMs, as containers are designed to be lightweight and fast-moving.

## Key Directories in Container Base Images

```
/bin    - Essential binaries (e.g., ls, cp, ps)
/sbin   - System binaries (e.g., init, shutdown)
/etc    - Configuration files
/lib    - Shared libraries
/usr    - User applications, libraries, docs
/var    - Logs, spool, and temp files
/root   - Root user's home directory

```

## Host Resources Containers Use

```
File System   - Accessed via bind mounts
Networking    - Uses host network stack or virtual networks
System Calls  - Handled by host kernel
Namespaces    - Isolate container environments
cgroups       - Control resource usage (CPU, memory, I/O)

```
# Docker 
Docker is a containerization platform that provides easy way to containerize your applications, which means, using Docker you can build container images, run the images to create containers and also push these containers to container regestries such as DockerHub, Quay.io and so on.

Docker is a tool for creating, running, and sharing containers.
Think of it as: containerization = concept, Docker = implementation.

## Docker Architecture
![image](https://user-images.githubusercontent.com/43399466/217507877-212d3a60-143a-4a1d-ab79-4bb615cb4622.png)


## Install Docker
Follow the official guide:
👉 https://docs.docker.com/get-docker/

For Ubuntu (like an EC2 instance):
```
sudo apt update
sudo apt install docker.io -y
```

Start Docker and add your user to the Docker group:

```
sudo systemctl start docker
sudo usermod -aG docker $USER
```
Note: Log out and back in for group changes to apply.

Test your install:

```
docker run hello-world
```

## Get Started
Clone the repo and go to the examples folder:

```
git clone https://github.com/iam-veeramalla/Docker-Zero-to-Hero
cd Docker-Zero-to-Hero/examples/first-docker-file
```
Login to Docker Hub:

```
docker login
```
Build your first image (replace yourdockerhub with your username):

```
docker build -t yourdockerhub/my-first-image:latest .
```
Run the container:

```
docker run -it yourdockerhub/my-first-image
```

Push to Docker Hub:

```
docker push yourdockerhub/my-first-image
```
## Optimizing Docker Builds with Caching 
Docker uses a layered caching mechanism to speed up builds by reusing unchanged instructions from previous builds. Each instruction in a Dockerfile creates a layer, and Docker checks whether it can reuse existing layers to avoid redundant work.

Key Concepts
✅ **Layered Builds** – Each instruction forms a layer, improving efficiency.

✅ **Cache Reuse** – Unchanged layers are reused, reducing build time. 

✅ **Cache Invalidation** – Changes to RUN, COPY, or ADD instructions invalidate the cache. 

✅ **Efficient Builds** – Minimizing unnecessary changes ensures faster builds.

### Best Practices
-    Place less frequently changing instructions first to maximize cache usage.

-    Avoid modifying RUN commands unless necessary.

-    Minimize changes to copied files to prevent unnecessary cache invalidation.

By following these practices, you can speed up Docker builds and reduce resource consumption! 

## Multi-Stage Docker Builds for Java Applications 

Multi-stage builds help create **optimized and secure Docker images** by separating the build environment from the runtime environment.  

### **How It Works**  
1️⃣ **Builder Stage** – Uses a **Java Development Kit (JDK)** to compile and package the application.  
2️⃣ **Final Stage** – Uses a **lighter Java Runtime Environment (JRE)** to run the application efficiently.  

### **Key Benefits**  
✅ **Smaller Image Size** – Removes unnecessary build dependencies.  
✅ **Improved Security** – Keeps only essential runtime components.  
✅ **Better Performance** – Reduces resource usage and speeds up deployments.  

### **Optimizing with `jlink`**  
- Instead of using a full JRE, **`jlink`** allows you to create a **custom minimal runtime**.  
- This includes **only the necessary Java modules**, reducing size and improving security.  

### **Why Use Multi-Stage Builds?**  
🔹 **Separates compilation, packaging, and testing from runtime**  
🔹 **Removes development/debugging tools from production images**  
🔹 **Enhances security and efficiency for Java applications**  

By using multi-stage builds, you can create **lean, secure, and optimized Docker images** for production! 🚀

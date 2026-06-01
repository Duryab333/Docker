# Food-Order-System-
Food Order System in java NetBeans.

Select categories , select checkbox , enter quantity and press Total button. 

Output :


![fo1](https://user-images.githubusercontent.com/106819662/196504053-5261a2ae-476b-4302-9c6a-c2adeb213858.png)


![fo2](https://user-images.githubusercontent.com/106819662/196504087-dd9a5a73-ed2e-4e79-b2af-1ab86967a601.png)


## Run Project with Docker

This project is a Java Swing GUI application containerized with Docker.

### Prerequisites

Make sure you have installed:

* Docker
* Git
* X11 display support for GUI applications

### Clone the Repository

```bash
git clone https://github.com/Duryab333/Docker.git
cd 2026/projects/Food-Order-System
```

### Build the Docker Image

```bash
docker build -t food-order-system .
```

### Allow Docker to Access Display

```bash
xhost +local:docker
```

### Run the Application

```bash
docker run --rm -it \
  -e DISPLAY=$DISPLAY \
  -v /tmp/.X11-unix:/tmp/.X11-unix \
  food-order-system:latest
```

### Notes

This is a desktop GUI application, so it needs access to the host machine display.

If you get a display-related error, check:

```bash
echo $DISPLAY
```

For WSL users, make sure WSLg or an X server is running.


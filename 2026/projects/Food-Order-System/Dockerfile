FROM   eclipse-temurin:8-jdk

WORKDIR /app
COPY food_order/ /app

RUN apt-get update &&  apt-get  install -y \
	ant \
	libxext6 \
    	libxrender1 \
    	libxtst6 \
    	libxi6 \
    	libx11-6 \
	&& rm -rf /var/lib/apt/lists/*  


RUN ant clean jar

CMD ["java","-jar","dist/anagrams.jar"]

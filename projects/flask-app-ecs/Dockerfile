FROM python:3.14

# Indicate the name of mainiainer
MAINTAINER duryabtariq

WORKDIR /app

COPY . . 

RUN pip install -r  requirements.txt

#indicate the port used

EXPOSE 80

CMD ["python","run.py"]

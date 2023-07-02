# The Water Jug Problem

## Description

This is a REST API with an implementation to solve the water jug problem.

The Water Jug problem consists of three variables: X, Y and Z. X is the max ammount of water you can hold in the first water jug, Y is the max ammount of water you can hold in the second water jug, and Z is the target; the ammount of water you want to have in either one of the jugs.

For each Water Jug you can perform three actions: dump, fill and transfer.

The goal of this test, is to write a program that solves the problem in the least ammount of steps for a given input (if possible).

## Solution
The program chooses a main Jug and keeps filling it up and transfering the water to the secondary jug until either one of them reaches the target value. It does this for both X and Y, and returns the solution with the least ammount of steps.

## How to run

### Requirements
- [Docker](https://docs.docker.com/desktop/install/windows-install/)
- [Basic knowledge of Command Prompt (CMD)](https://www.makeuseof.com/tag/a-beginners-guide-to-the-windows-command-line/)
### Steps
- Install and run Docker
- Once Docker is installed and running open a command prompt. 
- In the command prompt, cd into the project folder and run the following commands:

```cmd
docker image build -t waterjug .
docker container run --name waterjug -p 8080:80 -d waterjug
```
The first command will build a docker image of the app with the name "waterjug". 

The second command will run a docker container with "waterjug" docker image on port 8080

## How to use
The API consists of two endpoints:
1. POST /waterjug This endpoint expects a JSON input with the values to use to try and solve the Water Jug problem. It will return the steps taken to solve the problem if it found a solution, otherwise it will return an error message. The JSON input should look like this: `{"x": 3, "y": 5, "z": 4}`

2. GET /waterjug/status This endpoint will return the steps taken for the last water jug problem solved.

Once the program is running, you can use apps like [Postman](https://www.postman.com/) to communicate with the API.

You can also open a command prompt to send requests with CurL:
```
curl -X POST -H "Content-Type: application/json" -d "{\"x\":2,\"y\":5,\"z\":4}" localhost:8080/waterjug
```
- CRUD TASK
This project content a Create, Update, Delete, List and Test.

- USED TECHNOLOGYS

    - Dotnet 6
    - Entity Framework
    - Docker
    - Git
    - xUnit

- HOW TO RUN?

    INITIAL STEPS TO RUN THE APPLICATION

    - In the terminal, execute the command below to create an image of the APPLICATION in Docker and instantiate a PostGres database:
        -"docker-compose up"

    - Now the application is running in Docker (Take a look at Docker Desktop)

- EXAMPLES TEST (2 Ways to Test):
    -First Way - Postman
        Just copy and import the CURL's to postman

        CURL for GET request (Return all tasks)

            curl -X 'GET' \
            'http://localhost:5001/api/Task' \
            -H 'accept: text/plain'

        CURL for POST request (Create a new Taks)

            curl -X 'POST' \
            'http://localhost:5001/api/Task' \
            -H 'accept: text/plain' \
            -H 'Content-Type: application/json' \
            -d '{
            "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
            "creationDate": "2024-10-14T19:05:04.622Z",
            "title": "string",
            "description": "string",
            "status": 0,
            "startDate": "2024-10-14T19:05:04.622Z",
            "endDate": "2024-10-14T19:05:04.622Z"
            }'

        CURL for PUT request (Update a Task)

            curl -X 'PUT' \
            'http://localhost:5001/api/Task' \
            -H 'accept: text/plain' \
            -H 'Content-Type: application/json' \
            -d '{
            "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
            "creationDate": "2024-10-14T19:08:41.816Z",
            "title": "string",
            "description": "string",
            "status": 0,
            "startDate": "2024-10-14T19:08:41.816Z",
            "endDate": "2024-10-14T19:08:41.816Z"
            }'

        CURL for GET request by ID (Return a Taks based on ID)

            curl -X 'GET' \
            'http://localhost:5001/api/Task/3fa85f64-5717-4562-b3fc-2c963f66afa6' \
            -H 'accept: text/plain'

        CURL for DELETE request (DELETE a Task based on ID)

            curl -X 'DELETE' \
            'http://localhost:5001/api/Task/3fa85f64-5717-4562-b3fc-2c963f66afa6' \
            -H 'accept: */*'

    -Second Way (Swagger)
        Just copy and paste the URL below in your browser (make sure the docker is running)
        - "http://localhost:5000/swagger/index.html"

- UNIT TESTS
    - First of all, Go to appsettings and change Host to Host=localhost
    - Go to 4-Test File
    - In TaskList.Service.Test
    - Run Tests


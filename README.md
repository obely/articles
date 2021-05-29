## To Run locally
- Update "ArticlesConnectionString" connection string in _/Articles.Api/appsettings.json_
- Build and run the application
```sh
 dotnet run --project Articles.Api
```
- Open https://localhost:5001/swagger/index.html in browser to test the API. Alternatively, you can use the requests from _test.http_ file.

## To Run in Docker containers
- Build docker image
```sh
docker build -f Articles.Api/Dockerfile -t articles .
```
- Run the application
```sh
docker-compose up -d
```
- Open http://<docker host>:8080/swagger/index.html in browser to test the API. Alternatively, you can use the requests from _test.http_ file.

## Authorization

Some REST API methods are protected with token authorization and require the Authorization header in an HTTP request. The token is configured in _Articles.Api/appsettings.json_:
```sh
"JwtSettings": {
    "Token": "876c76b7-9f1d-437a-a4ff-5c13d268c320"
  }
```

The example of a valid request:
```sh
POST https://localhost:5001/api/Articles
Content-Type: application/json
Authorization: Bearer 876c76b7-9f1d-437a-a4ff-5c13d268c320

{
    "title": "ABC",
    "body": "Hello, world!"
}
```
# Notes REST application #

## Build artifact from code ##
Build application using: 
> `gradlew clean build`

Artifact can be found as `build/libs/notes-app-1.0.jar`

## Run application ##
Run application with optional param server.name
> `java -jar build/libs/notes-app-1.0.jar --server.name=some-server`

Param server.name is always added as response header to identify which server answered.
Default value is `default`

## REST API Documentation in Swagger ##
After running application locally you can open documentation in swagger-ui
> http://localhost:8080/swagger-ui.html 
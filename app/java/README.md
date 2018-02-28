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

## Policy to run application ##
Policy can be found in file cli-account-policy.policy in complete folder. 
Please review policy dynamodb table arn before applying.

## Added credention provider for complete app ##
To allow using profiles other then *default* - I have added ProfileCredentialsProvider which will look up credentials according to AWS specification 
https://docs.aws.amazon.com/sdk-for-java/v1/developer-guide/credentials.html

Please take a look at *Using the Default Credential Provider Chain* paragraph, there is an order in which credentials are looked up.
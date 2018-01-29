# AWS CLI useful commands #

## Create DynamoDB table ##

>aws dynamodb create-table \
     --table-name AWSQuizExams \
     --attribute-definitions AttributeName=NoteId,AttributeType=N \
     --key-schema AttributeName=NoteId,KeyType=HASH \
     --provisioned-throughput ReadCapacityUnits=1,WriteCapacityUnits=1
     
## List tables in region ##
> aws dynamodb list-tables --region=eu-west-2

##  ##
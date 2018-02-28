# AWS CLI useful commands #

## Set up AWS Credentials using Profile ##
> aws configure --profile my-super-profile

Type in Access Key, Secret Access Key and region.

For Linux/Mac
> export AWS_PROFILE=my-super-profile

For Windows
> set AWS_PROFILE=my-super-profile

You can also add --profile to all your AWS CLI api calls.

## Create DynamoDB table ##

>aws dynamodb create-table \
     --table-name Notes \
     --attribute-definitions AttributeName=NoteId,AttributeType=N \
     --key-schema AttributeName=NoteId,KeyType=HASH \
     --provisioned-throughput ReadCapacityUnits=1,WriteCapacityUnits=1
     
## List tables in region ##
> aws dynamodb list-tables --region=eu-west-2

## Copy file to S3 ##
> aws s3 cp build/libs/notes-app-1.0.jar s3://bpk-notes-artifactory/

To copy all files from S3 to local
> aws s3 cp s3://bpk-notes-artifactory/ build/libs/ --recursive


#!/usr/bin/env bash

yum install java-1.8.0 -y
yum remove java-1.7.0-openjdk -y

rm -f notes-app-1.0.jar

aws s3 cp s3://bpk-ha-rest-artifacts/artifacts . --recursive

java -jar notes-app-1.0.jar --server.name=$(curl http://169.254.169.254/latest/meta-data/local-ipv4)
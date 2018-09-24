
Source code at https://github.com/samwa/iddevtest

Terraform script is iddevtest.tf
run using terraform up

site uses angular and .net core 2.1 with Entity Framework Core

deploying using azure piplines https://dev.azure.com/iddevtest/iddevtest

### setup local
## dependacies
.net core 2.1
visual studio code
npm
terraform

## infrastructure
to create azure assets
terraform up

## db
dotnet ef database update
run data/fulldate.sql against the created db

## run app
npm install
dotnet watch run
ng serve
go to http://localhost:4200
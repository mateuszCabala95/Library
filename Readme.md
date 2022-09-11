# Description
Project contaoins 2 microservices, communication between bouth is done by RESTApi.  

# Microservices
- Library 
- Security

## Library
Library allows to get all books, get one book, create book and delete book,
Action like creating and deleting books required special permission.
This feauter is privdied by Security microservice.

## Security
By Security you can register new user. You can login already created user and check is JWT valid.

### General purpose of project
General purpose of project is possibility to get informations about book. Login user can edit this data or delete.
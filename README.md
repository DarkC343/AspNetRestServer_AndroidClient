# Documentation
## Introduction
This web API has been written in ASP.NET Core. The goal is to provide some basic functionality to connect an android application to this API. Briefly, the functionalities are validate a user, register and gets the profile of a user. You can find the details below. So, let's start! :+1:
## How To Connect
You should connect to this url pattern: `server:port/android-api/users/` where `android-api/users/` is for this particular API.
<br />
Each method name should come after the above pattern. example: `http://192.168.1.12:5000/android-api/users/get-all-users`
## Models
### Person
```javascript
└──── Name < string >
└──── Username < string >
└──── Password < string >
```
### Response
```javascript
└──── Success < bool >
└──── Message < string >
```
## API Functions
* `get-all-users`
   * **Method:** GET
   * **Parameter(s):** none
   * **Output(s):** array of 'Person' models, a 'Response' model
   * **Error(s):** DATABASE_ERROR, DATABASE_IS_EMPTY
   * **Description:** Gets all people from 'People' table
  ```json
  {
    "users": [
      {
      "personId": 1,
      "name": "Amir",
      "username": "amir_01",
      "password": "test1"
      },
      {
      "personId": 2,
      "name": "Ali",
      "username": "ali_the_hacker",
      "password": "test2"
      },
      {
      "personId": 3,
      "name": "Sajad",
      "username": "sajjad99",
      "password": "test3"
      },
      {
      "personId": 4,
      "name": "Hashem",
      "username": "h4shem",
      "password": "test4"
      },
      {
      "personId": 5,
      "name": "AmirMohammad",
      "username": "darkc343",
      "password": "123"
      }
    ]
  }
  ```
* `get-profile`
   * **Method:** GET
   * **Parameter(s):** 'username' string
   * **Output(s):** a 'Person' models, a 'Response' model
   * **Error(s):** DATABASE_ERROR, USERNAME_DOES_NOT_EXIST
   * **Description:** Get a profile based on the username provided (ex. get-profile?username=amir_01)
  ```json
  {
    "user": {
    "personId": 1,
    "name": "Amir",
    "username": "amir_01",
    "password": "test1"
    }
  }
  ```
* `validate`
   * **Method:** POST
   * **Parameter(s):** 'username' and 'password' string array. pair\[0] = username, pair\[1] = password
   * **Output(s):** a 'Response' model
   * **Error(s):** DATABASE_ERROR, LOGIN_IS_INVALID
   * **Description:** Checks whether the pair consisting of username and password is valid or not. Clearly, 'true' in 'Response' output model means valid.
* `register`
   * **Method:** POST
   * **Parameter(s):** a 'Person' model
   * **Output(s):** a 'Response' model
   * **Error(s):** DATABASE_ERROR, USERNAME_ALREADY_EXISTS
   * **Description:** Adds a new person to 'People' table. Notice a duplicate username is not acceptable.

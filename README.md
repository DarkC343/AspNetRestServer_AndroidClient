# Documentation
## HTTP request methods reference
* `get-all-users`
   * **Method:** GET
   * **Parameter(s):** none
   * **Output(s):** array of 'Person' models, a 'Response' model
   * **Error(s):** DATABASE_ERROR, DATABASE_IS_EMPTY
   * **Description:** Gets all people from 'People' table
* `get-profile`
   * **Method:** GET
   * **Parameter(s):** 'username' string
   * **Output(s):** a 'Person' models, a 'Response' model
   * **Error(s):** DATABASE_ERROR, USERNAME_DOES_NOT_EXIST
   * **Description:** Get a profile based on the username provided (ex. get-profile?username=amir_01)
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

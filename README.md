# OneStream Assessment

# How to Run
    dotnet run --project backendAPI1
    dotnet run --project backendAPI2
    dotnet run --project frontendWebAPI

## backendAPI1
    Call a GET request at http://localhost:5150/backendAPI1 to receive a 200 OK output
    Output will be" Hello World from backendAPI1 after a 2 second delay

## backendAPI2
    Call a GET request at http://localhost:5157/backendAPI2 to receive a 200 OK output
    Output will be" Hello World from backendAPI2 after a 4 second delay

## frontendWebAPI
    Call a GET request at http://localhost:5182/frontendWebAPI to receive a 200 OK output
    Call a POST request at http://localhost:5182/frontendWebAPI to receive a 200 OK or 400 Bad Request output

### frontendWebAPI GET request output
    Call a GET request at http://localhost:5182/frontendWebAPI to receive a 200 OK output
    Output will show the following after 4 seconds:

{
    "backendAPI1Response": "Hello World from backendAPI1",
    "backendAPI2Response": "Hello World from backendAPI2"
}

### frontendWebAPI POST request output
    The POST request requires a Content-Type = application/json HEADER and a JSON Body with a "Name" field. Depending on the contents of the value in the "Name" field, a 200 or 400 response will be returned.

### frontendWebAPI POST request output 200 OK
    In the POST request body, a JSON object with a "Name" field is required with a string name that has a 50 character limit. If the "Name" field has a value of 50 characters or less, the output will be "Hello, ${Name}!". Below is an example:

    Body: {
        "Name": "Johnathan"
    }

    Output: Hello, Johnathan!

### frontendWebAPI POST request output 400 bad Request
    If the "Name" field has a value over 50 characters, a 400 response will be returned stating "name cannot be more than 50 characters". Below is an example:

    Body: {
        "Name": "Char­gogg­a­gogg­man­chaugg­a­gogg­chau­bun­a­gunam"
    }

    Output: {
        "type": "https://tools.ietf.org/html/rfc9110#section-15.5.1",
        "title": "One or more validation errors occurred.",
        "status": 400,
        "errors": {
            "Name": [
                "Name cannot be more than 50 characters."
            ]
        },
        "traceId": "00-787bbcbe03efe770827794c355be0797-c9dc3263b14a3acf-00"
    }
// Import the express framework
const express = require('express')

// Create an instance of it
const expressApp = express()

// Set the port the server will listen on
const port = 3000

// When we receive a request at `http://localhost:3000/` call the `SayHi` method to send a result
expressApp.get('/', (request, result) => {
    SayHi(request, result);
})

// When we receive a request at `http://localhost:3000/` call the SayHi method
//expressApp.get('/', SayHi(request, result));


function SayHi(request, result)
{
	result.send('Hello from a function!');
}


expressApp.listen(port, () => console.log('Node server started and listening on port: ' + port));
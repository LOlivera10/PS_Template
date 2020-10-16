const express = require('express')
const app = express()
const port = 3000
const path = require('path')
const router = express.Router();

app.use(express.static(__dirname + '/public'));

app.get('/', (req, res) => {
  res.sendFile(path.join(__dirname + '/html/index.html'));
})

app.use('/', router);
app.listen(port, () => {
  console.log(`Example app listening at http://localhost:${port}`)
})
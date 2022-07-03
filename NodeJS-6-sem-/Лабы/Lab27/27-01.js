const {createClient} = require('webdav');
const fs = require('fs');
const config = require('./config/config');
const client = createClient(config.REMOTE_URL, {
    username: config.USERNAME,
    password: config.PASSWORD
});

const app = require('express')();

app.listen(config.PORT, () => {
    console.log(`Listening to http://localhost:${config.PORT}/`);
});

app.post('/md/:name', (req, res) => {
    const dirPath = '/' + req.params.name;
    //Проверка на сушествование директории
    client.exists(dirPath)
        .then(alreadyExists => {
            if (alreadyExists) {
                res.status(408);
                return {error: 'Such directory already exists'};
            } else {
                return client.createDirectory(dirPath).then(() => ({message: 'Directory\'s been created'}));
            }
        })
        .then(message => res.json(message))
        .catch(err => res.status(400).json({error: err.toString()}));
});

app.post('/rd/:name', (req, res) => {
    const dirPath = '/' + req.params.name;
    client.exists(dirPath)
        .then(alreadyExists => {
            if (alreadyExists) {
                return client.deleteFile(dirPath).then(() => ({message: 'Directory\'s been removed'}));
            } else {
                res.status(404);
                return {error: 'There is no such folder'};
            }
        })
        .then(message => res.json(message))
        .catch(err => res.status(400).json({error: err.toString()}));
});

app.post('/up/:name', (req, res) => {
    try {
        const filePath = './files/' + req.params.name;
        //Открыть поток для чтения
        let rs = fs.createReadStream(filePath);
        //Открыть поток для записи
        let ws = client.createWriteStream(req.params.name);
        //Связать потоки чтения-записи
        rs.pipe(ws);

        res.json({message: 'File\'s been uploaded'});
    } catch (err) {
        res.status(408).json({error: err.toString()})
    }
});

app.post('/down/:name', (req, res) => {
    const filePath = '/' + req.params.name;
    client.exists(filePath)
        .then(alreadyExists => {
            if (alreadyExists) {
                let rs = client.createReadStream(filePath);
                let ws = fs.createWriteStream('./files/' + Date.now() + req.params.name);
                rs.pipe(ws);
                //Связать потоки чтения-записи для отображения в ответе
                rs.pipe(res);
            } else {
                res.status(404);
                return {error: 'There is no such file'};
            }
        })
        .then(message => message ? res.json(message) : null)
        .catch(err => res.status(400).json({error: err.toString()}));
});

app.post('/del/:name', (req, res) => {
    const filePath = '/' + req.params.name;
    client.exists(filePath)
        .then(alreadyExists => {
            if (alreadyExists) {
                return client.deleteFile(filePath).then(() => ({message: 'File\'s been removed'}));
            } else {
                res.status(404);
                return {error: 'There is no such file'};
            }
        })
        .then(message => res.json(message))
        .catch(err => res.status(400).json({error: err.toString()}));
});

app.post('/copy/:source/:destination', (req, res) => {
    const sourceFilePath = '/' + req.params.source;
    const destinationFilePath = '/' + req.params.destination;
    client.exists(sourceFilePath)
        .then(alreadyExists => {
            if (alreadyExists) {
                //Копирование одного файла в другой, при этом файл не удаляется
                return client.copyFile(sourceFilePath, destinationFilePath).then(() => ({message: 'File\'s been copied'}));
            } else {
                res.status(404);
                return {error: 'There is no such source file'};
            }
        })
        .then(message => res.json(message))
        .catch(err => res.status(400).json({error: err.toString()}));
});

app.post('/move/:source/:destination', (req, res) => {
    const sourceFilePath = '/' + req.params.source;
    const destinationFilePath = '/' + req.params.destination;
    client.exists(sourceFilePath)
        .then(alreadyExists => {
            if (alreadyExists) {
                //Перемещение одного файла в другой, при этом файл удаляется
                return client.moveFile(sourceFilePath, destinationFilePath).then(() => ({message: 'File\'s been moved'}));
            } else {
                res.status(404);
                return {error: 'There is no such source file'};
            }
        })
        .then(message => res.json(message))
        .catch(err => res.status(400).json({error: err.toString()}));
});

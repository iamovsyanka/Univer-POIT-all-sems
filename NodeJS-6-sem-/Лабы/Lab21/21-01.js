const express = require('express');
/*Passport — это middleware для авторизации под node.js.*/
const passport = require('passport');
const BasicStrategy = require('passport-http').BasicStrategy;
const {checkUser, checkPassword} = require('./services/checkUsers');
const session = require('express-session')(
    {
        /*Заставляет сеанс быть сохраненным обратно в хранилище сеансов, даже если сеанс
        никогда не был изменен во время запроса. В зависимости от вашего магазина это может
        быть необходимо, но это также может создать условия гонки, когда клиент делает два
        параллельных запроса к вашему серверу, и изменения, внесенные в сеанс в одном запросе,
        могут быть перезаписаны, когда заканчивается другой запрос, даже если он не внес
        никаких изменений (это поведение также зависит от того, какой магазин вы используете).*/
        resave: false,
        /*Заставляет сеанс, который является "неинициализированным", быть сохраненным в хранилище.
        Сеанс неинициализируется, когда он является новым, но не модифицированным.
        Выбор false полезен для реализации сеансов входа в систему, сокращения использования
        серверного хранилища или соблюдения законов, требующих разрешения перед установкой
        файла cookie. Выбор false также поможет в условиях гонки, когда клиент делает
        несколько параллельных запросов без сеанса.*/
        saveUninitialized: false,
        /*Это секрет, используемый для подписи файла cookie идентификатора сеанса.
        Это может быть либо строка для одного секрета, либо массив из нескольких секретов.
        Если предоставляется массив секретов, то только первый элемент будет использоваться
        для подписи файла cookie идентификатора сеанса, в то время как все элементы будут
        учитываться при проверке подписи в запросах.*/
        secret: '123456789'
    });

const app = express();

/*Базовая стратегия аутентификации HTTP аутентифицирует пользователей с помощью идентификатора
пользователя и пароля. Стратегия требует verify обратного вызова, который принимает эти
учетные данные и вызывает done предоставляющего пользователя.*/
passport.use(new BasicStrategy((login, password, done) => {
    let result, user = checkUser(login);
    if (!user) {
        result = done(null, false, {message: 'incorrect login!'})
    } else if (!checkPassword(user.password, password)) {
        result = done(null, false, {message: 'incorrect password!'})
    } else {
        result = done(null, login)
    }

    return result;
}));

/*Для Passport также необходима сериализация и десериализация экземпляра объекта пользователя
из сессии сохранения в целях поддержки текущей сессии, так чтобы каждый последующий запрос
не содержал учетные данные пользователя. Для этого предназначены
два метода serializeUser и deserializeUser*/
passport.serializeUser((login, done) => {
    done(null, login);
});
passport.deserializeUser((login, done) => {
    done(null, login);
});

app.use(session);
//Возвращает middleware которая должная быть вызвана при старте приложения основанного
// на connect или express.
app.use(passport.initialize());
//Это возвращает middleware, которая будет пытаться прочитать пользователя из сессии
app.use(passport.session());

app
    .get('/login', (req, res, next) => {
            if (req.session.logout && req.headers['authorization']) {
                req.session.logout = false;
                delete req.headers['authorization'];
            }

            next();
        },
        //Данная функция возвращает middleware которая запускает стратегии
        passport.authenticate('basic'), (req, res, next) => {
            next();
        })
    .get('/login', (req, res, next) => {
        req.headers['authorization'] ?
            res.send('success login<br>' +
                '<a href="http://localhost:3000/resource">resource</a><br>' +
                '<a href="http://localhost:3000/logout">logout</a>') :
            res.redirect('/login');
    });

app.get('/resource', (req, res, next) => {
    req.headers['authorization'] ? res.send('resource') : res.redirect('/login');
});

app.get('/logout', (req, res) => {
    req.session.logout = true;
    res.redirect('/login');
});

app.use((req, res, next) => {
    res.status(404).send('This URI is not supported');
});

app.listen(3000, () => {
    console.log('http://localhost:3000/login')
});

const express = require('express');
const passport = require('passport');
const DigestStrategy = require('passport-http').DigestStrategy;
const {checkUser} = require('./services/checkUsers');
const session = require('express-session')(
    {
        resave: false,
        saveUninitialized: false,
        secret: '123456789'
    });

const app = express();

passport.use(new DigestStrategy({gop: 'auth'}, (login, done) => {
    let result, user = checkUser(login);
    if (!user) {
        result = done(null, false, {message: 'incorrect login!'})
    } else {
        result = done(null, user.login, user.password)
    }

    return result;
}, (params, done) => {
    console.log('parms = ', params);
    done(null, true);
}));

passport.serializeUser((login, done) => {
    done(null, login);
});
passport.deserializeUser((login, done) => {
    done(null, login);
});

app.use(session);
app.use(passport.initialize());
app.use(passport.session());

app
    .get('/login', (req, res, next) => {
        if (req.session.logout && req.headers['authorization']) {
            req.session.logout = false;
            delete req.headers['authorization'];
        }

        next();
    })
    .get('/login', passport.authenticate('digest', {session: false}),
        (req, res, next) => {
            next()
        })
    .get('/login', (req, res, next) => {
        res.send('success login<br>' +
            '<a href="http://localhost:3001/resource">resource</a><br>' +
            '<a href="http://localhost:3001/logout">logout</a>')
    });

app.get('/resource', (req, res, next) => {
    req.headers['authorization'] ?
        res.send('resource') :
        res.redirect('/login');
});

app.get('/logout', (req, res) => {
    req.session.logout = true;
    res.redirect('/login');
});

app.use((req, res, next) => {
    res.status(404).send('This URI is not supported');
});

app.listen(3001, () => {
    console.log('http://localhost:3001/login')
});

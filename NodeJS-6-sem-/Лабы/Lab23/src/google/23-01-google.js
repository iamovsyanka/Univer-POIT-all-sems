const express = require('express');
const cors = require('cors');
const bodyParser = require('body-parser');
const passport = require('passport');
const GoogleStrategy = require('passport-google-oauth20').Strategy;
const cookieSession = require('cookie-session');

const config = require('../../config/config');
const app = express();

passport.serializeUser(function (user, done) {
    done(null, user);
});

passport.deserializeUser(function (user, done) {
    done(null, user);
});

passport.use(new GoogleStrategy({
        clientID: config.GOOGLE_APP_ID,
        clientSecret: config.GOOGLE_APP_SECRET,
        callbackURL: config.GOOGLE_REDIRECT_URI
    },
    function (accessToken, refreshToken, profile, done) {
        return done(null, profile);
    }
));

app.use(cors());

app.use(bodyParser.urlencoded({extended: false}));
app.use(bodyParser.json());

app.use(cookieSession({
    name: 'session',
    keys: ['key1', 'key2']
}));

const isLoggedIn = (req, res, next) => {
    if (req.user) {
        next();
    } else {
        res.sendStatus(401);
    }
};

app.use(passport.initialize());
app.use(passport.session());

app.get('/', (req, res) => res.send('Example Home page!'));
app.get('/failed', (req, res) => res.send('You Failed to log in!'));

app.get('/good', isLoggedIn, (req, res) => res.send(`Welcome, ${req.user.displayName}!`));

app.get('/google', passport.authenticate('google', {scope: ['profile', 'email']}));

app.get('/google/callback', passport.authenticate('google', {failureRedirect: '/failed'}),
    function (req, res) {
        res.redirect('/good');
    }
);

app.get('/logout', (req, res) => {
    req.session = null;
    req.logout();
    res.redirect('/');
});

app.listen(config.PORT, () => console.log(`http://localhost:${config.PORT}/google`));

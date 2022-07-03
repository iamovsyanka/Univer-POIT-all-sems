const express = require('express'),
    passport = require('passport'),
    VkStrategy = require('passport-vkontakte/lib').Strategy;
const session = require('express-session')({
    resave: false,
    saveUninitialized: false,
    secret: '123456789'
});
const hbs = require('express-handlebars').create({extname: '.hbs'});
const config = require('../../config/config');

if (!config.VK_APP_ID || !config.VK_APP_SECRET) {
    throw new Error('Set VK_APP_ID and VK_APP_SECRET env vars to run the example');
}

passport.serializeUser(function(user, done) { done(null, user); });
passport.deserializeUser(function(obj, done) { done(null, obj); });

passport.use(new VkStrategy(
    {
        clientID: config.VK_APP_ID,
        clientSecret: config.VK_APP_SECRET,
        callbackURL: config.VK_REDIRECT_URI,
        scope: ['email'],
        profileFields: ['email'],
    },
    function verify(accessToken, refreshToken, params, profile, done) {
        process.nextTick(function () {
            return done(null, profile);
        });
    }
));

const app = express();

app.engine('.hbs', hbs.engine);
app.set('view engine', '.hbs');

app.use(session);
app.use(passport.initialize());
app.use(passport.session());

app.get('/', function(req, res){
    res.render('index', {
        user: req.user,
        account: JSON.stringify(req.user, null, 2)
    });
});

app.get('/resource', ensureAuthenticated, function(req, res){
    res.render('resource', { user: req.user });
});

app.get('/login', function(req, res){
    res.render('login', { user: req.user });
});

app.get('/auth/vk', passport.authenticate('vkontakte'), function(req, res) {
    req.logout();
    req.session.destroy(function (err) {
        if (err) {
            return next(err);
        }
        req.session = null;
        res.redirect('/');
    });
});

app.get('/auth/vk/callback',
    passport.authenticate('vkontakte', { failureRedirect: '/login' }),
    function(req, res) { res.redirect('/'); });

app.get('/logout', function(req, res) {
    req.session.logout = true;
    req.session.destroy(e => {
        req.logout();
        res.redirect("/login");
    });
});

app.use(function (req, res, next) {
    res.status(404).send("Not Found")
});

app.listen(config.PORT, () => {
    console.log(`http://localhost:${config.PORT}/`)
});

function ensureAuthenticated(req, res, next) {
    if (req.isAuthenticated()) { return next(); }
    res.redirect('/login')
}

//https://github.com/stevebest/passport-vkontakte

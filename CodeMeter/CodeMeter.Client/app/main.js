requirejs.config({
    paths: {
        'text': '../lib/requirejs-text/text',
        'durandal': '../lib/durandal',
        'plugins': '../lib/durandal/plugins',
        'transitions': '../lib/durandal/transitions',
        'knockout': '../lib/knockout/knockout',
        'komapping': '../lib/knockout/knockout.mapping',
        'jquery': '../lib/jquery/jquery.min',
        'bootstrap': '../lib/bootstrap/bootstrap.min',
        'moment': '../lib/moment/moment.min'

    },
    shim: {
        komapping: {
            deps: ['knockout'],
            exports: 'komapping'
        },
        bootstrap: {
            deps: ['jquery'],
            exports: 'jQuery'
        },

    }
});

define(['durandal/system', 'durandal/app', 'durandal/viewLocator', 'bootstrap'], function (system, app, viewLocator) {
    //>>excludeStart("build", true);
    system.debug(true);
    //>>excludeEnd("build");

    app.title = "CodeMeter";

    app.configurePlugins({
        router: true,
        dialog: true,
        widget: true
    });

    app.start().then(function () {
        // Replace 'viewmodels' in the moduleId with 'views' to locate the view.
        // Look for partial views in a 'views' folder in the root.
        viewLocator.useConvention();

        // Show the app by setting the root view model for our application with a transition.
        app.setRoot('viewmodels/shell');
    });
});
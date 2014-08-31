define(["jquery", "knockout", "durandal/app", "durandal/system", "plugins/router", "services/data"], function ($, ko, app, system, router, data) {
    var
    // Properties

    // Handlers

    // Lifecycle

        activate = function (id) {
            if (id) {
                return data.getTask(id).done(function (task) {

                }).fail(function () {});
            }

        },

        deactivate = function () {};

    return {
        // Place your public properties here
        activate: activate,
        deactivate: deactivate
    };
});
define(["jquery", "knockout", "durandal/app", "durandal/system", "plugins/router", "services/data", "komapping"], function ($, ko, app, system, router, data, mapper) {
    var
    // Properties
        cfg = mapper.fromJS({
        ID: '',
        CheckInterval: 0,
        CheckRunning: false,
        NotificationInterval: 15,
        Password: '',
        Port: 26,
        Recepient: '',
        SendEmail: false,
        SendSms: false,
        Sender: '',
        Smtp: '',
        Ssl: false,
        Username: ''
    }),
    isBusy = ko.observable(false),
    // Handlers
    save = function() {
        isBusy(true);
        data.updateConfiguration(cfg).done(function(){
            
        }).fail(function(){
            
        }).always(function(){
            isBusy(false);
        })
    },
    // Lifecycle

    activate = function () {
        return data.getConfiguration().done(function (configuration) {
            mapper.fromJS(configuration, cfg);
        })
    },

    deactivate = function () {};

    return {
        // Place your public properties here
        isBusy: isBusy,
        cfg: cfg,
        save: save,
        activate: activate,
        deactivate: deactivate
    };
});
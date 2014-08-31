define(["jquery", "knockout", "durandal/app", "durandal/system", "plugins/router", "komapping", "services/data"], function ($, ko, app, system, router, mapping, data) {
    var
    // Properties
    
        project = mapping.fromJS({
            ID: '',
            Name: '',
            Client: ''
        }),
        isBusy = ko.observable(false),
        notBusy = function() {
          isBusy(false);  
        },
        
        // Handlers
        
        save = function () {
            isBusy(true);
            if (!project.ID()) {
                data.saveProject(project).done(function (rsp) {

                }).fail(function () {}).always(notBusy);
            } else {
                data.updataProject(project).done(function (rsp) {

                }).fail(function () {}).always(notBusy);
            }

        },
        // Lifecycle

        activate = function (id) {
            if (id) {
                return data.getProject(id).done(function (proj) {
                    mapping.fromJS(proj, project);
                });
            } else {
                mapping.fromJS({
                    ID: '',
                    Name: '',
                    Client: ''
                }, project);
            }
        },

        deactivate = function () {};

    return {
        // Place your public properties here
        project: project,
        save: save,
        isBusy: isBusy,
        activate: activate,
        deactivate: deactivate
    };
});
define(["jquery", "knockout", "durandal/app", "durandal/system", "plugins/router", "services/data", "komapping"], function ($, ko, app, system, router, data, mapper) {
    var
    // Properties
        task = mapper.fromJS({
            ID: 0,
            ProjectID: 0,
            Name: '',
            Description: ''
        }),
        isBusy = ko.observable(''),
        // Handlers
        save = function () {
            isBusy(true);
            if (!task.ID()) {
                data.insertTask(task).done(function (id) {
                    task.ID(id);
                }).fail(function () {}).always(function () {
                    isBusy(false);
                })
            } else {
                data.updateTask(task).done(function () {
                    
                }).fail(function () {}).always(function () {
                    isBusy(false);
                });
            }
        },
        // Lifecycle

        activate = function (projectId, taskId) {
            if (taskId) {
                return data.getTask(taskId).done(function (t) {
                    mapper.fromJS(t, task);
                }).fail(function () {});
            } else {
                mapper.fromJS({
                    ID: 0,
                    ProjectID: projectId,
                    Name: '',
                    Description: ''
                }, task);
            }
        },

        deactivate = function () {};

    return {
        // Place your public properties here
        task: task,
        isBusy: isBusy,
        save: save,
        activate: activate,
        deactivate: deactivate
    };
});
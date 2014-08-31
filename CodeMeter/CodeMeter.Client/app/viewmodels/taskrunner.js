define(["jquery", "knockout", "durandal/app", "durandal/system", "plugins/router", "services/data"], function ($, ko, app, system, router, data) {
    var
        // Properties
        taskName = ko.observable(''),
        taskId,
        // Handlers

        // Lifecycle

        activate = function (taskId) {
            return data.getLastTaskRun(taskId).done(function(task){
                taskId = task.ID,
                taskName(task.Name);
            }).fail(function(){});
        },

        deactivate = function () {
        };

    return {
        // Place your public properties here
        activate: activate,
        deactivate: deactivate,
        taskName: taskName
    };
});

define(["jquery", "knockout", "durandal/app", "durandal/system", "plugins/router", "services/data"], function ($, ko, app, system, router, data) {
    var
        // Properties
        tasks = ko.observableArray([]),
        projectName = ko.observable(''),
        onEditTask = function(task) {
            router.navigate('#task/' + task.ID);
        },
        onDeleteTask = function (task) {
            app.showMessage("Are you sure?", null, ["No", "Yes"]).then(function(answer) {
                http.deleteTask(task.ID).done(function() {
                    tasks.remove(task);
                }).fail(function(){}); 
            });
        },
        onCreateNewTask = function () {
            router.navigate("#task");  
        },
        onGotoToTask = function (task) {
            router.navigate("#taskrunner/" + task.ID);
        },
        onTaskDetails = function (task) {
        
        },
        // Handlers

        // Lifecycle

        activate = function (project) {
            return data.getTasks(project).done(function(project) {
                projectName(project.Name);
                tasks(project.Tasks);
            }).fail(function(){});
        },

        deactivate = function () {
        };

    return {
        // Place your public properties here
        tasks: tasks,
        projectName: projectName,
        activate: activate,
        deactivate: deactivate,
        onEditTask: onEditTask,
        onDeleteTask: onDeleteTask,
        onCreateNewTask: onCreateNewTask,
        onGotoToTask: onGotoToTask,
        onTaskDetails: onTaskDetails
    };
});

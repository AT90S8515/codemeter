define(["jquery", "knockout", "durandal/app", "durandal/system", "plugins/router", "services/data", "moment", "utils/utils"], function ($, ko, app, system, router, data, moment, utils) {
    var
        // Properties
        tasks = ko.observableArray([]),
        projectName = ko.observable(''),
        projectId,
        refresh,
        timer,
        onEditTask = function(task) {
            router.navigate('#task/' + projectId + '/' + task.ID);
        },
        onDeleteTask = function (task) {
            app.showMessage("Are you sure?", null, ["No", "Yes"]).then(function(answer) {
                data.deleteTask(task.ID).done(function() {
                    tasks.remove(task);
                }).fail(function(){}); 
            });
        },
        onCreateNewTask = function () {
            router.navigate("#task/" + projectId);  
        },
        onGotoToTask = function (task) {
            router.navigate("#taskrunner/" + task.ID);
        },
        onTaskDetails = function (task) {
        
        },
        load = function (project) {
            return data.getTasks(project).done(function(project) {
                projectId = project.ID;
                projectName(project.Name);
                project.Tasks.forEach(function(task, ix) {
                    task.StartTime = task.StartTime ? moment(task.StartTime).format("DD.MM.YY HH:mm:ss") : 'N/A';
                    task.EndTime = task.EndTime ? moment(task.EndTime).format("DD.MM.YY HH:mm:ss") : 'N/A';
                    task.Elapsed = utils.formatTime(task.ElapsedSeconds);
                })
                tasks(project.Tasks);
            }).fail(function(){});
        },
        // Handlers

        // Lifecycle

        activate = function (project) {
            app.on('refresh').then(function() {load(project);});
            timer = setInterval(function() {
                load(project);
            }, 30 * 1000);
            return load(project);
        },

        deactivate = function () {
            refresh.off();
            clearInterval(timer);
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

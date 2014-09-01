define(["jquery", "knockout", "durandal/app", "durandal/system", "plugins/router", "services/data", "utils/utils"], function ($, ko, app, system, router, data, utils) {
    var
        // Properties
        timer,
        refresh,
        projects = ko.observableArray([]),
        // Handlers
        onCreateNew = function () {
            router.navigate('#project');   
        },
        onGotoProject = function (project) {
            router.navigate("#tasks/" + project.ID);  
        },
        onEditProject = function (project) {
            router.navigate("#project/" + project.ID);  
        },
        onDeleteProject = function (project) {
            app.showMessage("Do you really want to delete project?", null, ["No", "Yes"]).then(function(result) {
                if (result === "Yes") {
                    data.deleteProject(project.ID).done(function(){
                        projects.remove(project);
                    }).fail(function() {});
                }
            });
        },
        load = function () {
            return data.getProjects().done(function(data) {
                data.forEach(function(proj) {
                   proj.TotalTime = utils.formatTime(proj.TotalTime);
                   proj.Total = Math.round(proj.Total, 2);
                });
                projects(data);   
            }).fail(function(err) {
            
            });
        }
        // Lifecycle

        activate = function () {
            refresh = app.on('refresh').then(load);
            timer = setInterval(load, 30 * 1000);
            return load();
        },

        deactivate = function () {
            refresh.off();
            clearInterval(timer);
        };

    return {
        // Place your public properties here
        activate: activate,
        deactivate: deactivate,
        projects: projects,
        onCreateNew: onCreateNew,
        onGotoProject: onGotoProject,
        onEditProject: onEditProject,
        onDeleteProject: onDeleteProject
    };
});

define(['plugins/router', "durandal/app"], function (router, app) {
    var
    
        refresh = function() {
            app.trigger('refresh');
        };
    
    return {
        router: router,
        refresh : refresh,
        search: function () {
            app.showMessage("Not Implemented", "Error");
        },

        activate: function () {
            router.map([
                /*{
                    route: '',
                    moduleId: 'viewmodels/home',
                    title: "Home",
                    nav: true
                },*/
                {
                    "route": "",
                    "moduleId": "viewmodels/projects",
                    "title": "Projects",
                    "nav": true
                },
                {
                    "route": "project(/:id)",
                    "moduleId": "viewmodels/project",
                    "title": "Project",
                    "nav": false
                },
                {
                    "route": "tasks/:projectId",
                    "moduleId": "viewmodels/tasks",
                    "title": "Tasks",
                    "nav": false
                },
                {
                    "route": "task/:projectId(/:taskId)",
                    "moduleId": "viewmodels/task",
                    "title": "Task",
                    "nav": false
                },
                {
                    "route": "taskrunner/:taskId",
                    "moduleId": "viewmodels/taskrunner",
                    "title": "Task runner",
                    "nav": false
                },
                {"route":"configuration","moduleId":"viewmodels/configuration","title":"Configuration","nav":false},
                /*{durandal:routes}*/
            ]).buildNavigationModel();

            return router.activate();
        }
    };
});
define(['plugins/router', "durandal/app"], function (router, app) {
    return {
        router: router,

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
                    "route": "task(/:id)",
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
                /*{durandal:routes}*/
            ]).buildNavigationModel();

            return router.activate();
        }
    };
});
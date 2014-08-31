define(['plugins/http'], function(http) {
    //var url = "http://localhost:52214/api/";
    var url = "http://codemeter.brizb.rs/api/";
    return {
        getProjects: function() {
            return http.get(url + 'projects');
        },
        getProject: function(id) {
            return http.get(url + 'projects', {id: id});   
        },
        saveProject: function(project) {
            return http.post(url + 'projects', project);   
        },
        updataProject: function(project) {
            return http.put(url + 'projects', project);  
        },
        deleteProject: function(id) {
            return http.remove(url + 'projects/' + id);   
        },
        getTasks: function(projectId) {
            return http.get(url + 'project/' + projectId + '/tasks');   
        },
        getTask: function(taskId) {
            return http.get(url + 'project/0/tasks/' + taskId);   
        },
        getLastTaskRun: function (taskId) {
            return http.get(url + 'task/lastRun/' + taskId);
        },
        insertTask: function (task) {
            return http.post(url + 'project/' + task.ProjectID() + '/tasks/', task);   
        },
        updateTask: function (task) {
            return http.put(url + 'project/' + task.ProjectID() + '/tasks/' + task.ID(), task);  
        },
        deleteTask: function (id) {
            return http.remove(url + 'project/0/tasks/' + id);   
        },
        startTask: function (id) {
            return http.put(url + 'task/StartTask/' + id);   
        },
        stopTask: function (id) {
             return http.put(url + 'task/EndTask/' + id); 
        }
    };
})
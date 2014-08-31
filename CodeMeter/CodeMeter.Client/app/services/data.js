define(['plugins/http'], function(http) {
    var url = "http://localhost:52214/api/";
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
        }
    };
})
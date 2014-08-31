define(["jquery", "knockout", "durandal/app", "durandal/system", "plugins/router", "services/data", "moment", "utils/utils"], function ($, ko, app, system, router, data, moment, utils) {
    var
    // Properties
        taskName = ko.observable(''),
        TIME_FORMAT = "DD.MM.YYYY HH:mm:ss",
        tId,
        projectId,
        error = ko.observable(''),
        isRunning = ko.observable(false),
        timer,
        started = ko.observable('N/A'),
        ended = ko.observable('N/A'),
        elapsedTime,
        elapsed = ko.observable('00:00:00'),

        formatTime = function (timeDiff) {
            
        },
        startTimer = function() {
            isRunning(true);
                timer = setInterval(function () {
                    elapsedTime += 1;
                    elapsed(utils.formatTime(elapsedTime));
                }, 1000, true);
        },
        // Handlers
        start = function () {
            if (isRunning()) return;
            data.startTask(tId).done(startTimer).fail(function (err) {
                error(err.responseText);
            });

        },
        pause = function () {
            if (!isRunning()) return;
            data.stopTask(tId).done(function (task) {
                elapsedTime = task.ElapsedSeconds;
                formatTime(elapsedTime);
                ended(moment(task.EndTime).format(TIME_FORMAT));
                isRunning(false);
                clearInterval(timer);
            }).fail(function () {});

        },
        stop = function () {
            pause();
            router.navigate("#tasks/" + projectId);
        },
        // Lifecycle

        activate = function (taskId) {
            error('');
            return data.getLastTaskRun(taskId).done(function (task) {
                tId = task.ID;
                projectId = task.ProjectID;
                taskName(task.Name);
                elapsedTime = task.ElapsedSeconds;
                elapsed(utils.formatTime(elapsedTime));
                started(task.StartTime ? moment(task.StartTime).format(TIME_FORMAT) : 'N/A')
                ended(task.EndTime ? moment(task.EndTime).format(TIME_FORMAT): 'N/A')
                if (task.IsRunning) {
                    startTimer();   
                }
            }).fail(function () {});
        },

        deactivate = function () {
            clearInterval(timer);
        };

    ko.computed

    return {
        // Place your public properties here
        activate: activate,
        deactivate: deactivate,
        taskName: taskName,
        start: start,
        pause: pause,
        stop: stop,
        elapsed: elapsed,
        isRunning: isRunning,
        error: error,
        started: started,
        ended: ended
        
    };
});
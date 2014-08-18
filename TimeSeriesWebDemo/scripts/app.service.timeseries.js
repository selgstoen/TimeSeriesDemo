window.app = window.todoApp || {};

window.app.timeseriesservice = (function () {
    function ajaxRequest(type, url, data) {
        var options = {
            url: url,
            headers: {
                Accept: "application/json"
            },
            contentType: "application/json",
            cache: false,
            type: type,
            data: data ? ko.toJSON(data) : null
        };
        return $.ajax(options);
    }

    return {
        all : function() {
            return ajaxRequest('get', '/api/DemoTimeSeries/' );
        }
    }
})();
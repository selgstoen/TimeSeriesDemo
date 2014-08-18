

function DemoTimeSeries(data) {
    var self = this;
    data = data || {};

    self.Id = data.Id;
    self.Source = data.Source;
    self.Values = data.Values;
}

function GetDataFromServer() {
    return app.timeseriesservice.all();
}

var ViewModel = function() {
    var self = this;
    self.demoTimeSeries = ko.observableArray();

    GetDataFromServer().success(function (data) {
        var mapped = ko.utils.arrayMap(data, function (item) {
            return new DemoTimeSeries(item);
        });
        self.demoTimeSeries(mapped);
    });;
}

ko.applyBindings(ViewModel);

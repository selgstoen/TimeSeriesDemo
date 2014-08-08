function DemoTimeSeries(data) {
    var self = this;
    data = data || {};

    self.id = data.id;
    self.source = data.source;
    self.values = data.values;
}

function getDemoData(id) {
    var ts = new Object();
    ts.id = id;
    ts.source = 'Brady';
    ts.values = [1, 2, 3];

    return ts;
}

var ViewModel = function() {
    var self = this;

    self.demoTimeSeries = ko.observableArray();

    function addDemoTimeSeries(data) {
        //var jsonData = JSON.stringify(data);
        //var mapped = ko.utils.arrayMap(jsonData, function(item) {
        //var mapped = ko.mapping.fromJS(jsonData, function (item){
        //    return new DemoTimeSeries(item);
        //});
        var m = new DemoTimeSeries(data);
        self.demoTimeSeries.push(m);
    }

    addDemoTimeSeries(getDemoData(123));
    addDemoTimeSeries(getDemoData(456));
}

ko.applyBindings(new ViewModel());

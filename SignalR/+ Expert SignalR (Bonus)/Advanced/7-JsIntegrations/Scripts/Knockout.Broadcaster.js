var BroadcasterViewModel = function (hub) {
    var self = this;
    self.ready = ko.observable(false);
    self.text = ko.observable("");
    self.send = function () {
        if (self.ready()) {
            hub.server.broadcast(self.text()).done(function() {
                self.text("");
            });
        }
    };
    self.messages = ko.observableArray();
            
    hub.client.message = function(msg) {
        self.messages.push(msg);
    };
    self.start = function() {
        $.connection.hub.start().done(function() {
            self.ready(true);
        });
    };
};

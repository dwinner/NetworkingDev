angular.module('angularDemo', [])
    .factory('hub', function () {
        return {
            start: function (successCallback) {
                $.connection.hub.start().done(successCallback);
            },
            broadcast: function (msg) {
                $.connection.broadcaster.server.broadcast(msg);
            },
            messageReceived: function (callback) {
                $.connection.broadcaster.client.message = callback;
            }
        };
    });

function BroadcasterController($scope, hub) {
    $scope.ready = false;
    $scope.text = "";
    $scope.messages = [];
    $scope.send = function () {
        if ($scope.ready) {
            hub.broadcast($scope.text);
            $scope.text = "";
        }
    };
    $scope.start = function () {
        hub.start(function () {
            $scope.$apply(function () {
                $scope.ready = true;
            });
        });
    };
    hub.messageReceived(function (msg) {
        $scope.$apply(function () {
            $scope.messages.push(msg);
        });
    });
}

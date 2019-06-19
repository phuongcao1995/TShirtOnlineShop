(function () {
    var app = angular.module('App', ['angularUtils.directives.dirPagination']);
    app.controller('MenController', ['$scope', '$http', '$q', function ($scope, $http, $q) {
        init();    
        function init() {
            var type = document.getElementById("type").value;
            LongSleeves(type);
        };
        function LongSleeves(type) {
            var $def = $q.defer();
            $http.get('/Men/Data', { params: { type: type}}).then(function (response) {
                $def.resolve(response.data);
                $scope.listData = response.data;
                console.log($scope.listData);
            }, function () {
                $def.reject('Error getting roles');
            });
            return $def.promise;

        }

    }]);
})();

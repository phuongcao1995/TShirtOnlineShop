(function () {
    var app = angular.module('App', ['angularUtils.directives.dirPagination']);
    app.controller('MenController', ['$scope', '$http', '$q', function ($scope, $http, $q) {
        init();
        function init() {
            LongSleeves();
        };
        function LongSleeves() {
            var $def = $q.defer();
            $http.get('/Men/Data', { params: { type: 1}}).then(function (response) {
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

(function () {
    var app = angular.module('App', ['angularUtils.directives.dirPagination']);
    app.controller('MenController', ['$scope', '$http', '$q', function ($scope, $http, $q) {
        var type = document.getElementById("type").value;
        init();    
        function init() {
          
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
        $scope.Find = function (search) {
            console.log(search)
            var $def = $q.defer();
            $http.get('/Men/Data', { params: { size: search.size, colors: search.colors, price: search.price, type: type } }).then(function (response) {
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

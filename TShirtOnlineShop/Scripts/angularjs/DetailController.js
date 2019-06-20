(function () {
    var app = angular.module('App');
    app.controller('DetailController', ['$scope', '$http', '$q', function ($scope, $http, $q) {
        init();
        function init() {
            var id = document.getElementById("productId").value;
            Detail(id);
        };

        function Detail(id) {
            var $def = $q.defer();
            $http.get('/Men/ProductDetail', { params: { id: id } }).then(function (response) {
                $def.resolve(response.data);
                $scope.productDetail = response.data.product;
                $scope.anotherProduct = response.data.anotherProduct;
                console.log($scope.productDetail);
            }, function () {
                $def.reject('Error getting roles');
            });
            return $def.promise;
        }

        $scope.AddCart = function (id, name) {
            var $def = $q.defer();
            $http.get('/Order/AddCart', { params: { productId: id, productName: name } }).then(function (response) {
                $def.resolve(response.data);
                console.log(response.data);
            }, function () {
                $def.reject('Error getting roles');
            });
            return $def.promise;
        }
    }]);
})();

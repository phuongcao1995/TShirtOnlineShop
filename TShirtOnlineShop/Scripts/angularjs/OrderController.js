(function () {
    var app = angular.module('App');
    app.controller('OrderController', ['$scope', '$http', '$q', function ($scope, $http, $q) {
        init();
        function init() {
            ShoppingCart();
        };
        $scope.CheckOut = function (ShoppingCart) {
            var $def = $q.defer();
            $http.post('/Order/CheckOutOrder', { ShoppingCart: ShoppingCart }).then(function (response) {
                $def.resolve(response.data);
                window.location.href = "/Order/Shipping";
            }, function () {
                $def.reject('Error getting roles');
            });
            return $def.promise;
        }
        function ShoppingCart() {
            var $def = $q.defer();
            $http.get('/Order/GetShoppingCart').then(function (response) {
                $def.resolve(response.data);
                $scope.ShoppingCart = response.data;
                $scope.Subtotal = function () {
                    var total = 0;
                    for (var i = 0; i < $scope.ShoppingCart.length; i++) {
                        var product = $scope.ShoppingCart[i].Product;
                        total += (1 - product.PromotionPrice / 100) * product.Price * $scope.ShoppingCart[i].Quantity;
                    }
                    return total;
                }

            }, function () {
                $def.reject('Error getting roles');
            });
            return $def.promise;
        }


        $scope.removeProduct = function (productId) {

            var $def = $q.defer();
            $http.get('/Order/RemoveProduct', { params: { productId: productId } }).then(function (response) {
                $def.resolve(response.data);
                $scope.ShoppingCart = response.data;
                $scope.Subtotal = function () {
                    var total = 0;
                    for (var i = 0; i < $scope.ShoppingCart.length; i++) {
                        var product = $scope.ShoppingCart[i].Product;
                        total += (1 - product.PromotionPrice / 100) * product.Price * $scope.ShoppingCart[i].Quantity;
                    }
                    return total;
                }

            }, function () {
                $def.reject('Error getting roles');
            });
            return $def.promise;
        }

    }]);
})();

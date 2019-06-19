(function () {
    var app = angular.module('AppAdmin', ['angularUtils.directives.dirPagination']);
    app.controller('ProductController', ['$scope', '$http', '$q', function ($scope, $http, $q) {

        init();
        function init() {
            $scope.itemsPerPage = 10;
                var $def = $q.defer();
                $http.get('/Admin/Product/Data').then(function (response) {
                    $def.resolve(response.data);
                    $scope.listProduct = response.data;
                    console.log($scope.listProduct);
                }, function () {
                    $def.reject('Error getting roles');
                });
                return $def.promise;

        }

        function ListLog(data) {
            $scope.listProduct = data;
        }
        $scope.GetCategory = function (type) {
            var $def = $q.defer();
            $http.get('/Admin/Product/GetCategoryByType', { params: { type: type } }).then(function (response) {
                $def.resolve(response.data);
                $scope.listCategory = response.data;
                console.log($scope.listCategory)
            }, function () {
                $def.reject('Error getting roles');
            });
            return $def.promise;
        }

        function ShowMessage(data) {
            if (data.status === 1) {
                $.notify(data.message, "success");
            } else {
                $.notify(data.message, "error");
            }

        }
        $scope.AddProduct = function (product, m) {
            console.log(product);
            var $def = $q.defer();
            $http.post('/Admin/Product/AddProduct', { product: product }).then(function (response) {
                init();
                $(m).modal("hide");
                $.notify("Added product successlly ", "success");
                console.log($scope.listProduct);
            }, function () {
                $def.reject('Error getting roles');
            });
            return $def.promise;
        };

        $scope.OpenModalEdit= function (product) {          
            $scope.listCategory = $scope.GetCategory(product.Type);
            $scope.product = angular.copy(product);
            console.log($scope.product);
        };

        $scope.OpenModalDelete = function (product) {
            $scope.product = angular.copy(product);
        };

        $scope.EditProduct = function (product, m) {
            console.log(product);
            var $def = $q.defer();
            $http.post('/Admin/Product/EditProduct', { product: product }).then(function (response) {
                init();
                $(m).modal("hide");
                $.notify("Edited product successlly ", "success");
                console.log($scope.listProduct);
            }, function () {
                $def.reject('Error getting roles');
            });
            return $def.promise;
        };

        $scope.DeleteProduct = function (product, m) {
            console.log(product);
            var $def = $q.defer();
            $http.post('/Admin/Product/DeleteProduct', { product: product }).then(function (response) {
                init();
                $(m).modal("hide");
                $.notify("Deleted product successlly ", "success");
                console.log($scope.listProduct);
            }, function () {
                $def.reject('Error getting roles');
            });
            return $def.promise;
        };
 

    }]).directive("fileread", [function () {
        return {
            scope: {
                fileread: "="
            },
            link: function (scope, element, attributes) {
                element.bind("change", function (changeEvent) {
                    var reader = new FileReader();
                    reader.onload = function (loadEvent) {
                        scope.$apply(function () {
                            scope.fileread = loadEvent.target.result;
                        });
                    }
                    reader.readAsDataURL(changeEvent.target.files[0]);
                });
            }
        }
    }]);;
})();
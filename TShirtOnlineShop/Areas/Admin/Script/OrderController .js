(function () {
    var app = angular.module('AppAdmin', ['angularUtils.directives.dirPagination']);
    app.controller('OrderController', ['$scope', '$http', '$q', function ($scope, $http, $q) {

        init();
        function init() {
            //$scope.itemsPerPage = 10;
                var $def = $q.defer();
                $http.get('/Admin/Order/Data').then(function (response) {
                    $def.resolve(response);
                    console.log(response.data);
                    $scope.listOrder = response.data;
                  
                }, function () {
                    $def.reject('Error getting roles');
                });
                return $def.promise;

        }

        //$scope.GetCategory = function (type) {
        //    var $def = $q.defer();
        //    $http.get('/Admin/Product/GetCategoryByType', { params: { type: type } }).then(function (response) {
        //        $def.resolve(response.data);
        //        $scope.listCategory = response.data;
        //        console.log($scope.listCategory)
        //    }, function () {
        //        $def.reject('Error getting roles');
        //    });
        //    return $def.promise;
        //}

        //function ShowMessage(data) {
        //    if (data.status === 1) {
        //        $.notify(data.message, "success");
        //    } else {
        //        $.notify(data.message, "error");
        //    }

        //}
        $scope.OpenViewDetail = function (orderDetail) {
            console.log(orderDetail);
            $scope.orderDetail = orderDetail;
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
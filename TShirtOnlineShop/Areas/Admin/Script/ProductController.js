(function () {
    var app = angular.module('AppAdmin', ['angularUtils.directives.dirPagination']);
    app.controller('ProductController', ['$scope', '$http', '$q', function ($scope, $http, $q) {

        init();
        function init() {
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


        function ShowMessage(data) {
            if (data.status === 1) {
                $.notify(data.message, "success");
            } else {
                $.notify(data.message, "error");
            }

        }
        $scope.AddProduct = function (product, m) {
            var $def = $q.defer();
            $http.get('/Admin/Product/AddProduct').then(function (response) {
                $def.resolve(response.data);
                $scope.listProduct = response.data;
                console.log($scope.listProduct);
            }, function () {
                $def.reject('Error getting roles');
            });
            return $def.promise;
           // $(m).modal("hide");
            //homeService.AddLog(log).then(function (response) {
            //   // ShowMessage(response);
            //   // homeService.GetAllLog().then(ListLog).finally(commonService.EndLoading);
               
            //});
        };

        $scope.OpenModalUpdate = function (log) {
            log.NotificationDate = new Date(log.NotificationDate);
            log.IncidentDate = new Date(log.IncidentDate);
            $scope.log = angular.copy(log);
        };

        $scope.OpenModalDelete = function (log) {
            log.NotificationDate = new Date(log.NotificationDate);
            log.IncidentDate = new Date(log.IncidentDate);
            $scope.log = angular.copy(log);
        };

        $scope.UpdateLog = function (log, m) {
            commonService.StartLoading();
            homeService.UpdateLog(log).then(function (response) {
                ShowMessage(response);
                homeService.GetAllLog().then(ListLog).finally(commonService.EndLoading);
                $(m).modal("hide");
            });
        };

        $scope.DeleteLog = function (log, m) {
            commonService.StartLoading();
            homeService.DeleteLog(log).then(function (response) {
                ShowMessage(response);
                homeService.GetAllLog().then(ListLog).finally(commonService.EndLoading);
                $(m).modal("hide");
            });
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
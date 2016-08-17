/// <reference path="../libs/angular.js" />

(function (app) {
    app.controller("productController", productController);

    function productController($scope, apiService) {
        $scope.products = [];
        $scope.product = {};
        $scope.flag = false;
        $scope.flagAdd = false;

        $scope.showAdd = function () {
            $scope.flag = true;
            $scope.flagAdd = true;
            $scope.product = {};
        }

        $scope.addProduct = function () {
            apiService.addProduct("/api/product/add", $scope.product, function (result) {
                $scope.products.push(result.data);
            });
        }

        $scope.getAll = function () {
            apiService.getAll("/api/product/getall", function (result) {
                $scope.products = result.data;
            });
        };

        $scope.getById = function (params) {
            $scope.flag = true;
            $scope.flagAdd = false;
            apiService.getById("/api/product/getbyid", params, function (result) {
                $scope.product = result.data;
            });
        }

        $scope.updateProduct = function (flagAdd) {
            if ($scope.flagAdd) {
                $scope.addProduct();
            }
            else {
                apiService.updateProduct("/api/product/update", $scope.product, function (result) {
                    //Try to update Products in $scope.products
                    $scope.products.forEach(function (e, index) {
                        if (e.Id === result.data.Id) {
                            $scope.products[index].Name = result.data.Name;
                            $scope.products[index].Category = result.data.Category;
                            $scope.products[index].Price = result.data.Price;
                            $scope.products[index].Status = result.data.Status;
                        }
                    });
                });
            }

            $scope.flag = false;
            $scope.flagAdd = false;
            $scope.product = {};
        }

        $scope.deleteProduct = function (id) {
            if (confirm("Aru your sure?")) {
                apiService.deleteProduct("/api/product/delete", id, function (result) {
                    $scope.products.forEach(function (e, index) {
                        if (e.Id === result.data.Id) {
                            $scope.products.splice(index, 1);
                        }
                    });
                });
            }
            return false;
        }
    };

    app.directive("listProductView", listProductView);
    app.directive("addProductView", addProductView);

    function listProductView() {
        return {
            templateUrl: "/app/controller/listProductView.html"
        }
    };

    function addProductView() {
        return {
            templateUrl: "/app/controller/addProductView.html"
        }
    };
})(angular.module("product.module"));
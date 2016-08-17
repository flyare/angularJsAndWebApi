(function (app) {
    app.service("apiService", apiService);
    apiService.$inject = ["$http"];

    function apiService($http) {
        return {
            getAll: getAll,
            getById: getById,
            updateProduct: updateProduct,
            deleteProduct: deleteProduct,
            addProduct: addProduct
        }

        function addProduct(url, params, success, failure) {
            $http.post(url, params).then(function(result) {
                success(result);
            });
        }

        function deleteProduct(url, params, success, failure) {
            url = url + "?id=" + params;
            $http.delete(url).then(function (result) {
                success(result);
            });
        }

        function updateProduct(url, params, success, failure) {
            $http.put(url, params).then(function (result) {
                success(result);
            });
        }

        function getAll(url, success, failure) {
            $http.get(url).then(function (result) {
                success(result);
            }, function (error) {
                failure(error);
            });
        }

        function getById(url, params, success, failure) {
            url = url + "?id=" + params;

            $http.get(url).then(function (result) {
                return success(result);
            });
        }
    }
})(angular.module("product.module"));
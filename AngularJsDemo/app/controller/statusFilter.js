(function(app) {
    app.filter("statusFilter", function() {
        return function (input) {
            return input ? "Active" : "Inactive";
        }
    });

})(angular.module("product.module"));
(function(app) {
    app.filter("currencyVND", function() {
        return function(input) {
            return input + " VND";
        }
    });
})(angular.module("product.module"))
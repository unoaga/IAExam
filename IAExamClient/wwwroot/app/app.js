(function () {
    var app = angular.module('IAApp', ['ngRoute', 'toastr']); 
      
    app.constant('API_URL', 'https://localhost:5001/api/'); 

    app.config(function ( $routeProvider) {

        
        $routeProvider

            .when('/', {
                templateUrl: '/app/views/order.html',
                controller: 'OrderController'
            })

            .when('/products', {
                templateUrl: '/app/views/product.html',
                controller: 'ProductController'
            }) 

            .otherwise({ redirectTo: '/' });
    });
})();


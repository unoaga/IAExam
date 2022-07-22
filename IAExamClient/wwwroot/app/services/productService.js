

(function () {
    'use strict';

    angular
        .module('IAApp')
        .factory('ProductService', product);

    product.$inject = ['$http', 'API_URL'];

    function product($http, API_URL) {
        var service = {
            get: get,
            add: add,
            update: update,
            addStockProduct: addStockProduct,
            getById: getById,
            delete: deleteRow,
            base: API_URL + "product"
        };

        return service;




        function get(search) {
            return $http({
                method: 'GET',
                url: `${service.base}?search=${search}`,
                headers: { 'Content-Type': 'application/json' },
                contentType: "application/json",
            });
        }

        function getById(id) {
            return $http({
                method: 'GET',
                url: `${service.base}/getbyid?id=${id}`,
                headers: { 'Content-Type': 'application/json' },
                contentType: "application/json",
            });
        }


        function deleteRow(id) {
            return $http({
                method: 'DELETE',
                url: `${service.base}?id=${id}`,
                headers: { 'Content-Type': 'application/json' },

            });
        }
        function add(row) {
            return $http({
                method: 'POST',
                url: service.base,
                data: row,
                headers: { 'Content-Type': 'application/json' },

            });
        }

        function update(row) {
            return $http({
                method: 'PUT',
                url:  service.base,
                data: row,
                headers: { 'Content-Type': 'application/json' },

            });
        }


        function addStockProduct(id, quantity) {
            return $http({
                method: 'PUT',
                url: `${service.base}/addtostock?id=${id}&quantity=${quantity}`,
                data: {},
                headers: { 'Content-Type': 'application/json' },

            });
        }
    }
})();
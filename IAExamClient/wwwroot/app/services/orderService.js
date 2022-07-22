 

(function () {
    'use strict';

    angular
        .module('IAApp')
        .factory('OrderService', order);

    order.$inject = ['$http','API_URL'];

    function order($http, API_URL) {
        var service = {
            get: get,
            add: add, 
            getById: getById,
            cancel: cancel,
            nextStatus: nextStatus,
            getStatus: getStatus,
            update: update,
            base: API_URL+"order"
        };

        return service;  

        function get(search, status) {
            return $http({
                method: 'GET',
                url: `${service.base}?search=${search}&status=${status}`,
                headers: { 'Content-Type': 'application/json' },
                contentType: "application/json",
            });
        }

        function getStatus() {
            return $http({
                method: 'GET',
                url: `${service.base}/getstatus`,
                headers: { 'Content-Type': 'application/json' },
                contentType: "application/json",
            });
        }

        function getById(id) {
            return $http({
                method: 'GET',
                url: `${service.base}/getbyid?id=${id}` ,
                headers: { 'Content-Type': 'application/json' },
                contentType: "application/json",
            });
        }
   

        function cancel(id) {
            return $http({
                method: 'DELETE',
                url: `${service.base}?id=${id}`,
                headers: { 'Content-Type': 'application/json' },

            });
        }

        function nextStatus(id) {
            return $http({
                method: 'PUT',
                url: `${service.base}/nextStep?id=${id}`,
                data: {},
                headers: { 'Content-Type': 'application/json' },

            });
        }


        function add(row) {
            return $http({
                method: 'POST',
                url: service.base ,
                data: row,
                headers: { 'Content-Type': 'application/json' },

            });
        }

        function update(row) {
            return $http({
                method: 'PUT',
                url: service.base,
                data: row,
                headers: { 'Content-Type': 'application/json' },

            });
        }

    }
})();
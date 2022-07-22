(function () {
    angular.module('IAApp')
        .controller('OrderController', function ($scope, toastr, OrderService, ProductService) {
            var vm = this;
            vm.title = "Orders";
            vm.statusOrders = [];
            vm.selectedTab = 0;  
            vm.orderList = [];
            vm.products = [];
            vm.orderSelected = {};
            vm.modalTitle = "Add Order";   
            vm.msgSucces = "Data saved";

            vm.SelectTab = function (i,status) {
                vm.selectedTab = i;
                vm.loadOrders("", status);
               
            };

            vm.loadOrders = (search, status) => {
                OrderService.get(search, status).then(function (response) {
                    vm.orderList  = response.data;
                }).catch(function (e) {
                    toastr.error(e.data, 'Error');
                })

            }

            vm.getStatus = () => {
                OrderService.getStatus().then(function (response) {
                    vm.statusOrders = response.data;
                }).catch(function (e) {
                    toastr.error(e.data, 'Error');
                })

            }

            vm.nextStatus = (id, index) => {
                OrderService.nextStatus(id).then(function (response) {
                    toastr.success(vm.msgSucces, 'Success');
                    vm.orderList.splice(index, 1);
                }).catch(function (e) {
                    toastr.error(e.data, 'Error');
                }) 
            }

            vm.cancelOrder = (id,index) => {
                OrderService.cancel(id).then(function (response) {
                    toastr.success(vm.msgSucces, 'Success');
                    vm.orderList.splice(index, 1);
                }).catch(function (e) {
                    toastr.error(e.data, 'Error');
                }) 
            }

           

            vm.addOrder = (form) => {
                form.$submitted = true;
                if (!form.$valid)
                    return;

           
                OrderService.add(vm.orderSelected).then(function (response) {
                    if (vm.selectedTab==0)
                        vm.orderList.push(response.data);
                    else
                        vm.SelectTab(0,1);
                    $('#orderModal').modal('hide');
                    toastr.success(vm.msgSucces, 'Success');
                    form.$submitted = false;
                }).catch(function (e) {
                    toastr.error(e.data, 'Error');
                }) 
            }

            vm.loadProducts = () => {
                ProductService.get("").then(function (response) {
                    vm.products = response.data;
                })

            }

            vm.prepareAdd = () => {
                vm.loadProducts(); 
                vm.orderSelected = {}; 
            }
            vm.addRemoveProduct = (isAdd, product) => {
                if (isAdd) {
                    product.quantity = product.quantity ?? 0;
                    if (product.stock > product.quantity)
                        ++product.quantity
                    else
                        toastr.error("Not enough " + product.name + " in stock", 'Error');
                } else {
                    if (product.quantity)
                        --product.quantity 
                }
                vm.orderSelected.orderProducts = vm.products.filter(y => y.quantity).map((x) => {
                    return { idProduct: x.id, quantity: x.quantity }
                });
            }

            vm.getStatus()
            vm.loadOrders("", 1);
        });
})();
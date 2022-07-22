(function () {
    angular.module('IAApp')
        .controller('ProductController', function ($scope, toastr, ProductService) {
            var vm = this;
            vm.title = "Products";
            vm.modalTitle = "Update Product";
            vm.products = [];
            vm.productSelected = {};
            vm.indexSelected = -1;
            vm.stockQuantity = 0;
            vm.msgSucces = "Data saved";
            vm.loadProducts = () => {
                ProductService.get("").then(function (response) {  
                    vm.products = response.data; 
                })

            }

       

            vm.saveProduct = (form) => {
                form.$submitted = true;
                if (!form.$valid)
                    return;

                if (vm.modalTitle == "Update Product") {
                    vm.updateProduct(form);
                } else {
                    vm.addProduct(form);
                }

            }

            vm.addStockProduct = () => {
                ProductService.addStockProduct(vm.productSelected.id, vm.stockQuantity ).then(function (response) {
                    vm.products[vm.indexSelected] = response.data;
                    $('#addStockModal').modal('hide');
                    toastr.success(vm.msgSucces, 'Success');
                }).catch(function (e) {
                    toastr.error(e.data, 'Error');
                })
            }

            vm.updateProduct = (form) => {
                ProductService.update(vm.productSelected).then(function (response) {
                    vm.products[vm.indexSelected] = response.data;
                    $('#productModal').modal('hide');
                    toastr.success(vm.msgSucces, 'Success');
                    form.$submitted = false;
                }).catch(function (e) {
                    toastr.error(e.data, 'Error');
                })
            }


            vm.addProduct = (form) => {
                ProductService.add(vm.productSelected).then(function (response) {
                    vm.products.push(response.data);
                    $('#productModal').modal('hide');
                    toastr.success(vm.msgSucces, 'Success');
                    form.$submitted = false;
                }).catch(function (e) {
                    toastr.error(e.data, 'Error');
                })
            }
     
            vm.deleteProduct = ( ) => {
                ProductService.delete(vm.productSelected.id).then(function (response) { 
                    vm.products.splice(vm.indexSelected, 1);
                    $('#deleteModal').modal('hide');
                    toastr.success(vm.msgSucces, 'Success');
                }).catch(function (e) {
                    toastr.error(e.data, 'Error');
                })
            }


            vm.selectProduct = (item, index) => {
                vm.modalTitle = "Update Product";
                vm.productSelected = angular.copy(item);
                vm.indexSelected = index; 
                vm.stockQuantity = 0;
            }

            vm.prepareAdd = () => {
                vm.modalTitle = "Add Product";
                vm.productSelected = {};
                vm.indexSelected = -1;
            }


            vm.loadProducts();
        });
})();

var myapp = angular.module('myApp', []);

myapp.controller("EmployeeMainController", function ($scope, $http) {


    //Save employee details
    $scope.saveEmployeeDtails = function () {
        var data = new FormData();
        data.append('employeeName', $scope.employeeName);
        $.ajax({
            url: 'http://localhost:51279/api/Employee/SaveEmployeeDetails',
            processData: false,
            contentType: false,
            data: data,
            type: 'POST'
        }).done(function (data) {
            $('#loaderwrapper').hide();
            if (data.saveStatus === "true") {
                //do something
            }
            else {
                //do something
            }
        }).fail(function (a, b, c) {

        });

    }
    //End

    //View Employee details
    $scope.GetListofBlobs = function () {
        $scope.rowCollection = [];
        $scope.displayedCollection = [];
        var search = $scope.searchUploadsModel;//ng-modal in search input
        if (search === "" || search === undefined) {
            $scope.displayedCollection = [];
            var DocData = {};
            DocData.Blob_Container_Name = $scope.selectedOption.name;
            DocData.Employee_Name = logedUserCode;
            $http({
                method: 'POST',
                url: GetBlobDetailsLink,
                data: $.param(DocData),
                headers: {
                    'Content-Type': 'application/x-www-form-urlencoded',
                    'Authorization': 'Bearer ' + token
                }
            })
                .success(function (data) {
                    $scope.dispalyDocsFunction(data);
                    $('#loaderwrapper').hide();
                }).error(function () {
                    $('#loaderwrapper').hide();
                });
        }
        else {
            $scope.searchUploads();
        }
    }
    $scope.dispalyDocsFunction = function (data) {
        $scope.rowCollection = [];
        $scope.displayedCollection = [];
        for (var i = 0; i < data.length; i++) {
            $scope.rowCollection.push({
                docsName: data[i].Doc_Name,
                docsBarcode: data[i].Barcode_No,
                docsRackNo: data[i].Rack_No,
                docsCode: data[i].Doc_Code
            });
        }
    }
    //End



})
    .controller('DemoFileUploadController', [
        '$scope', '$http', '$filter', '$window',
        function ($scope, $http) {
            $scope.options = {
                url: url
            };
            $scope.loadingFiles = true;
            $http.get(url)
                .then(
                    function (response) {
                        $scope.loadingFiles = false;
                        $scope.queue = response.data.files || [];
                        //$scope.submitX($scope.queue);
                    }
                    ,
                    function () {
                        $scope.loadingFiles = false;
                    }
                );

        }
    ])
    .controller('FileDestroyController', [
        '$scope', '$http',
        function ($scope, $http) {
            var file = $scope.file,
                state;
            if (file.url) {
                file.$state = function () {
                    return state;
                };
                file.$destroy = function () {
                    state = 'pending';
                    return $http({
                        url: file.deleteUrl,
                        method: file.deleteType
                    }).then(
                        function () {
                            state = 'resolved';
                            $scope.clear(file);
                        },
                        function () {
                            state = 'rejected';
                        }
                    );
                };
            } else if (!file.$cancel && !file._index) {
                file.$cancel = function () {
                    $scope.clear(file);
                };
            }
        }
    ]);

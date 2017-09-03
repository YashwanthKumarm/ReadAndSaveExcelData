app.controller('mycontroller', function ($scope, $http, ExcelService) {
    $scope.SelectedFileForUpload = null;
    $scope.UploadFile = function (files) {
        $scope.$apply(function () {
            $scope.Message = "";
            $scope.SelectedFileForUpload = files[0];
        })
    }
    $scope.ParseExcelDataAndSave = function () {
        var file = $scope.SelectedFileForUpload;
        if (file) {
            var reader = new FileReader();
            reader.onload = function (e) {
                var data = e.target.result;
                var workbook = XLSX.read(data, { type: 'binary' });
                var sheetName = workbook.SheetNames[0];
                var excelData = XLSX.utils.sheet_to_row_object_array(workbook.Sheets[sheetName]);
                if (excelData.length>0) {
                    $scope.SaveData(excelData);
                }
                else {
                    $scope.Message = "No data found";
                }
            }
            reader.onerror=function(ex)
            {
                console.log(ex);
            }
            reader.readAsBinaryString(file);
        }
    }

    $scope.SaveData = function (excelData) {
        var ExcelInfo = ExcelService.saveExcelData(excelData);
        ExcelInfo.then(function (data) {
            if (data.status) {
                $scope.Message = excelData.length + " record inserted ";
            }
            else {
                $scope.Message = "Failed";
            }
        }, function (error) {
            $scope.Message = "Error";
        });
    }
});
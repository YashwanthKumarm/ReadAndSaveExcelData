app.service('ExcelService', function ($http) {
    this.saveExcelData = function (excelData) {
        var response = $http({
            method: 'Post',
            url: '/Test/ExcelSaveData',
            data: { preferredData: JSON.stringify(excelData) },
            headers: {
                'Content-Type': 'application/json'
            }
        });
        return response;
    }
})
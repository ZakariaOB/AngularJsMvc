angular.module('MyApp').controller('Part2Controller', function ($scope, ContactService) {
    $scope.contact = null;
    ContactService.GetLastContact().then(function (d) {
        $scope.contact = d.data;
    }, function () {
        alert('Failed to load contact');
    });
})
.factory('ContactService', function ($http) {
    var fac = {};
    fac.GetLastContact = function () {
        return $http.get('/Data/GetLastContact');
    }

    return fac;
});
var commonMod = angular.module('common', []);
commonMod.config(function ($httpProvider) {
    $httpProvider.defaults.transformRequest = function (obj) {
        var arr = [];

        for (var name in obj) {
            arr.push(`${encodeURIComponent(name)}=${encodeURIComponent(obj[name])}`);
        }

        return arr.join('&');
    };
    $httpProvider.defaults.headers.post['Content-Type'] = 'application/x-www-form-urlencoded';
});
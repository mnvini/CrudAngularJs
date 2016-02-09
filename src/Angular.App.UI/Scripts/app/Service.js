app.service("crudService", function ($http) {

    this.ObterTodosCelulares = function () {
        return $http.get('/api/v1/public/celulares');
    }

    this.ObterCelularPorId = function (id) {
        return $http.get('/api/v1/public/celular/'+id);
    }

    this.AtualizarCelular = function (celular) {
        var response = $http({
            method: 'put',
            url: '/api/v1/public/putCelular',
            data: JSON.stringify(celular),
            dataType: "json"
        });
        return response;
    }

    this.AdicionarCelular = function (celular) {
        var response = $http({
            method: 'post',
            url: '/api/v1/public/postCelular',
            data: JSON.stringify(celular),
            dataType: "json"
        });
        return response;
    }

    this.RemoverCelular = function (id) {
        return $http.delete('/api/v1/public/deleteCelular/' + id);
    }
});
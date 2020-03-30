$(document).ready(function () {
    $("#btnEditarPais").hide();
    $("#btnCancelarPais").hide();
    GetPais();
});

function Adicionar(data) {
    debugger
    if (data.success) {
        toastr.success(`<p><b>${data.mensagem}</b></p>`, ``);
        GetPais();
    }
    else {
        toastr.error(`<p><b>${data.mensagem}</b></p>`, ``);
    }
}

function GetPais() {
    $.ajax({
        method: "GET",
        url: "pais/listar",
        success: function (retorno) {
            if (retorno.hasOwnProperty("mensagem")) {
                toastr.error(`<p><b>${retorno.mensagem}</b></p>`, ``);
            }
            else {
                $("#gridPais").html(retorno);
            }
        },

        error: function (retorno) {
            toastr.error(`<p><b>${retorno}</b></p>`, ``);
        }
    });
}

function Excluir(id) {
    if (confirm("Todos os dados relacionados a esse país irão ser excluídos. Confirmar exclusão?")) {
        $.ajax({
            method: "DELETE",
            url: `pais/${id}`,
            success: function (retorno) {
                if (retorno.success) {
                    toastr.success(`<p><b>${retorno.mensagem}</b></p>`, ``);
                    GetPais();
                }
                else {
                    toastr.error(`<p><b>${retorno.mensagem}</b></p>`, ``);
                }
            },

            error: function (retorno) {
                toastr.error(`<p><b>${retorno}</b></p>`, ``);
            }
        });
    }
}

function Editar(id, descricao) {
    $("#idPais").val(id);
    $("#descricaoPais").val(descricao);
    $("#btnEditarPais").show();
    $("#btnCancelarPais").show();
    $("#btnSalvarPais").hide();
}

$("#btnCancelarPais").click(function () {
    $("#descricaoPais").val(null);
    $("#idPais").val(null);
    $("#btnEditarPais").hide();
    $("#btnCancelarPais").hide();
    $("#btnSalvarPais").show();
});

$("#btnEditarPais").click(function () {
    let dados = { Descricao: $("#descricaoPais").val(), Id: $("#idPais").val() };
    $.ajax({
        method: "PUT",
        url: `pais`,
        data: dados,
        success: function (retorno) {
            if (retorno.success) {
                toastr.success(`<p><b>${retorno.mensagem}</b></p>`, ``);
                $("#descricaoPais").val(null);
                $("#idPais").val(null);
                $("#btnEditarPais").hide();
                $("#btnCancelarPais").hide();
                $("#btnSalvarPais").show();
                GetPais();
            }
            else {
                toastr.error(`<p><b>${retorno.mensagem}</b></p>`, ``);
            }
        },

        error: function (retorno) {
            toastr.error(`<p><b>${retorno}</b></p>`, ``);
        }
    });
    
});


$(document).ready(function () {
    $("#btnEditarCidade").hide();
    $("#btnCancelarCidade").hide();
    GetCidade();
});

function Adicionar(data) {
    debugger
    if (data.success) {
        toastr.success(`<p><b>${data.mensagem}</b></p>`, ``);
        GetCidade();
    }
    else {
        toastr.error(`<p><b>${data.mensagem}</b></p>`, ``);
    }
}

function GetCidade() {
    $.ajax({
        method: "GET",
        url: "cidade/listar",
        success: function (retorno) {
            if (retorno.hasOwnProperty("mensagem")) {
                toastr.error(`<p><b>${retorno.mensagem}</b></p>`, ``);
            }
            else {
                $("#gridCidade").html(retorno);
            }
        },

        error: function (retorno) {
            toastr.error(`<p><b>${retorno}</b></p>`, ``);
        }
    });
}

function Excluir(id) {
    if (confirm("Todos os dados relacionados a essa cidade irão ser excluídos. Confirmar exclusão?")) {
        $.ajax({
            method: "DELETE",
            url: `cidade/${id}`,
            success: function (retorno) {
                if (retorno.success) {
                    toastr.success(`<p><b>${retorno.mensagem}</b></p>`, ``);
                    GetCidade();
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


function Editar(id, descricao, idEstado) {
    $("#idCidade").val(id);
    $("#idEstadoHidden").val(idEstado);
    $("#descricaoCidade").val(descricao);
    $("#btnEditarCidade").show();
    $("#btnCancelarCidade").show();
    $("#btnSalvarCidade").hide();
    $("#IdEstado").val(idEstado)
}

$("#btnCancelarCidade").click(function () {
    $("#descricaoCidade").val(null);
    $("#idEstadoHidden").val(null);
    $("#idCidade").val(null);
    $("#btnEditarCidade").hide();
    $("#btnCancelarCidade").hide();
    $("#btnSalvarCidade").show();
    $("#IdEstado").val(null)
});

$("#btnEditarCidade").click(function () {
    let estadoSelecionado = $("#IdEstado option:selected").val();
    let estadoHidden = $("#idEstadoHidden").val();
    let estado = estadoSelecionado != "" && estadoSelecionado != estadoHidden ? estadoSelecionado : estadoHidden;
    let dados = { Descricao: $("#descricaoCidade").val(), Id: $("#idCidade").val(), IdEstado: estado };
    $.ajax({
        method: "PUT",
        url: `cidade`,
        data: dados,
        success: function (retorno) {
            if (retorno.success) {
                toastr.success(`<p><b>${retorno.mensagem}</b></p>`, ``);
                $("#descricaoCidade").val(null);
                $("#idEstadoHidden").val(null);
                $("#idCidade").val(null);
                $("#btnEditarCidade").hide();
                $("#btnCancelarCidade").hide();
                $("#btnSalvarCidade").show();
                GetCidade();
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
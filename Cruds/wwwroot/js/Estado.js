$(document).ready(function () {
    $("#btnEditarEstado").hide();
    $("#btnCancelarEstado").hide();
    GetEstado();
});

function Adicionar(data) {
    debugger
    if (data.success) {
        toastr.success(`<p><b>${data.mensagem}</b></p>`, ``);
        GetEstado();
    }
    else {
        toastr.error(`<p><b>` + data.mensagem + `</b></p>`, ``);
    }
}

function GetEstado() {
    $.ajax({
        method: "GET",
        url: "estado/listar",
        success: function (retorno) {
            if (retorno.hasOwnProperty("mensagem")) {
                alert(retorno.mensagem);
            }
            else {
                $("#gridEstado").html(retorno);
            }
        },

        error: function (retorno) {
            alert(retorno.mensagem);
        }
    });
}

function Excluir(id) {
    if (confirm("Todos os dados relacionados a esse estado irão ser excluídos. Confirmar exclusão?")) {
        $.ajax({
            method: "DELETE",
            url: `estado/${id}`,
            success: function (retorno) {
                if (retorno.success) {
                    toastr.success(`<p><b>${retorno.mensagem}</b></p>`, ``);
                    GetEstado();
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

function Editar(id, descricao, idPais) {
    $("#idEstado").val(id);
    $("#idPaisHidden").val(idPais);
    $("#descricaoEstado").val(descricao);
    $("#btnEditarEstado").show();
    $("#btnCancelarEstado").show();
    $("#btnSalvarEstado").hide();
    $("#IdPais").val(idPais);
}

$("#btnCancelarEstado").click(function () {
    $("#descricaoEstado").val(null);
    $("#idPaisHidden").val(null);
    $("#idEstado").val(null);
    $("#IdPais").val(null);
    $("#btnEditarEstado").hide();
    $("#btnCancelarEstado").hide();
    $("#btnSalvarEstado").show();
});

$("#btnEditarEstado").click(function () {
    let paisSelecionado = $("#IdPais option:selected").val();
    let paisHidden = $("#idPaisHidden").val();
    let pais = paisSelecionado != "" && paisSelecionado != paisHidden ? paisSelecionado : paisHidden;
    let dados = { Descricao: $("#descricaoEstado").val(), Id: $("#idEstado").val(), IdPais: pais };
    $.ajax({
        method: "PUT",
        url: `estado`,
        data: dados,
        success: function (retorno) {
            if (retorno.success) {
                toastr.success(`<p><b>${retorno.mensagem}</b></p>`, ``);
                $("#descricaoEstado").val(null);
                $("#idPaisHidden").val(null);
                $("#idEstado").val(null);
                $("#btnEditarEstado").hide();
                $("#btnCancelarEstado").hide();
                $("#btnSalvarEstado").show();
                GetEstado();
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

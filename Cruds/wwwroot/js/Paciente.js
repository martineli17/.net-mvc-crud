$(document).ready(function () {
    $("#btnEditarPaciente").hide();
    $("#btnCancelarPaciente").hide();
    GetPaciente();
});

$(".cpf").mask("000.000.000-00");

function Adicionar(data) {
    debugger
    if (data.success) {
        toastr.success(`<p><b>${data.mensagem}</b></p>`, ``);
        GetPaciente();
    }
    else {
        toastr.error(`<p><b>${data.mensagem}</b></p>`, ``);
    }
}

function GetPaciente() {
    $.ajax({
        method: "GET",
        url: "paciente/listar",
        success: function (retorno) {
            if (retorno.hasOwnProperty("mensagem")) {
                toastr.error(`<p><b>${retorno.mensagem}</b></p>`, ``);
            }
            else {
                $("#gridPaciente").html(retorno);
            }
        },

        error: function (retorno) {
            toastr.error(`<p><b>${retorno}</b></p>`, ``);
        }
    });
}

function Excluir(id) {
    if (confirm("Confirmar exclusão?")) {
        $.ajax({
            method: "DELETE",
            url: `paciente/${id}`,
            success: function (retorno) {
                if (retorno.success) {
                    toastr.success(`<p><b>${retorno.mensagem}</b></p>`, ``);
                    GetPaciente();
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

function Editar(id, cpf, nome, idPais, idEstado, idCidade) {
    $("#idPaciente").val(id);
    $("#idPaisHidden").val(idPais);
    $("#idEstadoHidden").val(idEstado);
    $("#idCidadeHidden").val(idCidade);
    $("#nomePaciente").val(nome);
    $("#cpfPaciente").val(cpf);
    $("#btnEditarPaciente").show();
    $("#btnCancelarPaciente").show();
    $("#btnSalvarPaciente").hide();
    $("#IdPais").val(idPais);
    $("#IdEstado").val(idEstado);
    $("#IdCidade").val(idCidade);
}

$("#btnCancelarPaciente").click(function () {
    $("#idPaisHidden").val(null);
    $("#idEstadoHidden").val(null);
    $("#idCidadeHidden").val(null);
    $("#nomePaciente").val(null);
    $("#cpfPaciente").val(null);
    $("#idPaciente").val(null);
    $("#IdPais").val(null);
    $("#IdEstado").val(null);
    $("#IdCidade").val(null);
    $("#btnEditarPaciente").hide();
    $("#btnCancelarPaciente").hide();
    $("#btnSalvarPaciente").show();
});

$("#btnEditarPaciente").click(function () {
    let paisSelecionado = $("#IdPais option:selected").val();
    let estadoSelecionado = $("#IdEstado option:selected").val();
    let cidadeSelecionado = $("#IdCidade option:selected").val();
    let paisHidden = $("#idPaisHidden").val();
    let estadoHidden = $("#idEstadoHidden").val();
    let cidadeHidden = $("#idCidadeHidden").val();
    let pais = paisSelecionado != "" && paisSelecionado != paisHidden ? paisSelecionado : paisHidden;
    let cidade = cidadeSelecionado != "" && cidadeSelecionado != cidadeHidden ? cidadeSelecionado : cidadeHidden;
    let estado = estadoSelecionado != "" && estadoSelecionado != estadoHidden ? estadoSelecionado : estadoHidden;


    let dados = { Nome: $("#nomePaciente").val(), Id: $("#idPaciente").val(), Cpf: $("#cpfPaciente").val(), IdCidade: cidade, IdPais: pais, IdEstado: estado };
    $.ajax({
        method: "PUT",
        url: `paciente`,
        data: dados,
        success: function (retorno) {
            if (retorno.success) {
                toastr.success(`<p><b>${retorno.mensagem}</b></p>`, ``);
                $("#idPaisHidden").val(null);
                $("#idEstadoHidden").val(null);
                $("#idCidadeHidden").val(null);
                $("#nomePaciente").val(null);
                $("#cpfPaciente").val(null);
                $("#idPaciente").val(null);
                $("#btnEditarPaciente").hide();
                $("#btnCancelarPaciente").hide();
                $("#btnSalvarPaciente").show();
                GetPaciente();
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


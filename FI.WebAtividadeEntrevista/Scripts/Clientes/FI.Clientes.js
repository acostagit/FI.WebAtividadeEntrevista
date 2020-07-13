$(document).ready(function () {

    $('#formCadastro').submit(function (e) {

        var items = new Object();
        items.beneficiarios = new Array();

        var beneficiarios;

        $('#btn-incluir').on('click', function () {
            beneficiarios = adicionar();

        });
       

        function adicionar() {
            var var_cpf = $("#cpf-beneficiario").val();
            var var_nome = $("#nome-beneficiario").val();

            items.beneficiarios.push(new Object({ cpf: var_cpf, nome: var_nome }));

            $("#resultado").empty();
            $(items.beneficiarios).each(function () {

                $("#resultado").append("CPF = " + this.cpf + " | Nome = " + this.nome + "<br>").hide();

                $('#formCadastro').append('<input type="text" class="form-control" name="cpf[]">');

            });

            $("#cpf-beneficiario").val('');
            $("#nome-beneficiario").val('');

            beneficiarios = items.beneficiarios;

            return JSON.stringify(items.beneficiarios);
        }

        e.preventDefault();
        $.ajax({
            url: urlPost,
            method: "POST",
            data: {
                "NOME": $(this).find("#Nome").val(),
                "CEP": $(this).find("#CEP").val(),
                "Email": $(this).find("#Email").val(),
                "Sobrenome": $(this).find("#Sobrenome").val(),
                "Nacionalidade": $(this).find("#Nacionalidade").val(),
                "Estado": $(this).find("#Estado").val(),
                "Cidade": $(this).find("#Cidade").val(),
                "Logradouro": $(this).find("#Logradouro").val(),
                "Telefone": $(this).find("#Telefone").val(),
                "CPF": $(this).find("#CPF").val(),
                "Beneficiarios": items.beneficiarios
            },
            error:
                function (r) {
                    if (r.status == 400)
                        ModalDialog("Ocorreu um erro", r.responseJSON);
                    else if (r.status == 500)
                        ModalDialog("Ocorreu um erro", "Ocorreu um erro interno no servidor.");
                },
            success:
                function (r) {
                    ModalDialog("Cliente", r);
                    $("#formCadastro")[0].reset();
                }
        });
    });


});

function ModalDialog(titulo, texto) {
    var random = Math.random().toString().replace('.', '');
    var texto = '<div id="' + random + '" class="modal fade">                                                               ' +
        '        <div class="modal-dialog">                                                                                 ' +
        '            <div class="modal-content">                                                                            ' +
        '                <div class="modal-header">                                                                         ' +
        '                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>         ' +
        '                    <h4 class="modal-title">' + titulo + '</h4>                                                    ' +
        '                </div>                                                                                             ' +
        '                <div class="modal-body">                                                                           ' +
        '                    <p>' + texto + '</p>                                                                           ' +
        '                </div>                                                                                             ' +
        '                <div class="modal-footer">                                                                         ' +
        '                    <button type="button" class="btn btn-default" data-dismiss="modal">Fechar</button>             ' +
        '                                                                                                                   ' +
        '                </div>                                                                                             ' +
        '            </div><!-- /.modal-content -->                                                                         ' +
        '  </div><!-- /.modal-dialog -->                                                                                    ' +
        '</div> <!-- /.modal -->                                                                                        ';

    $('body').append(texto);
    $('#' + random).modal('show');
}

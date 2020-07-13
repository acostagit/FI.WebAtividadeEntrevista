
$(document).ready(function () {

    if (obj) {
        $('#formCadastro #Nome').val(obj.Nome);
        $('#formCadastro #CEP').val(obj.CEP);
        $('#formCadastro #Email').val(obj.Email);
        $('#formCadastro #Sobrenome').val(obj.Sobrenome);
        $('#formCadastro #Nacionalidade').val(obj.Nacionalidade);
        $('#formCadastro #Estado').val(obj.Estado);
        $('#formCadastro #Cidade').val(obj.Cidade);
        $('#formCadastro #Logradouro').val(obj.Logradouro);
        $('#formCadastro #Telefone').val(obj.Telefone);
        $('#formCadastro #CPF').val(obj.CPF);

        $('#FormCadastro #Beneficiarios').val(obj.Beneficiarios);

        
        //var lista = document.getElementById('tb-beneficiarios').rows;
        var corpo_tabela = document.querySelector("tbody");

        for (var i = 0; i < obj.Beneficiarios.length; i++) {

            var linha = document.createElement("tr");
            var campo_cpf = document.createElement("td");
            var campo_nome = document.createElement("td");
            var campo_botao1 = document.createElement("td");

            var texto_cpf = document.createTextNode(obj.Beneficiarios[i].CPF);
            var texto_nome = document.createTextNode(obj.Beneficiarios[i].Nome);
            var texto_botao1 = document.createTextNode('<button onclick="window.location.href=\'' + "edit/" + '/' + obj.Beneficiarios[i].Id + '\'" class="btn btn-primary btn-sm">Alterar</button>');

           // '<button onclick="window.location.href=\'' + urlAlteracao + '/' + data.record.Id + '\'" class="btn btn-primary btn-sm">Alterar</button>'

               // '"<button class="btn btn-primary details"' + "data-id=" + obj.Beneficiarios[i]. + "'> <i class="glyphicon glyphicon-file></i></button>");

            //vincular os valores aos elemtos
            campo_cpf.appendChild(texto_cpf);
            campo_nome.appendChild(texto_nome);
            campo_botao1.appendChild(texto_botao1);

            linha.appendChild(campo_cpf);
            linha.appendChild(campo_nome);
            linha.appendChild(campo_botao1);

            corpo_tabela.appendChild(linha);
         
            //tbody.innerhtml += "<tr><td>" + lista[i].cpf + "</td><td>" + lista[i].nome + "</td></tr>";
        }

        //<td>
        //    <button class="btn btn-success details" data-id="@item.ClienteId"><i class="glyphicon glyphicon-file"></i></button>
        //    <button class="btn btn-danger delete" data-id="@item.ClienteId"><i class="glyphicon glyphicon-trash"></i></button>
        //    <button class="btn btn-primary edit" data-id="@item.ClienteId"><i class="glyphicon glyphicon-edit"></i></button>
        //</td>

       // corpo_tabela.appendChild();
    }

    $('#formCadastro').submit(function (e) {
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
                "CPF": $(this).find("#CPF").val()
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
                    ModalDialog("Sucesso!", r)
                    $("#formCadastro")[0].reset();
                    window.location.href = urlRetorno;
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

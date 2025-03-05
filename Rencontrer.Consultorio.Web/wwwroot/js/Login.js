document.addEventListener("DOMContentLoaded", function () {
    const form = document.getElementById("frmPost");
    const button = document.getElementById("btnLogin");

    // Adiciona o evento de envio ao formulário
    form.addEventListener("submit", function (event) {
        event.preventDefault(); // Impede o envio padrão do formulário
        autenticar();
    });

    // Adiciona o evento de clique ao botão
    button.addEventListener("click", function (event) {
        event.preventDefault(); // Impede o envio padrão do botão
        autenticar();
    });
});

function autenticar() {
    console.log("Iniciando autenticação...");

    var button = document.getElementById("btnLogin");
    button.innerHTML = 'Acessando...';
    button.classList.add('neon-pulse');

    // Obtendo os dados diretamente do formulário
    var formData = new FormData(document.getElementById("frmPost"));
    var username = formData.get("username"); // Use o ID correto do input
    var password = formData.get("password");

    console.log(username, password);

    // Verificação dos campos
    if (!username || !password) {
        alert("Por favor, preencha todos os campos!");
        button.innerHTML = 'Entrar';
        button.classList.remove('neon-pulse');
        return;
    }

    // Criando o objeto de dados
    var dadosLogin = {
        Email: username,
        Senha: password
    };

    // Enviando os dados via POST
    $.ajax({
        type: "POST",
        url: "Login/Autenticar", // Rota para o método no controller
        contentType: "application/json",
        data: JSON.stringify(dadosLogin),
        beforeSend: function () {
            console.log("Enviando dados...");
        },
        success: function (data) {
            console.log("Resposta recebida:", data);
            if (data.status === "success") {
                window.location.href = '/CustosExtra/Aprovacoes';
            } else {
                alert("Erro ao autenticar: " + data.message);
            }
        },
        error: function (xhr) {
            console.error("Erro ao enviar a requisição", xhr);
        },
        complete: function () {
            button.innerHTML = 'Entrar';
            button.classList.remove('neon-pulse');
        }
    });
}







document.addEventListener('DOMContentLoaded', function () {
    var eyesClosed = document.querySelector('.eyesClosed');
    var eyesOpen = document.querySelector('.eyesOpen');
    var input_senha = document.querySelector('.input_senha');

    window.alterarInput = function (value) {
        if (value == 'closed') {
            input_senha.type = 'text';
            eyesOpen.classList.remove('ocultar');
            eyesClosed.classList.add('ocultar');
        } else {
            input_senha.type = 'password';
            eyesOpen.classList.add('ocultar');
            eyesClosed.classList.remove('ocultar');
        }
    };
});




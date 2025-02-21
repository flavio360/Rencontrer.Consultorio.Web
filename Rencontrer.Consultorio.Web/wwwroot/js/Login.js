function autenticar() {
    console.log("passei");
    var button = document.querySelector('.btn_login_entrar');
    button.innerHTML = 'Acessando';
    button.classList.add('neon-pulse');
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

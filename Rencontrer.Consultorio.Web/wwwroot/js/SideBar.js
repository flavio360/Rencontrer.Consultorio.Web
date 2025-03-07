function abrirSidebar(valor) {
    if (valor == 'atendimento') {
        document.querySelector('.atendimento').classList.remove('ocultar');
        document.querySelector('.reports').classList.add('ocultar');
        document.getElementById('reportsSpan').classList.remove('active');
    }
    if (valor == 'reports') {
        document.querySelector('.reports').classList.remove('ocultar');
        document.querySelector('.atendimento').classList.add('ocultar');
        document.getElementById('atendimentoSpan').classList.remove('active');
    }
    if (valor == 'home') {
        document.querySelector('.reports').classList.add('ocultar');
        document.getElementById('reportsSpan').classList.remove('active');
        document.querySelector('.atendimento').classList.add('ocultar');
        document.getElementById('atendimentoSpan').classList.remove('active');
    }

    // Adiciona a classe 'active' ao botão
    var spanElement = document.getElementById(valor + 'Span');
    if (spanElement) {
        spanElement.classList.toggle('active');
    }
}

// Função para fechar o sidebar
function fecharSidebar(valor) {
    if (valor == 'atendimento') {
        document.querySelector('.atendimento').classList.add('ocultar');
        document.querySelector('.reports').classList.add('ocultar');
    }
    if (valor == 'reports') {
        document.querySelector('.reports').classList.add('ocultar');
        document.querySelector('.atendimento').classList.add('ocultar');
    }
    if (valor == 'home') {
        document.querySelector('.atendimento').classList.add('ocultar');
        document.querySelector('.reports').classList.add('ocultar');
    }
}

// Função para lidar com cliques fora do sidebar
function fecharSidebarForaDoMenu(event) {
    const sidebar = document.querySelector('.sidebar');
    const isClickInsideSidebar = sidebar.contains(event.target);

    if (!isClickInsideSidebar) {
        // Fecha o sidebar
        document.querySelector('.atendimento').classList.add('ocultar');
        document.querySelector('.reports').classList.add('ocultar');

        // Remove a classe 'active' dos botões, se necessário
        document.getElementById('atendimentoSpan').classList.remove('active');
        document.getElementById('reportsSpan').classList.remove('active');
    }
}

// Adiciona um ouvinte de eventos para detectar cliques fora do sidebar
document.body.addEventListener('click', fecharSidebarForaDoMenu);
let currentPage = 1; // Use 'let' para permitir reatribuição

// Função para ir para a próxima página
function nextPage() {
    if (currentPage < 4) { // Ajustado para permitir até 4 páginas
        currentPage++;
        showPage(currentPage);
    }
}

// Função para voltar para a página anterior
function prevPage() {
    if (currentPage > 1) {
        currentPage--;
        showPage(currentPage);
    }
}

// Função para mostrar a página correspondente
function showPage(pageNumber) {
    const pages = document.querySelectorAll('.page'); // Seleciona todas as páginas

    pages.forEach(page => {
        page.style.display = 'none'; // Oculta todas as páginas
    });

    document.getElementById(`page${pageNumber}`).style.display = 'block'; // Exibe a página atual
}

// Inicializa a visualização correta das páginas na primeira carga
window.onload = function () {
    showPage(currentPage); // Exibe a primeira página
};

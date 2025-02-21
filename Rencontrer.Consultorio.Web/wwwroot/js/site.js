let currentPage = 1; // Use 'let' para permitir reatribuição

function nextPage() {
    if (currentPage < 3) {
        currentPage++;
        showPage(currentPage);
    }
}

function prevPage() {
    if (currentPage > 1) {
        currentPage--;
        showPage(currentPage);
    }
}

function showPage(pageNumber) {
    const pages = document.querySelectorAll('.page');

    pages.forEach(page => {
        page.style.display = 'none';
    });

    document.getElementById(`page${pageNumber}`).style.display = 'block';
}


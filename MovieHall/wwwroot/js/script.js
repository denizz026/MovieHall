


function createMovieCard(movie) {
    return `
        <div class="movie-card">
            <img src="${movie.image}" alt="${movie.title}">
            <div class="movie-info">
                <div class="movie-title">${movie.title}</div>
                <div class="movie-rating">IMDb: ${movie.imdb}</div>
            </div>
        </div>
    `;
}

function renderMovies(movies, containerId) {
    const container = document.getElementById(containerId);
    container.innerHTML = movies.map(createMovieCard).join('');
}

document.addEventListener('DOMContentLoaded', () => {
    renderMovies(vizyondakiler, 'vizyondakilerGrid');
    renderMovies(vizyonaGirecekler, 'vizyonaGireceklerGrid');
});


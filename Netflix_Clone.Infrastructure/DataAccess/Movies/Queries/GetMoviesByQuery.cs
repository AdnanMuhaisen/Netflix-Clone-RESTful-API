﻿using MediatR;
using Netflix_Clone.Shared.DTOs;

namespace Netflix_Clone.Infrastructure.DataAccess.Movies.Queries
{
    public class GetMoviesByQuery(
        int? GenreId = default,
        int? ReleaseYear = default,
        int? MinimumAgeToWatch = default,
        int? LanguageId = default,
        int? DirectorId = default) : IRequest<ApiResponseDto<IEnumerable<MovieDto>>>
    {
        public readonly int? genreId = GenreId;
        public readonly int? releaseYear = ReleaseYear;
        public readonly int? minimumAgeToWatch = MinimumAgeToWatch;
        public readonly int? languageId = LanguageId;
        public readonly int? directorId = DirectorId;
    }
}

﻿namespace Netflix_Clone.Shared.DTOs
{
    public record TVShowEpisodeDto
    {
        public int Id { get; init; }
        public int LengthInMinutes { get; init; }
        public int SeasonNumber { get; init; }
        public int EpisodeNumber { get; init; }
        public int TVShowId { get; set; }
        public string FileName { get; set; } = string.Empty;
        public int SeasonId { get; set; }
    }
}

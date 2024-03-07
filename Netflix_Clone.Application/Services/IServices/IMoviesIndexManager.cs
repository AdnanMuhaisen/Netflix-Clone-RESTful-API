﻿using Netflix_Clone.Domain.Documents;

namespace Netflix_Clone.Application.Services.IServices
{
    public interface IMoviesIndexManager : IElasticsearchIndexManager<MovieDocument>
    {
    }
}

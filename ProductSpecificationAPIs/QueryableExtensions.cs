namespace ProductCodeOldAPIs
{
    public static class QueryableExtensions
    {
        public static IQueryable<T> Get<T>(this IQueryable<T> queryable, out int totalRecords, int? skip = null, int? take = null)
        {
            if (queryable == null)
                throw new ArgumentNullException(nameof(queryable));

            totalRecords = queryable.Count();
            take = (take == 0 ? null : take);
            if (take != null)
                queryable = queryable.Skip((skip.Value - 1) * take.Value).Take(take.Value);

            return queryable;
        }
    }
}

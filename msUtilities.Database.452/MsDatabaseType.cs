namespace msUtilities.Database
{
    /// <summary>
    /// currently supported database types (for connection string generation)
    /// </summary>
    public enum MsDatabaseType
    {
        None = 0,
        Firebird = 1,
        SqlServer = 2,
        Other = 99
    };
}
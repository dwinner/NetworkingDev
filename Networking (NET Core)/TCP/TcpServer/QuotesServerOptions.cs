internal record QuotesServerOptions
{
   public string? QuotesFile { get; init; }

   public int Port { get; init; }
}
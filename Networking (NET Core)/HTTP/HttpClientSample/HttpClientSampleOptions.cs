namespace HttpClientSample
{
   public record HttpClientSampleOptions
   {
      public string? Url { get; init; }

      public string? InvalidUrl { get; init; }
   }
}
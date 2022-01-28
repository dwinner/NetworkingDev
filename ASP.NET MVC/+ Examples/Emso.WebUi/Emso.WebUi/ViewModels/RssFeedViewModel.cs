using System;
using System.ComponentModel.DataAnnotations;
using Emso.WebUi.ViewModels.Metadata;

namespace Emso.WebUi.ViewModels
{
   /// <summary>
   ///    Rss feed view model class
   /// </summary>
   [MetadataType(typeof (RssFeedMetadata))]
   public sealed class RssFeedViewModel : IEquatable<RssFeedViewModel>
   {
      public RssFeedViewModel()
      {
      }

      public RssFeedViewModel(int feedId, string title, string details, string relatedLink, DateTime newsDate,
         bool hasImageData, string imageMimeType)
      {
         FeedId = feedId;
         Title = title;
         Details = details;
         RelatedLink = relatedLink;
         NewsDate = newsDate;
         HasImageData = hasImageData;
         ImageMimeType = imageMimeType;
      }

      /// <summary>
      ///    Feed Id
      /// </summary>
      public int FeedId { get; set; }

      /// <summary>
      ///    News title
      /// </summary>
      public string Title { get; set; }

      /// <summary>
      ///    News details
      /// </summary>
      public string Details { get; set; }

      /// <summary>
      ///    Feed link
      /// </summary>
      public string RelatedLink { get; set; }

      /// <summary>
      ///    News date
      /// </summary>
      public DateTime NewsDate { get; set; }

      /// <summary>
      ///    Has image data
      /// </summary>
      public bool HasImageData { get; set; }

      /// <summary>
      ///    Image mime type
      /// </summary>
      public string ImageMimeType { get; set; }

      public bool Equals(RssFeedViewModel other)
      {
         return !ReferenceEquals(null, other) &&
                (ReferenceEquals(this, other) ||
                 FeedId == other.FeedId && string.Equals(Title, other.Title) &&
                 string.Equals(RelatedLink, other.RelatedLink) && NewsDate.Equals(other.NewsDate));
      }

      public override bool Equals(object obj)
      {
         return !ReferenceEquals(null, obj) &&
                (ReferenceEquals(this, obj) || obj is RssFeedViewModel && Equals((RssFeedViewModel) obj));
      }

      public override int GetHashCode()
      {
         unchecked
         {
            var hashCode = FeedId;
            if (Title != null)
               hashCode = (hashCode*397) ^ Title.GetHashCode();

            if (RelatedLink != null)
               hashCode = (hashCode*397) ^ RelatedLink.GetHashCode();

            hashCode = (hashCode*397) ^ NewsDate.GetHashCode();

            return hashCode;
         }
      }

      public static bool operator ==(RssFeedViewModel left, RssFeedViewModel right)
      {
         return Equals(left, right);
      }

      public static bool operator !=(RssFeedViewModel left, RssFeedViewModel right)
      {
         return !Equals(left, right);
      }
   }
}
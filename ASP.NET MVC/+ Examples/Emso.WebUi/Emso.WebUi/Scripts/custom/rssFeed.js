function getNewsFeed (page) {
    var loadingEl = "#newsLoading";
    var rssEl = "#rssRow";
    var truncationLen = 150;

    $ (loadingEl).show();    
    $ (rssEl).hide();

    $.ajax ({
        url: "/newsfeed/all/" + page,
        type: "GET",
        dataType: "json",
        success: function (feedData) { // hasImageData, imageMimeType                                
            var rssTargetEl = $ (rssEl);
            rssTargetEl.empty();
            var rssViewModel = { rssNews: [] };
            feedData.forEach (function (feedItem) {                
                feedItem.truncatedDetails = jQuery.trim (feedItem.details).substring (0, truncationLen);
                feedItem.restDetails = feedItem.details.substring (truncationLen);
                rssViewModel.rssNews.push(feedItem);
                animatedcollapse.addDiv ("detailsContent" + feedItem.feedId, "fade=1");
            });

            $("#rssTmpl").template(rssViewModel).appendTo(rssTargetEl);            
            animatedcollapse.init();

            $ (rssEl).show();
            $ (loadingEl).hide();
        },
        error: function (e) {
            console.log (e.message);
        }
    });
}

(function () {
    $ ("#newsLoading").hide();
    $.ajax ({
        url: "/newsfeed/navConfig",
        type: "GET",
        dataType: "json",
        success: function (navData) {
            var totalItemsCount = navData.totalItemsCount;
            var itemsPerPageCount = navData.itemsPerPageCount;
            $ ("#feedPagination").pagination (totalItemsCount, {
                num_edge_entries: 2,
                num_display_entries: 8,
                items_per_page: itemsPerPageCount,
                load_first_page: true,
                callback: function (pageIndex) {
                    getNewsFeed (pageIndex + 1);
                }
            });
        }
    });
}) (jQuery);
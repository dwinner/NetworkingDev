(function ($) {
    /**
     * @class Class for calculating pagination values
     */
    $.PaginationCalculator = function (maxentries, opts) {
        this.maxentries = maxentries;
        this.opts = opts;
    };

    $.extend ($.PaginationCalculator.prototype, {
        /**
         * Calculate the maximum number of pages
         * @method
         * @returns {Number}
         */
        numPages: function () {
            return Math.ceil (this.maxentries / this.opts.items_per_page);
        },
        /**
         * Calculate start and end point of pagination links depending on 
         * current_page and num_display_entries.
         * @returns {Array}
         */
        getInterval: function (currentPage) {
            var neHalf = Math.floor (this.opts.num_display_entries / 2);
            var np = this.numPages();
            var upperLimit = np - this.opts.num_display_entries;
            var start = currentPage > neHalf ? Math.max (Math.min (currentPage - neHalf, upperLimit), 0) : 0;
            var end = currentPage > neHalf
                ? Math.min (currentPage + neHalf + (this.opts.num_display_entries % 2), np)
                : Math.min (this.opts.num_display_entries, np);
            return {
                start: start,
                end: end
            };
        }
    });

    // Initialize jQuery object container for pagination renderers
    $.PaginationRenderers = {};

    /**
     * @class Default renderer for rendering pagination links
     */
    $.PaginationRenderers.defaultRenderer = function (maxentries, opts) {
        this.maxentries = maxentries;
        this.opts = opts;
        this.pc = new $.PaginationCalculator (maxentries, opts);
    };
    $.extend ($.PaginationRenderers.defaultRenderer.prototype, {
        /**
         * Helper function for generating a single link (or a span tag if it's the current page)
         * @param {Number} pageId The page id for the new item
         * @param {Number} currentPage 
         * @param {Object} appendopts Options for the new item: text and classes
         * @returns {jQuery} jQuery object containing the link
         */
        createLink: function (pageId, currentPage, appendopts) {
            var np = this.pc.numPages();
            pageId = pageId < 0 ? 0 : (pageId < np ? pageId : np - 1); // Normalize page id to sane value
            appendopts = $.extend ({ text: pageId + 1, classes: "" }, appendopts || {});
            var lnk = pageId === currentPage
                ? $ ("<span class='current'>" + appendopts.text + "</span>")
                : $ ("<a>" + appendopts.text + "</a>").attr ("href", this.opts.link_to.replace (/__id__/, pageId));
            if (appendopts.classes) {
                lnk.addClass (appendopts.classes);
            }
            if (appendopts.rel) {
                lnk.attr ("rel", appendopts.rel);
            }
            lnk.data ("page_id", pageId);
            return lnk;
        },
        // Generate a range of numeric links 
        appendRange: function (container, currentPage, start, end, opts) {
            var i;
            for (i = start; i < end; i++) {
                this.createLink (i, currentPage, opts).appendTo (container);
            }
        },
        getLinks: function (currentPage, eventHandler) {
            var begin,
                end,
                interval = this.pc.getInterval (currentPage),
                np = this.pc.numPages(),
                fragment = $ ("<div class='pagination'></div>");

            // Generate "Previous"-Link
            if (this.opts.prev_text && (currentPage > 0 || this.opts.prev_show_always)) {
                fragment.append (this.createLink (currentPage - 1, currentPage, { text: this.opts.prev_text, classes: "prev", rel: "prev" }));
            }
            // Generate starting points
            if (interval.start > 0 && this.opts.num_edge_entries > 0) {
                end = Math.min (this.opts.num_edge_entries, interval.start);
                this.appendRange (fragment, currentPage, 0, end, { classes: "sp" });
                if (this.opts.num_edge_entries < interval.start && this.opts.ellipse_text) {
                    $ ("<span>" + this.opts.ellipse_text + "</span>").appendTo (fragment);
                }
            }
            // Generate interval links
            this.appendRange (fragment, currentPage, interval.start, interval.end);
            // Generate ending points
            if (interval.end < np && this.opts.num_edge_entries > 0) {
                if (np - this.opts.num_edge_entries > interval.end && this.opts.ellipse_text) {
                    $ ("<span>" + this.opts.ellipse_text + "</span>").appendTo (fragment);
                }
                begin = Math.max (np - this.opts.num_edge_entries, interval.end);
                this.appendRange (fragment, currentPage, begin, np, { classes: "ep" });

            }
            // Generate "Next"-Link
            if (this.opts.next_text && (currentPage < np - 1 || this.opts.next_show_always)) {
                fragment.append (this.createLink (currentPage + 1, currentPage, { text: this.opts.next_text, classes: "next", rel: "next" }));
            }
            $ ("a", fragment).click (eventHandler);
            return fragment;
        }
    });

    // Extend jQuery
    $.fn.pagination = function (maxentries, opts) {

        // Initialize options with default values
        opts = $.extend ({
            items_per_page: 10,
            num_display_entries: 11,
            current_page: 0,
            num_edge_entries: 0,
            link_to: "#",
            prev_text: "&laquo;",
            next_text: "&raquo;",
            ellipse_text: "...",
            prev_show_always: true,
            next_show_always: true,
            renderer: "defaultRenderer",
            show_if_single_page: false,
            load_first_page: true,
            callback: function () { return false; }
        }, opts || {});

        var containers = this, renderer, links, current_page;

        /**
         * This is the event handling function for the pagination links. 
         * @param {int} page_id The new page number
         */
        function paginationClickHandler (evt) {
            evt.preventDefault();
            //var links,
            var newCurrentPage = $ (evt.target).data ("page_id");
            var continuePropagation = selectPage (newCurrentPage);
            if (!continuePropagation) {
                evt.stopPropagation();
            }
            return continuePropagation;
        }

        /**
         * This is a utility function for the internal event handlers. 
         * It sets the new current page on the pagination container objects, 
         * generates a new HTMl fragment for the pagination links and calls
         * the callback function.
         */
        function selectPage (newCurrentPage) {
            // update the link display of a all containers
            containers.data ("current_page", newCurrentPage);
            links = renderer.getLinks (newCurrentPage, paginationClickHandler);
            containers.empty();
            links.appendTo (containers);
            // call the callback and propagate the event if it does not return false
            var continuePropagation = opts.callback (newCurrentPage, containers);
            return continuePropagation;
        }

        // -----------------------------------
        // Initialize containers
        // -----------------------------------
        current_page = parseInt (opts.current_page, 10);
        containers.data ("current_page", current_page);
        // Create a sane value for maxentries and items_per_page
        maxentries = (!maxentries || maxentries < 0) ? 1 : maxentries;
        opts.items_per_page = (!opts.items_per_page || opts.items_per_page < 0) ? 1 : opts.items_per_page;

        if (!$.PaginationRenderers[opts.renderer]) {
            throw new ReferenceError ("Pagination renderer '" + opts.renderer + "' was not found in jQuery.PaginationRenderers object.");
        }
        renderer = new $.PaginationRenderers[opts.renderer] (maxentries, opts);

        // Attach control events to the DOM elements
        var pc = new $.PaginationCalculator (maxentries, opts);
        var np = pc.numPages();
        containers.off ("setPage").on ("setPage", { numPages: np }, function (evt, pageId) {
            if (pageId >= 0 && pageId < evt.data.numPages) {
                selectPage (pageId);
                return false;
            }
            return true;
        });
        containers.off ("prevPage").on ("prevPage", function ( /*evt*/) {
            var currentPage = $ (this).data ("current_page");
            if (currentPage > 0) {
                selectPage (currentPage - 1);
            }
            return false;
        });
        containers.off ("nextPage").on ("nextPage", { numPages: np }, function (evt) {
            var currentPage = $ (this).data ("current_page");
            if (currentPage < evt.data.numPages - 1) {
                selectPage (currentPage + 1);
            }
            return false;
        });
        containers.off ("currentPage").on ("currentPage", function () {
            var currentPage = $ (this).data ("current_page");
            selectPage (currentPage);
            return false;
        });

        // When all initialisation is done, draw the links
        links = renderer.getLinks (current_page, paginationClickHandler);
        containers.empty();
        if (np > 1 || opts.show_if_single_page) {
            links.appendTo (containers);
        }
        // call callback function
        if (opts.load_first_page) {
            opts.callback (current_page, containers);
        }
    }; // End of $.fn.pagination block

}) (jQuery);
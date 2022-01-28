var sideviewmenu = (function (win, $) {
   var defaults = {
      main_transition_duration: 0.3,
      menu_transition: {
         duration: 0.4,
         delay: 0.4
      },
      list_transition: {
         listclass: "menulinks",
         duration: 0.5,
         basedelay: 0.4,
         delay: 0.3
      },
      menusource: "menucontents.html",
      menuid: "sideviewmenu",
      onopenclose: function ( /*state*/) { }
   };

   var transform = typeof $(document.documentElement).css("perspective") != "undefined";
   var menuloaded = false;

   function getajaxcontent(url, options) {
      $.ajax({
         url: url,
         dataType: "html",
         error: function (ajaxRequest) {
            console.log("Error fetching content.<br />Server Response: " + ajaxRequest.responseText);            
         },
         success: function (content) {
            menuloaded = true;
            options.menuref = $(content);
            sideviewmenu(options);
         }
      });
   }

   function sideviewmenu(options) {
      var menusource = options.menusource || defaults.menusource;
      if (!menuloaded && menusource !== "inline") {
         getajaxcontent(menusource, options);
         return;
      }

      var s = $.extend({}, defaults, options), $bod = $(document.body), $content = $("#contentwrapper");
      var $menu = s.menuref || $("#" + s.menuid);
      if ($content.length === 0) {
         $bod.wrapInner('<div id="contentwrapper" />');
         $content = $("#contentwrapper");
      }

      $bod.prepend($menu);
      var $menubackdrop = $('<div class="backdrop" />').prependTo($menu);

      function togglescrollbars(state) {
         if (state === "open") {
            $menu.css({ overflow: "auto" });
            $menubackdrop.css({ height: $menu.get(0).scrollHeight });
            s.onopenclose("opened");
         } else {
            $content.css({ height: "", overflow: "" });
            $bod.css("overflow", "auto");
            $menu.css({ overflow: "" });
            s.onopenclose("closed");
         }
      }

      if (transform) {
         $content.css({ 'transitionDuration': s.main_transition_duration + "s" });
         $menu.css({ transitionDuration: s.menu_transition.duration + "s", transitionDelay: s.menu_transition.delay + "s" });
         $menu.find("." + s.list_transition.listclass + " li").each(function (i) {
            $(this).css({
               transitionDuration: s.list_transition.duration + "s",
               transitionDelay: s.list_transition.basedelay + s.list_transition.delay * i + "s"
            });
         });
         $bod.on("transitionend webkitTransitionEnd", function (e) {
            if (e.originalEvent && /transform/i.test(e.originalEvent.propertyName) && e.target.getAttribute("id") === s.menuid) {
               togglescrollbars(!$bod.hasClass("opensideviewmenu") ? "close" : "open");
            }
         });
      } else {
         $menu.css({ left: "-100%", visibility: "visible" });
      }

      sideviewmenu.toggle = function (state) {
         $bod.css("overflow", "hidden");
         $content.css({
            height: window.innerHeight,
            overflow: "hidden"
         });
         var actionfunc = (state === "open") ? "addClass" : (state === "close") ? "removeClass" : "toggleClass";
         setTimeout(function () {
            $bod[actionfunc]("opensideviewmenu");
         }, transform ? 25 : 0);
         if (!transform) {
            var leftval = (state === "open") ? 0 : (state === "close") ? "-100%" : ($bod.hasClass("opensideviewmenu")) ? "-100%" : 0;
            $menu.animate({ left: leftval }, s.menu_transition.duration + "ms", function () {
               togglescrollbars(leftval === 0 ? "open" : "close");
            });
         }
      };
      $menu.add($content).on("click", function () {
         if ($bod.hasClass("opensideviewmenu")) {
            sideviewmenu.toggle("close");
         }
      });
   }   

   return sideviewmenu;
})(window, jQuery);
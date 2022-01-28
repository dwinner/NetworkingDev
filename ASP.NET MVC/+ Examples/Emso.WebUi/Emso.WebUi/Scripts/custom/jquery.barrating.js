!function (t) { "function" == typeof define && define.amd ? define(["jquery"], t) : "object" == typeof module && module.exports ? module.exports = t(require("jquery")) : t(jQuery) }(function (t) {
   var e = function () {
      function e() {
         var e = this,
            n = function () {
               var n = ["br-wrapper"];
               "" !== e.options.theme && n.push("br-theme-" + e.options.theme), e.$elem.wrap(t("<div />", { "class": n.join(" ") }))
            },
            i = function () { e.$elem.unwrap() },
            a = function (n) { return t.isNumeric(n) && (n = Math.floor(n)), t('option[value="' + n + '"]', e.$elem) },
            r = function () {
               var n = e.options.initialRating;
               return n ? a(n) : t("option:selected", e.$elem)
            },
            o = function (t) {
               var n = e.$elem.data("barrating");
               return "undefined" != typeof t ? n[t] : n
            },
            l = function (t, n) { null !== n && "object" == typeof n ? e.$elem.data("barrating", n) : e.$elem.data("barrating")[t] = n },
            s = function () {
               var t = r(), n = t.val(), i = t.data("html") ? t.data("html") : t.text();
               l(null, { userOptions: e.options, ratingValue: n, ratingText: i, originalRatingValue: n, originalRatingText: i, readOnly: e.options.readonly, ratingMade: !1 })
            },
            u = function () { e.$elem.removeData("barrating") },
            d = function () { return o("ratingText") },
            c = function () { return o("ratingValue") },
            f = function () {
               var n = t("<div />", { "class": "br-widget" });
               return e.$elem.find("option").each(function () {
                  var i, a, r, o;
                  i = t(this).val(), i && (a = t(this).text(), r = t(this).data("html"), r && (a = r), o = t("<a />", { href: "#", "data-rating-value": i, "data-rating-text": a, html: e.options.showValues ? a : "" }), n.append(o))
               }), e.options.showSelectedRating && n.append(t("<div />", { text: "", "class": "br-current-rating" })), e.options.reverse && n.addClass("br-reverse"), e.options.readonly && n.addClass("br-readonly"), n
            },
            g = function () { return o("userOptions").reverse ? "nextAll" : "prevAll" },
            p = function (t) { a(t).prop("selected", !0), e.$elem.change() },
            h = function () { t("option", e.$elem).prop("selected", function () { return this.defaultSelected }), e.$elem.change() },
            v = function (t) { t = t ? t : d(), e.options.showSelectedRating && e.$elem.parent().find(".br-current-rating").text(t) },
            m = function (t) { return Math.round(Math.floor(10 * t) / 10 % 1 * 100) },
            b = function () { e.$widget.find("a").removeClass() },
            $ = function () {
               var n, i, a = e.$widget.find('a[data-rating-value="' + c() + '"]'), r = o("userOptions").initialRating, l = t.isNumeric(c()) ? c() : 0, s = m(r);
               if (b(), a.addClass("br-selected br-current")[g()]().addClass("br-selected"), !o("ratingMade") && t.isNumeric(r)) {
                  if (l >= r || !s) return;
                  n = e.$widget.find("a"), i = a.length ? a[o("userOptions").reverse ? "prev" : "next"]() : n[o("userOptions").reverse ? "last" : "first"](), i.addClass("br-fractional"), i.addClass("br-fractional-" + s)
               }
            },
            w = function (t) { return e.options.deselectable ? e.$elem.find("option:first").val() ? !1 : c() == t.attr("data-rating-value") : !1 },
            y = function (n) {
               n.on("click.barrating", function (n) {
                  var i, a, r = t(this), s = o("userOptions");
                  return n.preventDefault(), i = r.attr("data-rating-value"), a = r.attr("data-rating-text"), w(r) && (i = "", a = ""), l("ratingValue", i), l("ratingText", a), l("ratingMade", !0), p(i), v(a), $(), s.onSelect.call(e, c(), d(), n), !1
               })
            },
            x = function (e) {
               e.on("mouseenter.barrating", function () {
                  var e = t(this);
                  b(), e.addClass("br-active")[g()]().addClass("br-active"), v(e.attr("data-rating-text"))
               })
            },
            C = function (t) { e.$widget.on("mouseleave.barrating blur.barrating", function () { v(), $() }) },
            O = function (e) { e.on("touchstart.barrating", function (e) { e.preventDefault(), e.stopPropagation(), t(this).click() }) },
            R = function (t) { t.on("click.barrating", function (t) { t.preventDefault() }) },
            S = function (t) { y(t), e.options.hoverState && (x(t), C(t)) },
            M = function (t) { t.off(".barrating") },
            V = function (t) { $elements = e.$widget.find("a"), O && O($elements), t ? (M($elements), R($elements)) : S($elements) };
         this.show = function () { o() || (n(), s(), e.$widget = f(), e.$widget.insertAfter(e.$elem), $(), v(), V(e.options.readonly), e.$elem.hide()) }, this.readonly = function (t) { "boolean" == typeof t && o("readOnly") != t && (V(t), l("readOnly", t), e.$widget.toggleClass("br-readonly")) }, this.set = function (t) {
            var n = o("userOptions");
            e.$elem.find('option[value="' + t + '"]').val() && (l("ratingValue", t), l("ratingText", e.$elem.find('option[value="' + t + '"]').text()), l("ratingMade", !0), p(c()), v(d()), $(), n.silent || n.onSelect.call(this, c(), d()))
         }, this.clear = function () {
            var t = o("userOptions");
            l("ratingValue", o("originalRatingValue")), l("ratingText", o("originalRatingText")), l("ratingMade", !1), h(), v(d()), $(), t.onClear.call(this, c(), d())
         }, this.destroy = function () {
            var t = c(), n = d(), a = o("userOptions");
            M(e.$widget.find("a")), e.$widget.remove(), u(), i(), e.$elem.show(), a.onDestroy.call(this, t, n)
         }
      }

      return e.prototype.init = function (e, n) { return this.$elem = t(n), this.options = t.extend({}, t.fn.barrating.defaults, e), this.options }, e
   }();
   t.fn.barrating = function (n, i) {
      return this.each(function () {
         var a = new e;
         if (t(this).is("select") || t.error("Sorry, this plugin only works with select fields."), a.hasOwnProperty(n)) {
            if (a.init(i, this), "show" === n) return a.show(i);
            if (a.$elem.data("barrating")) return a.$widget = t(this).next(".br-widget"), a[n](i)
         } else {
            if ("object" == typeof n || !n) return i = n, a.init(i, this), a.show();
            t.error("Method " + n + " does not exist on jQuery.barrating")
         }
      })
   }, t.fn.barrating.defaults = { theme: "", initialRating: null, showValues: !1, showSelectedRating: !0, deselectable: !0, reverse: !1, readonly: !1, fastClicks: !0, hoverState: !0, silent: !1, onSelect: function (t, e, n) { }, onClear: function (t, e) { }, onDestroy: function (t, e) { } }, t.fn.barrating.BarRating = e
});
//# sourceMappingURL=jquery.barrating.min.js.map
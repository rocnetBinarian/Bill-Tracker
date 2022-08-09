// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
(function ($) {
    $.fn.invisible = function () {
        return this.each(function () {
            $(this).css("visibility", "hidden");
        });
    };
    $.fn.visible = function () {
        return this.each(function () {
            $(this).css("visibility", "visible");
        });
    };
}(jQuery));
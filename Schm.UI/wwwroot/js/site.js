// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
'use strict';

(function ($) {

    /*------------- seperated Number -------------*/
    $("input[data-type='seperatedNumber']").on({
        keyup: function (regex) {
            seprateNumber($(this));
        },
        blur: function (regex) {
            seprateNumber($(this), "blur");
        }
    });

    function formatNumber(n) {
        // format number 1000000 to 1,234,567
        return n.replace('.', '').replace(/\D/g, "").replace(/\B(?=(\d{3})+(?!\d))/g, ",")
    }

    function seprateNumber(input, blur) {
        // prevent to insert decimal side
        // and puts cursor back in right position.

        // get input value
        let input_val = input.val();

        // don't validate empty input
        if (input_val === "" || input_val === null || input_val === undefined) { return; }

        // original length
        let original_len = input_val.length;

        // initial caret position
        let caret_pos = input.prop("selectionStart");

        input_val = formatNumber(input_val);

        // send updated string to input
        input.val(input_val);

        //put caret back in the right position
        let updated_len = input_val.length;
        caret_pos = updated_len - original_len + caret_pos;
        input[0].setSelectionRange(caret_pos, caret_pos);
    }
    /*------------- seperated Number -------------*/

})(jQuery);

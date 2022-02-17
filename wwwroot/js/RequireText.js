$(document).ready(function() {

    $('input[type="checkbox"]').change(function() {

        if ($('input[type="text"]').attr('required')) {
            $('input[type="text"]').removeAttr('required');
        } 

        else {
            $('input[type="text"]').attr('required','required');
        }

    });

});
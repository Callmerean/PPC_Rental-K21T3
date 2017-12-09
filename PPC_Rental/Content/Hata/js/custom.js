
jQuery(document).ready(function($) {

    "use strict";

    // Home Slider

    $('#slider').flexslider({
        animation: "slide"
    });

    // Select Box Replacements

    $('select').selectBox({
        mobile: true,
        menuSpeed: 'fast'
    });
	
	// Properties Slider
	
	$('#property-slider').flexslider({
        animation: "slide",
        controlNav: false,
        directionNav: false,
        animationLoop: false,
        slideshow: false,
        sync: "#property-carousel"
    });
    $('#property-carousel').flexslider({
        animation: "slide",
        controlNav: false,
        animationLoop: false,
        slideshow: false,
        itemWidth: 200,
        itemMargin: 24,
        minItems: 1,
        move: 1,
        asNavFor: '#property-slider'
    });

    // Accordions

    $( ".accordion" ).accordion({
        heightStyle: "content",
        collapsible: true
    });

    // Area Range

    $( "#area-range" ).slider({
        range: true,
        min: 0,
        max: 1000,
        values: [ 500, 800 ],
        slide: function( event, ui ) {
            $( "#area" ).val( ui.values[ 0 ] + " - " + ui.values[ 1 ] );
        }
    });
    $( "#area" ).val( $( "#area-range" ).slider( "values", 0 ) + " - " + $( "#area-range" ).slider( "values", 1 ) );

    // Price Range

    $( "#price-range" ).slider({
        range: true,
        min: 10000,
        max: 1000000,
        values: [ 30000, 500000 ],
        slide: function (event, ui) {
            //console.log(ui.values[1]);
            $( "#price" ).val( ui.values[ 0 ] + " - " + ui.values[ 1 ] );
        }
    });
   $( "#price" ).val( $( "#price-range" ).slider( "values", 0 ) + " - " + $( "#price-range" ).slider( "values", 1 ) );

    // Checkbox Replacements

    $('input.checkbox').iCheck({
        checkboxClass: 'icheckbox_square-green',
        radioClass: 'iradio_square-green',
        increaseArea: '20%'
    });

    // Gallery Grid

    $('.grid').masonry({
        itemSelector: '.grid-item',
        columnWidth: '.grid-sizer',
        percentPosition: true,
        gutter: 0
    });

    // Counter

    $(function() {
        var value;
        $('.counter span').appear();
        $(document.body).on('appear', '.counter span', function(e, $affected) {
            $affected.each(function() {
                value = $(this).data('fact');
                $(this).animateNumbers( value, false, 1000, "easeOutBounce" );
            });
        });
    });

    $('.animated').appear();

});
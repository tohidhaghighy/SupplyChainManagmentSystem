$(document).ready(function(){



	//////////////////////////////////////////////// Loding Page ////////////////////////////////////////////////

	$(function preloaderLoad() {
		$('#loading-wrapper').addClass('del-loading');

    });



	//////////////////////////////////////////////// Mega Menu ////////////////////////////////////////////////

	$(".menu .mega-menu .category-list .category-item:first-child").addClass("active");
	$(".menu .mega-menu .category-list .category-item").on("mouseenter", function () {
	  	$(this).addClass("active").siblings().removeClass("active");
	});



	//////////////////////////////////////////////// Slider ////////////////////////////////////////////////

	$(".slider .owl-carousel").owlCarousel({
		rtl:true,
		loop:true,
		autoplay:true,
    	autoplayTimeout:5000,
    	autoplayHoverPause:true,
		items:1,
		dots:true,

	});



	//////////////////////////////////////////////// Category ////////////////////////////////////////////////

	$(".category .owl-carousel").owlCarousel({
		rtl:true,
		loop:true,
		items:8,
		dots:true,

		responsive:{
    	    0:{
    	        items:2,

    	    },
    	    500:{
    	        items:3,

    	    },
    	    700:{
    	        items:4,

    	    },
    	    1000:{
    	        items:6,

    	    },
    	    1200:{
    	        items:8,
    	    },
    	}

	});



	//////////////////////////////////////////////// New Products ////////////////////////////////////////////////

	$(".new-products .owl-carousel").owlCarousel({
		rtl:true,
		loop:true,
		items:3,
		nav:true,
		dots:false,
		navText : ["<i class='fal fa-chevron-right'></i>","<i class='fal fa-chevron-left'></i>"],

		responsive:{
    	    0:{
    	        items:1,

    	    },
    	    500:{
    	        items:2,

    	    },
    	    1200:{
    	        items:3,

    	    }
    	}

	});



	//////////////////////////////////////////////// Popular Products ////////////////////////////////////////////////

	$(".popular-products .owl-carousel").owlCarousel({
		rtl:true,
		loop:true,
		items:6,
		nav:true,
		dots:false,
		navText : ["<i class='fal fa-chevron-right'></i>","<i class='fal fa-chevron-left'></i>"],

		responsive:{
    	    0:{
    	        items:1,

    	    },
    	    500:{
    	        items:2,

    	    },
    	    900:{
    	        items:3,

    	    },
    	    1000:{
    	        items:4,

    	    },
    	    1200:{
    	        items:5,

    	    }
    	}

	});



	//////////////////////////////////////////////// Amazing Offer Right ////////////////////////////////////////////////

	$(".amazing-offer .amazing-right .owl-carousel").owlCarousel({
		rtl:true,
		loop:true,
		items:1,
		nav:true,
		dots:false,
		navText : ["<i class='fal fa-chevron-right'></i>","<i class='fal fa-chevron-left'></i>"],

	});



	//////////////////////////////////////////////// Date Counting ////////////////////////////////////////////////

    $('[data-countdown]').each(function() {
        var $this = $(this),
            finalDate = $(this).data('countdown');

        $this.countdown(finalDate, function(event) {
            $this.html(event.strftime('<ul><li><span class="number">%S</span><span class="text">ثانیه</span></li> <li><span class="number">%M</span><span class="text">دقیقه</span></li> <li><span class="number">%H</span><span class="text">ساعت</span></li> <li><span class="number">%D</span><span class="text">روز</span></li></ul>'));
        });

    });



    //////////////////////////////////////////////// Amazing Offer Moment ////////////////////////////////////////////////

	$(".amazing-offer .moment .owl-carousel").owlCarousel({
		rtl:true,
		loop:true,
		items:1,
		autoplay:true,
		autoplayTimeout:5000,
		autoplayHoverPause:true,

	});



	//////////////////////////////////////////////// Brand ////////////////////////////////////////////////

	$(".brand .owl-carousel").owlCarousel({
		rtl:true,
		loop:true,
		items:7,
		nav:true,
		dots:false,
		navText : ["<i class='fal fa-chevron-right'></i>","<i class='fal fa-chevron-left'></i>"],

		responsive:{
    	    0:{
    	        items:1,

    	    },
    	    300:{
    	        items:2,

    	    },
    	    600:{
    	        items:4,

    	    },
    	    1000:{
    	        items:7,

    	    }
    	}

	});



	//////////////////////////////////////////////// Blog ////////////////////////////////////////////////

	$(".blog .owl-carousel").owlCarousel({
		rtl:true,
		loop:true,
		items:4,
		nav:true,
		dots:false,
		navText : [
			"<i class='fal fa-chevron-right'></i>",
			"<i class='fal fa-chevron-left'></i>"
		],

		responsive:{
    	    0:{
    	        items:1,

    	    },
    	    450:{
    	        items:2,

    	    },
    	    700:{
    	        items:3,

    	    },
    	    1200:{
    	        items:4,

    	    }
    	}

	});



	//////////////////////////////////////////////// Single Product Gallery  ////////////////////////////////////////////////

	var bigimage = $("#big-pic");
	var thumbs = $("#thumbs");
	var syncedSecondary = true;
		bigimage
	.owlCarousel({
	   	rtl:true,
	   items: 1,
	   nav: true,
	   dots: false,
	   loop: true,
	   responsiveRefreshRate: 200,
	   navText: [
	    	'<i class="fal fa-chevron-left" aria-hidden="true"></i>',
	    	'<i class="fal fa-chevron-right" aria-hidden="true"></i>'
	   ],

	})
	.on("changed.owl.carousel", syncPosition);
		thumbs
	.on("initialized.owl.carousel", function() {
	   	thumbs
	    .find(".owl-item")
	    .eq(0)
	    .addClass("current");

	})
	.owlCarousel({
		rtl:true,
	   items: 5,
	   dots: false,
	   nav: false,
	   navText: [
	    	'<i class="fal fa-chevron-left" aria-hidden="true"></i>',
	    	'<i class="fal fa-chevron-right" aria-hidden="true"></i>'
	   ],

	})
   	.on("changed.owl.carousel", syncPosition2);
	function syncPosition(el) {
	   	var count = el.item.count - 1;
	   	var current = Math.round(el.item.index - el.item.count / 2 - 0.5);
			   if (current < 0) {
	   	  			current = count;
	   			}
	   if (current > count) {
	    	current = 0;
	   	}
	  	
	   thumbs
	    .find(".owl-item")
	    .removeClass("current")
	    .eq(current)
	    .addClass("current");
		var onscreen = thumbs.find(".owl-item.active").length - 1;
		var start = thumbs
		.find(".owl-item.active")
		.first()
		.index();
		var end = thumbs
		.find(".owl-item.active")
		.last()
		.index();
		if (current > end) {
	    	thumbs.data("owl.carousel").to(current, 100, true);
	   	}
	   if (current < start) {
	    	thumbs.data("owl.carousel").to(current - onscreen, 100, true);
	   	}
	}
	function syncPosition2(el) {
  		if (syncedSecondary) {
  		 	var number = el.item.index;
  		 	bigimage.data("owl.carousel").to(number, 100, true);
  		}
	}
	thumbs.on("click", ".owl-item", function(e) {
		e.preventDefault();
		var number = $(this).index();
		bigimage.data("owl.carousel").to(number, 300, true);
	});



	//////////////////////////////////////////////// Show More ////////////////////////////////////////////////

	var list = $("#show-more li");
    var numToShow = 5;
    var button = $("#next");
    var numInList = list.length;
    list.hide();
    if (numInList > numToShow) {
    	button.show();
    }
    list.slice(0, numToShow).show();

    button.click(function(){
        var showing = list.filter(':visible').length;
        list.slice(showing - 1, showing + numToShow).fadeIn();
        var nowShowing = list.filter(':visible').length;
        if (nowShowing >= numInList) {
         	button.hide();
        }
    });



    //////////////////////////////////////////////// Color Variable ////////////////////////////////////////////////

	$(".color-box .color").click( function(){
	    if ( $(this).hasClass('active') ) {
	        $(this).removeClass('active');
	    }
	    else {
	        $('.color-box .color').removeClass('active');
	        $(this).addClass('active');    
	    }
	});



	//////////////////////////////////////////////// Quantitys Product ////////////////////////////////////////////////

	$('.quantity').on('click', '.plus', function(e) {
        let $input = $(this).prev('input.qty');
        let val = parseInt($input.val());
        $input.val( val+1 ).change();
    });
    $('.quantity').on('click', '.minus',  function(e) {
        let $input = $(this).next('input.qty');
        var val = parseInt($input.val());
        if (val > 0) {
            $input.val( val-1 ).change();
        } 
    });



    //////////////////////////////////////////////// Tabs Product ////////////////////////////////////////////////

	$(".tabs-stage .item-tab").hide();
	$(".tabs-stage .item-tab:first").show();
	$(".tabs-nav .nav-item:first").addClass("tab-active");

	$(".tabs-nav .nav-item a").on('click', function(event){
		event.preventDefault();
		$(".tabs-nav .nav-item").removeClass("tab-active");
		$(this).parent().addClass("tab-active");
		$(".tabs-stage .item-tab").hide();
		$($(this).attr("href")).show();
	});


	//////////////////////////////////////////////// Shop filter Category ////////////////////////////////////////////////

	$(".shop .filter .category-menu .item").click( function(){
	    if ( $(this).hasClass('active') ) {
	        $(this).removeClass('active');
	    }
	    else {
	        $('.shop .filter .category-menu .item').removeClass('active');
	        $(this).addClass('active');    
	    }
	});



	//////////////////////////////////////////////// Shop filter Price ////////////////////////////////////////////////

	const rangeInput = document.querySelectorAll(".shop-product .shop .filter .pric .wrapper .range-input input"),
	  priceInput = document.querySelectorAll(".shop-product .shop .filter .pric .wrapper .price-input input"),
	  range = document.querySelector(".shop-product .shop .filter .pric .wrapper .slider .progress");
	let priceGap = 1000;
	
	priceInput.forEach((input) => {
	  input.addEventListener("input", (e) => {
	    let minPrice = parseInt(priceInput[0].value),
	      maxPrice = parseInt(priceInput[1].value);
	
	    if (maxPrice - minPrice >= priceGap && maxPrice <= rangeInput[1].max) {
	      if (e.target.className === "input-min") {
	        rangeInput[0].value = minPrice;
	        range.style.right = (minPrice / rangeInput[0].max) * 100 + "%";
	      } else {
	        rangeInput[1].value = maxPrice;
	        range.style.left = 100 - (maxPrice / rangeInput[1].max) * 100 + "%";
	      }
	    }
	  });
	});
	
	rangeInput.forEach((input) => {
	  input.addEventListener("input", (e) => {
	    let minVal = parseInt(rangeInput[0].value),
	      maxVal = parseInt(rangeInput[1].value);
	
	    if (maxVal - minVal < priceGap) {
	      if (e.target.className === "range-min") {
	        rangeInput[0].value = maxVal - priceGap;
	      } else {
	        rangeInput[1].value = minVal + priceGap;
	      }
	    } else {
	      priceInput[0].value = minVal;
	      priceInput[1].value = maxVal;
	      range.style.right = (minVal / rangeInput[0].max) * 100 + "%";
	      range.style.left = 100 - (maxVal / rangeInput[1].max) * 100 + "%";
	    }
	  });
	});



	//////////////////////////////////////////////// Shop Filter Color ////////////////////////////////////////////////

	$(".color-box .color-item").click(function() {
        $(this).toggleClass("active");
    });



	//////////////////////////////////////////////// Faq Accordion ////////////////////////////////////////////////
	var acc = document.getElementsByClassName('faqs-title');
	var i;
	
	for (i = 0; i < acc.length; i++) {
	    acc[i].addEventListener('click', function () {
	        this.classList.toggle('active');
	        var panel = this.nextElementSibling;
	        if (panel.style.maxHeight) {
	            panel.style.maxHeight = null;
	        } else {
	            panel.style.maxHeight = panel.scrollHeight + 'px';
	        }
	    });
	}



	//////////////////////////////////////////////// Mobile Menu ////////////////////////////////////////////////

	$(".mobile-menu .btn-mobile").on('click', function() {
    	$(".menu-overlay").show();
    	$(".mobile-content").toggleClass("active");
    });

    $(".menu-overlay").on('click', function() {
    	if ($(".mobile-content").hasClass("active")) {
    		$(".mobile-content").removeClass("active");
    	}
    	$(this).hide();
    });

    $(".mobile-menu .mobile-content ul li > a").on("click", function (event) {
    	event.preventDefault();
    	$(this).hasClass("active");
    	$(this).siblings("ul").toggleClass("d-block");
    });

    $(".mobile-menu .mobile-content .category .item > a").on("click", function (event) {
    	$(this).parents("li").toggleClass("active");
    });


	
	//////////////////////////////////////////////// Back To Top ////////////////////////////////////////////////
	
	$(window).on('scroll', function() {
		var height = $(window).scrollTop();
		if (height > 100) {
			$('#tops-button').fadeIn();
		} else {
			$('#tops-button').fadeOut();
		}
	});



	//////////////////////////////////////////////// Template Color  ////////////////////////////////////////////////
	$("#template-color .box-color .color").click( function(){
	    if ( $(this).hasClass("active") ) {
	        $(this).removeClass("active");
	    }
	    else {
	        $("#template-color .box-color .color").removeClass("active");
	        $(this).addClass("active");    
	    }
	    
	    var colorPath = $(this).attr("data-path");
    	$("#colorswitch").attr("href", colorPath);
	});

	$("#template-color .btn-color").click(function(){
		$(this).parent("#template-color").toggleClass("active");

	})




});



var _x = document.getElementById('myCarousel').clientHeight;
//alert(self.window.innerWidth);
$('#my').css('margin-top', _x);

if (self.window.innerWidth < 768) {
    $('#my').css('margin-top', 0);
}

window.addEventListener("resize", function (event) {
    var _x = document.getElementById('myCarousel').clientHeight;
    $('#my').css('margin-top', _x);

    if (self.window.innerWidth < 768) {
        $('#my').css('margin-top', 0);
    }
});

$(function () {
    $('.showClick-Pie').click(function () {
        $('.more-pie').slideDown("slow");
        $('.showClick-Pie').hide();
        $('.hideClick-Pie').show();
    });
    $('.hideClick-Pie').click(function () {

        $('.more-pie').slideUp("slow");
        $('.showClick-Pie').show();
        $('.hideClick-Pie').hide();
    });
});

$(function () {
    $('.showClick-Cake').click(function () {
        $('.more-cake').slideDown("slow");
        $('.showClick-Cake').hide();
        $('.hideClick-Cake').show();
    });
    $('.hideClick-Cake').click(function () {

        $('.more-cake').slideUp("slow");
        $('.showClick-Cake').show();
        $('.hideClick-Cake').hide();
    });
});

$(function () {
    $('.showClick-Ic').click(function () {
        $('.more-ic').slideDown("slow");
        $('.showClick-Ic').hide();
        $('.hideClick-Ic').show();
    });
    $('.hideClick-Ic').click(function () {

        $('.more-ic').slideUp("slow");
        $('.showClick-Ic').show();
        $('.hideClick-Ic').hide();
    });
});

$(function () {
    $('.showClick-Drink').click(function () {
        $('.more-drink').slideDown("slow");
        $('.showClick-Drink').hide();
        $('.hideClick-Drink').show();
    });
    $('.hideClick-Drink').click(function () {

        $('.more-drink').slideUp("slow");
        $('.showClick-Drink').show();
        $('.hideClick-Drink').hide();
    });
});

$(function () {
    $('#_menu').click(function () {
        $('#_dropdown-menu').slideToggle(200);
    });
});

$(function () {
    $('.just-click').click(function () {
        $('#_dropdown-menu').slideUp(200);
    });
});

$(window).click(function () {
    $('#_dropdown-menu').slideUp(200);
});

//owl carousel sale item
$(document).ready(function () {
    $('#sale-slider').owlCarousel({
        center: true,
        loop: true,lazyLoad: true,
        margin: 20,
        responsive: {
            0: {
                items: 1
            },
            500: {
                items: 2
            },
            768: {
                items: 4
            },
            1140: {
                items: 5
            }
        }
    });
    var owl = $('#sale-slider');
    owl.on('mousewheel', '.owl-stage', function (e) {
        if (e.deltaY > 0) {
            owl.trigger('next.owl');
        } else {
            owl.trigger('prev.owl');
        }
        e.preventDefault();
    });
});
$('#_clip').owlCarousel({
    items: 1,
    merge: true,
    loop: true,
    margin: 20,
    video: true,
    lazyLoad: true,
    center: true,
    responsive: {
        480: {
            items: 2
        },
        600: {
            items: 4
        }
    }
})



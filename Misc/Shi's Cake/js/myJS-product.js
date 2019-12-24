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

$(function () {
    var widthWindow = window.outerWidth;

    if (widthWindow < 992 && widthWindow >= 768) {
        var widthNavRow = document.getElementById("navRow").offsetWidth - 15;
        $('.navbar-collapse').width(widthNavRow + 15);
        $('.navbar-nav').width(widthNavRow);
    } else {
        $('.navbar-collapse').width = '100%';
        $('.navbar-nav').width = '100%';
    }
});

window.addEventListener("resize", function (event) {
    var widthWindow = window.outerWidth;

    if (widthWindow < 992 && widthWindow >= 768) {
        var widthNavRow = document.getElementById("navRow").offsetWidth - 15;
        $('.navbar-collapse').width(widthNavRow + 15);
        $('.navbar-nav').width(widthNavRow);
    } else {
        $('.navbar-collapse').width = '100%';
        $('.navbar-nav').width = '100%';
    }
});


$(document).ready(function () {
    $('#img-carousel').owlCarousel({
        items: 6,
        margin: 10,
    });
    var owl = $('#img-carousel');
    owl.on('mousewheel', '.owl-stage', function (e) {
        if (e.deltaY > 0) {
            owl.trigger('next.owl');
        } else {
            owl.trigger('prev.owl');
        }
        e.preventDefault();
    });
});

$('.clickme').on('click', function (e) {
    e.preventDefault();

    $('.clickme').removeClass("selected");
    $(this).addClass("selected");
});

function clickToDisplay(imgs) {
    var expandImg = document.getElementById("main-dish");
    expandImg.src = imgs.src;
    expandImg.parentElement.style.display = "block";
    $('.clickme').on('click', function (e) {
        e.preventDefault();

        $('.clickme').removeClass("selected");
        $(this).addClass("selected");
    });
}

function addCard(x) {
    var originalText = x.getElementsByTagName('p')[0].innerHTML;
    x.getElementsByTagName('p')[0].innerHTML = "ADDED TO CARD";
    x.getElementsByTagName('p')[0].style.fontWeight = "bold";

    setTimeout(function () {
        x.getElementsByTagName('p')[0].innerHTML = originalText;
        x.getElementsByTagName('p')[0].style.fontWeight = "normal";
    }, 1000);
}

$(document).ready(function () {
    $('#_topping').owlCarousel({
        items: 3,
        margin: 10,
        responsive: {
            768: {
                items: 5
            }
        }
    });
    var owl = $('#_topping');
    owl.on('mousewheel', '.owl-stage', function (e) {
        if (e.deltaY > 0) {
            owl.trigger('next.owl');
        } else {
            owl.trigger('prev.owl');
        }
        e.preventDefault();
    });
});

var liked = false;
function changeHeart(heart){
    liked = !liked;
    
    if (liked == true){
        $('.nodelike').addClass("pink-heart");
    }
    else {
        $('.nodelike').removeClass("pink-heart");
    }
    
}






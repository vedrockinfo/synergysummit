jQuery('.owl-carousel').owlCarousel({
    loop: true,
    margin: 30,
    autoplay: true,
    dots: true,
    nav: false,
    responsiveClass: true,
    autoHeight: true,
    autoplayTimeout: 7000,
    smartSpeed: 800,
    responsive:{
        0:{
            items:1
        },
        600:{
            items:3
        },
        1000:{
            items:5
        }
    }
})


document.addEventListener("DOMContentLoaded", function(){
        
        window.addEventListener('scroll', function() {
             
          if (window.scrollY > 200) {
            document.getElementById('navbar_top').classList.add('fixed-top');
            // add padding top to show content behind navbar
            navbar_height = document.querySelector('.navbar').offsetHeight;
            document.body.style.paddingTop = navbar_height + 'px';
          } else {
             document.getElementById('navbar_top').classList.remove('fixed-top');
             // remove padding top from body
            document.body.style.paddingTop = '0';
          } 
        });
      }); 
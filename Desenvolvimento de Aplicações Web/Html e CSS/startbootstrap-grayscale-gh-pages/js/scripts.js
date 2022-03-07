/*!
* Start Bootstrap - Grayscale v7.0.4 (https://startbootstrap.com/theme/grayscale)
* Copyright 2013-2021 Start Bootstrap
* Licensed under MIT (https://github.com/StartBootstrap/startbootstrap-grayscale/blob/master/LICENSE)
*/
//
// Scripts
//


window.addEventListener('DOMContentLoaded', event => {

    // Navbar shrink function
    var navbarShrink = function () {
        const navbarCollapsible = document.body.querySelector('#mainNav');
        if (!navbarCollapsible) {
            return;
        }
        if (window.scrollY === 0) {
            navbarCollapsible.classList.remove('navbar-shrink')
        } else {
            navbarCollapsible.classList.add('navbar-shrink')
        }

    };

    // Shrink the navbar 
    navbarShrink();

    // Shrink the navbar when page is scrolled
    document.addEventListener('scroll', navbarShrink);

    // Activate Bootstrap scrollspy on the main nav element
    const mainNav = document.body.querySelector('#mainNav');
    if (mainNav) {
        new bootstrap.ScrollSpy(document.body, {
            target: '#mainNav',
            offset: 74,
        });
    };

    // Collapse responsive navbar when toggler is visible
    const navbarToggler = document.body.querySelector('.navbar-toggler');
    const responsiveNavItems = [].slice.call(
        document.querySelectorAll('#navbarResponsive .nav-link')
    );
    responsiveNavItems.map(function (responsiveNavItem) {
        responsiveNavItem.addEventListener('click', () => {
            if (window.getComputedStyle(navbarToggler).display !== 'none') {
                navbarToggler.click();
            }
        });
    });

    function auto_height(elem) {  /* javascript */
        elem.style.height = "1px";
        elem.style.height = (elem.scrollHeight)+"px";
    }

});

$(document).ready(function() {
    $("#basic-form").validate({
      rules: {
        email: {
          required: true,
          email: true
        },
        email: {
          email: "The email should be in the format: abc@domain.tld"
        },
      }
    });
  });

function registerFunction() {
    var email = document.getElementById("email").value;
    var password = document.getElementById("password").value;
    var passwordRe = document.getElementById("passwordRe").value;

    if(password == 0 || email == 0)
    {   
        alert("Todos os campos precisam de ser preenchidos");
        return false
    }
    else if(password != passwordRe)
    {
        alert("As passwords precisam de ser iguais");
        return false
    }
    else if (password == passwordRe){
        alert("Registo efectuado com sucesso");
        return true
    }
    else {
        alert("Algo deu erro e nós também não sabemos o que foi");
        return false
    }
}

function loginFunction(){
    var username = document.getElementById("email").value;
    var password = document.getElementById("password").value;

    if(username == 0)
    {
        alert("Insira o seu email");
        return false
    }
    else if(password == 0)
    {
        alert("Insira a sua password");
        return false
    }
    else if(username == "daniel@gmail.com" || password == "1234")
    {
        alert("Login efectuado com sucesso");
        return true
    }
    else{
        alert("Os dados inseridos estão incorrectos");
        return false
    }

}
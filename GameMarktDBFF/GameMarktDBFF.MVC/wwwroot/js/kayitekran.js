
function kayitOl()
{ 
alert("Sayın " + document.getElementById("nickname").value + " kaydınız başarıyla tamamlanmıştır.");
}

function girisYap(email, sifre) {
    var email = document.getElementById("username").value;
    var sifre = document.getElementById("password").value;

    if (email == "tdincerkaan@gmail.com") {
        if (sifre == "sifredeneme4444") {



            alert("Giriş Yapıldı");
            window.location.replace("https://localhost:44380/Home/GirisAnasayfa");

            return true;
        }

    }
    else if (kullanici = !"tdincerkaan@gmail.com") {
        if (sifre == "sifredeneme4444") {
            alert("Kullanıcı Adı Yalnış");
            return false;
        }
    }
    else if (kullanici == "tdincerkaan@gmail.com") {
        if (sifre = !"sifredeneme4444") {
            alert("Şifreniz Yalnış");
            return false;
        }
    }
    else {
        alert("Şifre ve Kullanıcı adı yanlış");
        return false;
    }
}

function satinAl()
{ 
alert("Satın alma işlemi gerçekleşti. Anasayfa'ya yönlendiriliyorsunuz...");
window.location.assign("girisyeni.html");
}


  /* When the user clicks on the button, 
  toggle between hiding and showing the dropdown content */
  function myFunction() {
    document.getElementById("myDropdown").classList.toggle("show");
  }
  
  // Close the dropdown if the user clicks outside of it
  window.onclick = function(e) {
    if (!e.target.matches('.dropbtn')) {
    var myDropdown = document.getElementById("myDropdown");
      if (myDropdown.classList.contains('show')) {
        myDropdown.classList.remove('show');
      }
    }
  }
 


  /* When the user clicks on the button, 
  toggle between hiding and showing the dropdown content */
  function myFunction1() {
    document.getElementById("myDropdown1").classList.toggle("show");
  }
  
  // Close the dropdown if the user clicks outside of it
  window.onclick = function(e) {
    if (!e.target.matches('.dropbtn')) {
    var myDropdown = document.getElementById("myDropdown1");
      if (myDropdown.classList.contains('show')) {
        myDropdown.classList.remove('show');
      }
    }
  }
  

    /* When the user clicks on the button, 
    toggle between hiding and showing the dropdown content */
    function myFunction2() {
      document.getElementById("myDropdown2").classList.toggle("show");
    }
    
    // Close the dropdown if the user clicks outside of it
    window.onclick = function(e) {
      if (!e.target.matches('.dropbtn')) {
      var myDropdown = document.getElementById("myDropdown2");
        if (myDropdown.classList.contains('show')) {
          myDropdown.classList.remove('show');
        }
      }
    }
 
      /* When the user clicks on the button, 
      toggle between hiding and showing the dropdown content */
      function myFunction3() {
        document.getElementById("myDropdown3").classList.toggle("show");
      }
      
      // Close the dropdown if the user clicks outside of it
      window.onclick = function(e) {
        if (!e.target.matches('.dropbtn')) {
        var myDropdown = document.getElementById("myDropdown3");
          if (myDropdown.classList.contains('show')) {
            myDropdown.classList.remove('show');
          }
        }
      }

     
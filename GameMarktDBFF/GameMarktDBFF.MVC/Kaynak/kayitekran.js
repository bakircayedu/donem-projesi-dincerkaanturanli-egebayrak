
function kayitOl()
{ 
alert("Sayın " + document.getElementById("nickname").value + " kaydınız başarıyla tamamlanmıştır.");
window.location.assign("girisyap.html");
}

function girisYap()
{ 
alert("Sayın " + document.getElementById("nickname").value + " başarıyla giriş yaptınız. Yönlendiriliyosunuz...");
window.location.assign("girisyeni.html");
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

     
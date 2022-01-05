function girisKontrol(kullanici,sifre){
    var kullanici = document.getElementById("username").value;
    var sifre = document.getElementById("password").value;

    if (kullanici == "admin") {
        if (sifre == "admin") {
            alert("Giriş Yapıldı");
            window.location.replace("https://localhost:44380/Home/GirisAnasayfa");

            return true;
        }
    }
    else if (kullanici == "admin" || sifre == "admin") {
        if (sifre = !"admin") {
            alert("Kullanıcı Adı ya da Sifreniz yanlış!");
            return false;
        }
    }


    
}
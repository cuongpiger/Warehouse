function HightLight(control, flag) {
    switch (flag) {
        case 1:
            control.className = "onFocus"
            break;
        case 2:
            control.className = "normal";
            break;
        case 3:
            control.className = "onMouseOver";
            break;
    }
}

function ChangeLanguage() {
    var lang = document.getElementById("cmdLanguage")
    switch (lang.value) {
        case "Tiếng Anh":
            document.getElementById("idHeader").innerHTML = "Login Form";
            document.getElementById("idUserName").innerHTML = "User Name";
            document.getElementById("idPassword").innerHTML = "Password";
            document.getElementById("idLanguage").innerHTML = "Language";
            document.getElementById("idEng").innerHTML = "English";
            document.getElementById("idVN").innerHTML = "Vietnamese";
            document.getElementById("btnSubmit").value = "Login";
            document.getElementById("btnClose").value = "Close";
            break;
        case "Vietnamese":
            document.getElementById("idHeader").innerHTML = "Khung đăng nhập";
            document.getElementById("idUserName").innerHTML = "Tên đăng nhập";
            document.getElementById("idPassword").innerHTML = "Mật khẩu";
            document.getElementById("idLanguage").innerHTML = "Ngôn ngữ";
            document.getElementById("idEng").innerHTML = "Tiếng Anh";
            document.getElementById("idVN").innerHTML = "Tiếng Việt";
            document.getElementById("btnSubmit").value = "Đăng nhập";
            document.getElementById("btnClose").value = "Đóng";
            break;
    }
}

function CheckSubmit() {
    var username = document.getElementById("txtUserName");

    if (username.value == ""){
        alert("Yêu cầu nhập tên đăng nhập!");
        username.focus();
        return false;
    }

    var password = document.getElementById("txtPassword");

    if (password.value == ""){
        alert("Yêu cầu nhập mật khẩu!");
        password.focus()
        return false;
    }

    return true;
}
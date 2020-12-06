function login()  {
   var _email = document.getElementById("inputEmail").value;
   var _password = document.getElementById("inputPassword").value;
   
   if (_password.length < 8) {
    alert("Password phải 8 ký tự trở lên.");
    return false;
  }
  if(_email.isEmpty||_password.isEmpty)
  {
    alert("Tài khoản hoặc mật khẩu nhập không đúng");
    return false;
  }
   alert("Đăng ký thành công!")
   return true;
  }
  function isEmpty(val){
    return (val === undefined || val == null || val.length <= 0) ? true : false;
}
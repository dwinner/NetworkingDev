/// <reference path="../../Scripts/jquery-2.2.0.js" />

function showAsLoggedIn() {
   $("div.loggedIn").show();
   $("div.loggedOut").hide();
}

function showAsLoggedOut() {
   $("div.loggedOut").show();
   $("div.loggedIn").hide();
}

function openCanvas(id) {
   var canvasUrl = "/Content/Canvas.html?canvasId=" + id;
   if (window.innerWidth <= 800 && window.innerHeight <= 600) {
      window.location.href = canvasUrl;
   } else {
      window.open(canvasUrl, "_blank");
   }
}

$("#btnLogin").click(function () {
   var dataObject = { "UserName": $("form#loginForm input#username").val(), "Password": $("form#loginForm input#password").val() };
   $.ajax({
      url: "/public/api/login",
      type: "post",
      contentType: "application/json",
      data: JSON.stringify(dataObject),
      success: function (data, status) {
         if (status === "success" && data === "Success") {
            showAsLoggedIn();
         } else {
            $("span#loginError").show();
         }
      },
      error: function (/*data*/) {
         $("span#loginError").show();
         showAsLoggedOut();
      }
   });
});

$("#btnCreateAccount").click(function () {
   $("span#passwordNotEqual").hide();
   if ($("div#createAccount input#password").val() !== $("div#createAccount input#verifyPassword").val()) {
      $("span#passwordNotEqual").show();
      return;
   }

   var dataObject = {
      "UserName": $("div#createAccount input#username").val(),
      "Password": $("div#createAccount input#password").val()
   };

   $.ajax({
      url: "/public/api/user",
      type: "post",
      contentType: "application/json",
      data: JSON.stringify(dataObject),
      success: function (data, status) {
         if (status === "success" && data === "Success") {
            showAsLoggedIn();
         } else {
            $("span#createAccountError").show();
         }
      },
      error: function (/*data*/) {
         showAsLoggedOut();
         $("span#createAccountError").show();
      }
   });
});

$("#btnCreateAccount").click(function () {
   var dataObject = {
      "Name": $("div#createCanvasContainer input#canvasname").val(),
      "Description": $("div#createCanvasContainer input#canvasdescription").val()
   };

   $.ajax({
      url: "/api/canvas",
      type: "post",
      contentType: "application/json",
      data: JSON.stringify(dataObject),
      dataType: "json",
      success: function (data, status) {
         if (status === "success" && data !== "undefined") {
            openCanvas(data);
         } else {
            $("span#createCanvasError").show();
         }
      },
      error: function (/*data*/) {
         $("span#createCanvasError").show();
      }
   });
});

$("#btnJoinCanvas").click(function () {
   var dataObject = {
      "Name": $("div#joinCanvasContainer input#canvasname").val()
   };

   $.ajax({
      url: "/api/canvas",
      type: "put",
      contentType: "application/json",
      data: JSON.stringify(dataObject),
      dataType: "json",
      success: function (data, status) {
         if (status === "success" && data !== "undefined") {
            openCanvas(data);
         } else {
            $("span#joinCanvasError").show();
         }
      },
      error: function (/*data*/) {
         $("span#joinCanvasError").show();
      }
   });
});

$("#btnLogout").click(function () {
   $.ajax({
      url: "/public/api/logout",
      type: "post",
      success: function (/*data*/) {
         showAsLoggedOut();
      }
   });
});
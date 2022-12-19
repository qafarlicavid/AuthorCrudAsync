//$(document).on("click", '.show-author-modal', function (e) {
//    console.log("salam")
//    e.preventDefault();


//    fetch(e.target.href)
//        .then(response => response.text())
//        .then(data => {

//            $(".author-modal-body").html(data);


//        })


//    $("#exampleModalCenter").modal("show");

//})




//$(document).on("click", '.show-book-modal', function (e) {
//    e.preventDefault();

//    //fetch(e.target.href)
//    //    .then(response => response.text())
//    //    .then(data => {

//    //        $('.product-details-modal').html(data);


//    //    })

//    $.ajax({
//        type: "POST",
//        url: url,
//        data: {

//        },
//        success: function (msg) {
//            $("#getCodeModal").modal("toggle");
//            $("#getCode").html(msg);
//        }
//    });



//    $("#quickModal").modal("show");

//})
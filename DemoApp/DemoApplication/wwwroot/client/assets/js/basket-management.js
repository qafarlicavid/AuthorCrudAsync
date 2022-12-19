let buttons = document.querySelectorAll(".add-product-to-basket-btn")

buttons.forEach(x => {
    x.addEventListener("click", function (e) {
        e.preventDefault();

        fetch(e.target.href)
            .then(response => response.text())
            .then(data => {
                $('.cart-block').html(data);
            })
    })
})

//let deleteButtons = document.querySelectorAll(".remove-product-to-basket-btn")

//deleteButtons.forEach(x => {
//    x.addEventListener("click", function (e) {
//        e.preventDefault();

//        fetch(e.target.href)
//            .then(response => response.text())
//            .then(data => {
//                $('.cart-block').html(data);
//            })
//    })
//})


$(document).on("click", '.remove-product-to-basket-btn', function (e) {
    e.preventDefault();

    fetch(e.target.href)
        .then(response => response.text())
        .then(data => {

            $('.cart-block').html(data);


        })

})


//$(document).on("click", ".single-btn", function (e) {
//    e.preventDefault();

//    var id = $(this).attr("data-id");

//    fetch('https://localhost:44348/book/addtobasket/' + id)
//        .then(response => response.text())
//        .then(data => {
//            $('.cart-block').html(data);
//        })

//});



$(document).on("click", '.show-book-modal', function (e) {
    e.preventDefault();

    fetch(e.target.href)
        .then(response => response.text())
        .then(data => {

            $('.product-details-modal').html(data);


        })




    $("#quickModal").modal("show");

})



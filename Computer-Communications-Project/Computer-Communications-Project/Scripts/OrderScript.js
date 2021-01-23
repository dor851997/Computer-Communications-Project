
function seatCol(el ,price) {
    if (el.style.backgroundColor == "yellow") {
        el.style.backgroundColor = "white";
    }
    else {
       el.style.backgroundColor = "yellow";
    }
    var x = document.querySelectorAll(".selectedSeats");
    var i;
    var count = 0;
    for (i = 0; i < x.length; i++) {
        if (x[i].style.backgroundColor == "yellow") {
            count++;
        }
    }
    document.getElementById("myTotal").innerHTML = count;
    document.getElementById("totalPrice").innerHTML = count * price;
}
//function calcTickets() {
//    alert('!!!!!!!!!');
//    var x = document.querySelectorAll(".selectedSeats");
//    var i;
//    var count = 0;
//    for (i = 0; i < x.length; i++) {
//        if (x[i].style.ckgroundColor == "yellow") {
//            count++;
//        }
//    }
//    '@ViewBag.totalVal' = 10;
//    document.body.style.backgroundColor = "red";
//}

function seatCol(el ,price,row,colm) {
    if (el.style.backgroundColor == "yellow") {
        el.style.backgroundColor = "white";
    }
    else {
       el.style.backgroundColor = "yellow";
    }
    var x = document.querySelectorAll(".selectedSeats");
    var i;
    var count = 0;
    document.getElementById("line").value = String(row);
    document.getElementById("chair").value = String(colm);
    for (i = 0; i < x.length; i++) {
        if (x[i].style.backgroundColor == "yellow") {
            count++;
        }
    }
    document.getElementById("myTotal").innerHTML = count;
    document.getElementById("totalPrice").innerHTML = count * price;
    
}

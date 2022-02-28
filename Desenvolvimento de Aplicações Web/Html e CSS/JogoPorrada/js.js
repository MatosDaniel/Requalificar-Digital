function hit(){
    var health2 = document.getElementById("myHealth2").clientWidth;
    health2 = health2 - 100;
    document.getElementById("myHealth2").style.width = health2 + "px";
    if( health2 > 0)
    {
    document.getElementById("myHealth2").innerHTML = health2 + "<strong> HP </strong>";
    }
    else
    {
        document.getElementById("myHealth2").innerHTML = "DEAD";
    }
    if (health2 < 350 && health2 >199)
    {
        document.getElementById("myHealth2").style.backgroundColor = "orange";
    }
    else if(health2 < 198)
    {
        document.getElementById("myHealth2").style.backgroundColor = "red";
    }
    // document.getElementById("myHealth").style.width = "95%";
    // document.getElementById("myHealth").innerHTML = "<strong>95%</strong>";
}
function heal(){}
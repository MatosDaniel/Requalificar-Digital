function hit(){
    var health2 = document.getElementById("myHealth2").clientWidth;
    health2 = health2 - 100;
    document.getElementById("myHealth2").style.width = health2 + "px";
    if( health2 > 0)
    {
    document.getElementById("myHealth2").innerHTML = "<strong>" + health2 + "</strong>" + "<strong> HP </strong>";
    }
    else
    {
        document.getElementById("myHealth2").innerHTML = "DEAD";
        document.getElementById("myHealth2").style.marginLeft = "40%";
        document.getElementById("myHealth2").style.backgroundColor = "white";
        alert("Player 1 won!");
        location.reload();
    }
    if (health2 < 350 && health2 >199)
    {
        document.getElementById("myHealth2").style.backgroundColor = "orange";
    }
    else if(health2 <= 199)
    {
        document.getElementById("myHealth2").style.backgroundColor = "red";
        document.getElementById("myHealth2").style.animation= "flash linear 2s infinite";
    }

    var health1 = document.getElementById("myHealth").clientWidth;
    health1 = health1 - 5;
    document.getElementById("myHealth").style.width = health1 + "px";
    if( health1 > 0)
    {
    document.getElementById("myHealth").innerHTML = "<strong>" + health1 + "</strong>" + "<strong> HP </strong>";
    }
    else
    {
        document.getElementById("myHealth").innerHTML = "DEAD";
        document.getElementById("myHealth").style.marginLeft = "40%";
        document.getElementById("myHealth").style.backgroundColor = "white";
        alert("Player 2 won!");
        location.reload();
    }
    if (health1 < 350 && health1 >199)
    {
        document.getElementById("myHealth").style.backgroundColor = "orange";
    }
    else if(health1 <= 199)
    {
        document.getElementById("myHealth").style.backgroundColor = "red";
        document.getElementById("myHealth").style.animation= "flash linear 2s infinite";
    }
}
function heal(){
    var health1 = document.getElementById("myHealth").clientWidth;
    health1 = health1 + 50;

    if(health1 >= 500)
    {
        document.getElementById("myHealth").style.width = "500px";
        document.getElementById("myHealth").innerHTML = "<strong> 500 HP </strong>";
        document.getElementById("myHealth").style.backgroundColor = "green";
    }
    else{
        if(health1 >= 350){
            document.getElementById("myHealth").style.backgroundColor = "green";
        }
        else if(health1 < 350 && health1 > 199){
            document.getElementById("myHealth").style.backgroundColor = "orange";
        }
        else if(health1 <= 199){
            document.getElementById("myHealth").style.backgroundColor = "red";
            document.getElementById("myHealth").style.animation= "flash linear 2s infinite";
        }
        document.getElementById("myHealth").style.width = health1 + "px";
        document.getElementById("myHealth").innerHTML = "<strong>" + health1 + "</strong>" + "<strong> HP </strong>";
    }
}

function hit2(){
    var health1 = document.getElementById("myHealth").clientWidth;
    health1 = health1 - 100;
    document.getElementById("myHealth").style.width = health1 + "px";
    if( health1 > 0)
    {
    document.getElementById("myHealth").innerHTML = "<strong>" + health1 + "</strong>" + "<strong> HP </strong>";
    }
    else
    {
        document.getElementById("myHealth").innerHTML = "DEAD";
        document.getElementById("myHealth").style.marginLeft = "40%";
        document.getElementById("myHealth").style.backgroundColor = "white";
        alert("Player 2 won!");
        location.reload();
    }
    if (health1 < 350 && health1 >199)
    {
        document.getElementById("myHealth").style.backgroundColor = "orange";
    }
    else if(health1 <= 199)
    {
        document.getElementById("myHealth").style.backgroundColor = "red";
        document.getElementById("myHealth").style.animation= "flash linear 2s infinite";
    }

    var health2 = document.getElementById("myHealth2").clientWidth;
    health2 = health2 - 5;
    document.getElementById("myHealth2").style.width = health2 + "px";
    if( health2 > 0)
    {
    document.getElementById("myHealth2").innerHTML = "<strong>" + health2 + "</strong>" + "<strong> HP </strong>";
    }
    else
    {
        document.getElementById("myHealth2").innerHTML = "DEAD";
        document.getElementById("myHealth2").style.marginLeft = "40%";
        document.getElementById("myHealth2").style.backgroundColor = "white";
        alert("Player 1 won!");
        location.reload();
    }
    if (health2 < 350 && health2 >199)
    {
        document.getElementById("myHealth2").style.backgroundColor = "orange";
    }
    else if(health2 <= 199)
    {
        document.getElementById("myHealth2").style.backgroundColor = "red";
        document.getElementById("myHealth2").style.animation= "flash linear 2s infinite";
    }
}
function heal2(){
    var health2 = document.getElementById("myHealth2").clientWidth;
    health2 = health2 + 50;

    if(health2 >= 500)
    {
        document.getElementById("myHealth2").style.width = "500px";
        document.getElementById("myHealth2").innerHTML = "<strong> 500 HP </strong>";
        document.getElementById("myHealth2").style.backgroundColor = "green";
    }
    else{
        if(health2 >= 350){
            document.getElementById("myHealth2").style.backgroundColor = "green";
        }
        else if(health2 < 350 && health2 > 199){
            document.getElementById("myHealth2").style.backgroundColor = "orange";
        }
        else if(health2 <= 199){
            document.getElementById("myHealth2").style.backgroundColor = "red";
            document.getElementById("myHealth2").style.animation= "flash linear 2s infinite";
        }
        document.getElementById("myHealth2").style.width = health2 + "px";
        document.getElementById("myHealth2").innerHTML = "<strong>" + health2 + "</strong>" + "<strong> HP </strong>";
    }
}
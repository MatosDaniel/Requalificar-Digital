var counter = 0

function valueCounter(value) {
    document.getElementById("counter").innerHTML = value;
}

function adicionar() {

    alert("deu");
    valueCounter(++counter);
}

function remover() {
    valueCounter(--counter);
}

function reset() {
    counter = 0;
    valueCounter(counter);
}
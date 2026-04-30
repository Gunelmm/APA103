let sumBtn = document.querySelector(".plus_btn");
let subBtn = document.querySelector(".minus_btn");
let multBtn = document.querySelector(".mult_btn");
let divideBtn = document.querySelector(".divide_btn");
let resetBtn = document.querySelector(".reset_btn");

let result = document.querySelector(".result");

let inputOne = document.querySelector(".inputOne");
let inputTwo = document.querySelector(".inputTwo");

function ResetInput() {
    CheckInputValue();
    inputOne.value = "";
    inputTwo.value = "";
}

function CheckInputValue() {
    if (inputOne.value == "" || inputTwo.value == "") {
        alert("Please enter number");
        return false;
    }
    return true;
}

function ResetResult() {
    result.textContent = 0;
}

resetBtn.addEventListener("click", ResetResult);

let Sum = () => {
    if (!CheckInputValue()) return;

    result.textContent = Number(inputOne.value) + Number(inputTwo.value);

    ResetInput();
};

sumBtn.addEventListener("click", Sum);

let Sub = () => {
    if (!CheckInputValue()) return;

    result.textContent = Number(inputOne.value) - Number(inputTwo.value);

    ResetInput();
};

subBtn.addEventListener("click", Sub);

let Mult = () => {
    if (!CheckInputValue()) return;

    result.textContent = Number(inputOne.value) * Number(inputTwo.value);

    ResetInput();
};

multBtn.addEventListener("click", Mult);

let Divide = () => {
    if (!CheckInputValue()) return;

    if (inputTwo.value == 0)
    {
        alert("You can't divide by zero!");
        return;
    }

    result.textContent = (Number(inputOne.value) / Number(inputTwo.value)).toFixed(2);

    ResetInput();
};

divideBtn.addEventListener("click", Divide);
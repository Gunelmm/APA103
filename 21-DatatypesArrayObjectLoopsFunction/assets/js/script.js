// task1
let arr = [1, 4, 7, 7, 23, 77, 77, 77];

let newArr = [], counts = {};

for (i = 0; i < arr.length; i++)
{
   if(!counts[arr[i]]) 
    {
        counts[arr[i]] = 1;
        newArr.push(arr[i]);
    }
   else counts[arr[i]]++;
}

console.log(counts);
console.log(newArr);

// task2
let word = "mom";

let reversedWord = word.split("").reverse().join("");

if (word === reversedWord) console.log("This word is polindrom.");
else console.log("This word in not polindrom.");

// task3
let numbers = [1, 5, 7, 27, 77, 83], num = 25, count = 0;

for (i = 0; i < numbers.length; i++)
{
    if(num < numbers[i]) count++;
}

console.log(count);

// task4
let number = 13, sum = 0;

for (i = 0; i < number; i++)
{
    if (number % i ==0) sum+=i;
}
if (sum > number) console.log("Aboundant");
else console.log("Deficient");

// task5
let numArray = [1, 2, 3, 4, 5];

function squareArray(numArray)
{
    let squareArr = [];
    for (i = 0; i < numArray.length; i++)
    {
        squareArr.push(numArray[i]*numArray[i]);
    }
    console.log(squareArr);
}

squareArray(numArray);
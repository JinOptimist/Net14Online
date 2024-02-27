// outdate way to craete variable
// var test = 1;

let age = 12; // number
const coin = 1.1; // number

const nameIvan = "Ivan"; // string
let nameOlga = 'Olga'; // string

let isAdult = true;

let user1 = {
    name: 'Lera'
};

const user2 = {
    name: 'Lera',
    age: 20
};

let user3 = {
    age: 13
};

user2.age = 30;
user3.age = 15;

//user = 1;
//user = 'smile';
//user = true;

function SayHi() {
    console.log('hi');
}

function Summ(a, b) {
    return a + b;
}

Summ(1);
Summ(1, 2);
Summ(1, 2, 3);

let sayMyName = 'test';
sayMyName = function (user) {
    console.log(user.name);
}

sayMyName(user1);

let helper = {
    do1: Summ,
    do2: function () {
        console.log(42);
    }
};

helper.do3 = sayMyName;
helper.do1(1, 2);
helper.do3(user3);

user1.isMale = true;

if (user1.isMale) {

}

if (user1) {
    console.log(user1.name);
}

let urls = [1, 2, 3, 4];

for (let i = 0; i < urls.length; i++) {
    console.log(urls[i]);
}

if (false) {
    helper.qweqweqwe();
}

DoVerstion2(); // document.name

function DoVerstion2() {
    this.name;

    function innerFunction() {
        this.name;// DoVerstion2.name
    }

    innerFunction();
}

const userCanDo = {
    name: 'Ivan',
    Do: DoVerstion2
}

userCanDo.Do(); // userCanDo.name

const createAndAppendElement = (data = {}, element='', className = '', parentId = '') => {
  let div = document.createElement(element);
  div.append(data.value);
  div.setAttribute('class', className);
  div.setAttribute('id', data.id);
  let divNumbers = document.getElementById(parentId);
  divNumbers.appendChild(div);
}

const changeTextOnElement = (data = {}, id = '') => {
  let div = document.getElementById(id);
  div.innerText = data.value;
}

const toArray = (obj) => {
  var array = [];
  for (var i = 0; i < obj.length; i++) {
    array[i] = { id: obj[i].id, value: obj[i].innerText };
  }
  return array;
}

const postData = async (url = '', data = {}) => {

  const response = await fetch(url, {
    method: 'POST',
    mode: 'cors',
    cache: 'no-cache',
    credentials: 'same-origin',
    headers: {
      'Content-Type': 'application/json'
    },
    redirect: 'follow',
    referrerPolicy: 'no-referrer',
    body: JSON.stringify(data)
  });
  return response.json();
}
const getData = async (url = '') => {
  const response = await fetch(url, {
    method: 'GET',
    mode: 'cors',
    cache: 'no-cache',
    credentials: 'same-origin',
    headers: {
      'Content-Type': 'application/json'
    },
    redirect: 'follow',
    referrerPolicy: 'no-referrer',
  });
  return response.json();
}

const addNumber = () => {
  let numbers = document.getElementsByClassName("number");
  getData("http://localhost:8000/Home/Add")
    .then(data => {
      console.log(data);
      createAndAppendElement(data, "div", "number col-2 border border-primary", 'numbers');
      changeTextOnElement({ value: numbers.length }, "count")
    })
    .catch(err => console.log(err));
}

const sumNumbers = () => {
  let message = document.getElementById("message");
  let numbers = document.getElementsByClassName("number");
  let arr = toArray(numbers);
  postData("http://localhost:8000/Home/Sum", arr)
    .then(data => {
      console.log(data);
      message.innerText = data;
    })
    .catch(err => console.log(err));

}




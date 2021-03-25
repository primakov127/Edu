const EMPTY_STRING = "";

function renderDropdownList(event) {
  let inputName = event.target.value.toUpperCase();
  let dropdownList = document.getElementById("dropdown-list");
  let template = document.getElementById("dropdown-list-item");

  dropdownList.innerHTML = EMPTY_STRING;
  if (inputName.length === 0) {
    return;
  }

  fetch("data.json")
    .then((result) => result.json())
    .then((data) => {
      data
        .filter((item) => item.name.toUpperCase().includes(inputName))
        .forEach((item) => {
          let clone = template.content.cloneNode(true).firstElementChild;

          clone.setAttribute("id", item.id);
          clone.setAttribute("name", item.name);
          clone.addEventListener("click", () => selectDropdownListItem(item.name));
          clone.querySelector(".dropdown-list__image").setAttribute("src", item.image_url);
          clone.querySelector(".dropdown-list__name").innerText = item.name;
          clone.querySelector(".dropdown-list__screen-name").innerText = `@${item.screen_name}`;

          dropdownList.appendChild(clone);
        });
    });
}

function selectDropdownListItem(name) {
  let input = document.getElementById("text-field");

  input.value = name;
  document.getElementById("dropdown-list").innerHTML = EMPTY_STRING;
}

function addToChannelList() {
  let channelList = document.getElementById("channel-list");
  let input = document.getElementById("text-field");
  let template = document.getElementById("channel-list-item");
  let name = input.value;

  if (name === EMPTY_STRING) {
    return;
  }

  fetch("data.json")
    .then((result) => result.json())
    .then((data) => {
      let item = data.find((item) => item.name === name);
      let clone = template.content.cloneNode(true).firstElementChild;

      clone.setAttribute("id", item.id);
      clone.setAttribute("name", item.name);
      clone.addEventListener("click", (event) => {goToChannelPage(event, item.id);});
      clone.querySelector("h2").innerText = item.name;
      clone.querySelector("button").addEventListener("click", () => {removeChannel(item.id);});
      clone.querySelector(".channel-list__footer").children[0].innerText = item.description;
      clone.querySelector(".channel-list__footer").children[1].innerText = item.followers_count;

      channelList.appendChild(clone);
    });

    input.value = EMPTY_STRING;
}

function goToChannelPage(event, id) {
  if (event.target.tagName === "BUTTON") {
    return;
  }

  changeUrl(id);
}

function changeUrl(id) {
  let params = new URLSearchParams();

  params.set("id", id);
  window.location.href = `channel.html?${params.toString()}`;
}

function removeChannel(id) {
  let items = document.getElementById("channel-list").children;

  for (let i = 0; i < items.length; i++) {
    let item = items[i];

    if (item.getAttribute("id") != id) {
      continue;
    }

    item.remove();
  }
}

document
  .getElementById("text-field")
  .addEventListener("input", renderDropdownList);

document
  .getElementById("add-button")
  .addEventListener("click", addToChannelList);
  
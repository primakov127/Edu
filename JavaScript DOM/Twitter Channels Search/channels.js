import { getChannelByName, getChannelsIncludesName } from "./dataService.js";
import { renderTweetsPage } from "./index.js";

const EMPTY_STRING = "";

function renderDropdownList(value) {
  const inputName = value.toUpperCase();
  const dropdownList = document.getElementById("dropdown-list");
  const template = document.getElementById("dropdown-list-item");

  dropdownList.innerHTML = EMPTY_STRING;
  if (inputName.length === 0) {
    return;
  }

  getChannelsIncludesName(inputName).then((channels) => {
    channels.forEach((channel) => {
      const clone = template.content.cloneNode(true).firstElementChild;

      clone.setAttribute("id", channel.id);
      clone.setAttribute("name", channel.name);
      clone.addEventListener("click", () => selectDropdownListItem(channel.name));
      clone.querySelector(".dropdown-list__image").setAttribute("src", channel.image_url);
      clone.querySelector(".dropdown-list__name").innerText = channel.name;
      clone.querySelector(".dropdown-list__screen-name").innerText = `@${channel.screen_name}`;

      dropdownList.appendChild(clone);
    });
  });
}

function selectDropdownListItem(name) {
  const input = document.getElementById("text-field");

  input.value = name;
  document.getElementById("dropdown-list").innerHTML = EMPTY_STRING;
}

function addToChannelList() {
  const channelList = document.getElementById("channel-list");
  const input = document.getElementById("text-field");
  const template = document.getElementById("channel-list-item");
  const name = input.value;

  if (name === EMPTY_STRING) {
    return;
  }

  getChannelByName(name).then((channel) => {
    const clone = template.content.cloneNode(true).firstElementChild;

    clone.setAttribute("id", channel.id);
    clone.setAttribute("name", channel.name);
    clone.addEventListener("click", (event) => {
      goToTweetsPage(event, channel.id);
    });
    clone.querySelector("h2").innerText = channel.name;
    clone.querySelector("button").addEventListener("click", () => {
      removeChannel(channel.id);
    });
    clone.querySelector(".channel-list__footer").children[0].innerText = channel.description;
    clone.querySelector(".channel-list__footer").children[1].innerText = channel.followers_count;

    channelList.appendChild(clone);
  });

  input.value = EMPTY_STRING;
}

function goToTweetsPage(event, id) {
  if (event.target.tagName === "BUTTON") {
    return;
  }

  renderTweetsPage(id);
}

function removeChannel(id) {
  const items = document.getElementById("channel-list").children;

  for (let i = 0; i < items.length; i++) {
    const item = items[i];

    if (item.getAttribute("id") != id) {
      continue;
    }

    item.remove();
  }
}

document
  .getElementById("text-field")
  .addEventListener("input", (event) => renderDropdownList(event.target.value));

document.getElementById("add-button").addEventListener("click", addToChannelList);

import { getChannelById } from "./dataService.js";

const EMPTY_STRING = "";
const main = document.querySelector(".main");

function renderChannelsPage() {
  const channelsPageTemplate = document.getElementById("channelsPage");
  const channelsPage = channelsPageTemplate.content.cloneNode(true);

  renderPageHead("channels", "Twitter Channels Search");
  renderPageTitle("Twitter Channels");

  clearMain();
  main.append(channelsPage);
}

export function renderTweetsPage(channelId) {
  const tweetsPageTemplate = document.getElementById("tweetsPage");
  const tweetsPage = tweetsPageTemplate.content.cloneNode(true);

  getChannelById(channelId).then((channel) => {
    renderPageHead("tweets", channel.name);
    renderPageTitle(`${channel.name} Channel`);
  });

  clearMain();
  main.append(tweetsPage);
}

function renderPageHead(pageName, title) {
  const headTemplate = document.getElementById("head");
  const head = headTemplate.content.cloneNode(true);

  head.querySelector("link").setAttribute("href", `${pageName}.css`);
  head.querySelector("title").innerText = title;
  head.querySelector("script").setAttribute("src", `${pageName}.js`);

  document.head.innerHTML = null;
  document.head.append(head);
}

function renderPageTitle(title) {
  document.querySelector(".title").innerText = title;
}

// Clear main container before the page updating
function clearMain() {
    main.innerHTML = EMPTY_STRING;
}

renderChannelsPage();

import { getChannelByName } from "./dataService.js";

function renderTweetsList() {
  const channelName = document.title;
  const tweetList = document.getElementById("tweet-list");
  const template = document.getElementById("card");

  getChannelByName(channelName).then((channel) => {
    channel.tweets.forEach((tweet) => {
      const clone = template.content.cloneNode(true).firstElementChild;

      clone.querySelector(".twit-card__img").setAttribute("src", channel.image_url);
      clone.querySelector(".twit-card__desc").innerText = tweet.text;
      clone
        .querySelector(".twit-card__attach")
        .setAttribute("src", "https://pbs.twimg.com/media/ExKW-ZZVcAEtdIP?format=jpg&name=small");

      tweetList.appendChild(clone);
    });
  });
}

renderTweetsList();

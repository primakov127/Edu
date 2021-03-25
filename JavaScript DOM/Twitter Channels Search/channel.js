function loadTweets() {
  let id = getUrlParam("id");
  let tweetList = document.getElementById("tweet-list");
  let template = document.getElementById("card");

  fetch("data.json")
    .then((result) => result.json())
    .then((data) => {
      let channel = data.find((item) => item.id == id);

      channel.tweets.forEach((tweet) => {
        let clone = template.content.cloneNode(true).firstElementChild;

        clone.querySelector(".twit-card__img").setAttribute("src", channel.image_url);
        clone.querySelector(".twit-card__desc").innerText = tweet.text;
        clone.querySelector(".twit-card__attach").setAttribute("src","https://pbs.twimg.com/media/ExKW-ZZVcAEtdIP?format=jpg&name=small");

        tweetList.appendChild(clone);
      });
    });
}

function getUrlParam(key) {
  let params = new URLSearchParams(window.location.search);
  let value = params.get(key);

  return value;
}

loadTweets();

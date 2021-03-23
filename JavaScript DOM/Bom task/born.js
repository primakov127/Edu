function printWindowSize() {
  console.log(window.innerHeight, window.innerWidth);
}

function printEnvInfo() {
  for (let propName in window.navigator) {
    let propValue = window.navigator[propName];
    if (propValue?.constructor === String) {
      console.log(propName, propValue);
    }
  }
}

function getSearch(href) {
  let signIndex = href.indexOf("?") === -1 ? href.indexOf("#") : href.indexOf("?");
  if (signIndex === -1) {
    return "";
  }
  let search = href.substr(signIndex + 1, href.length);
  return search;
}

function setUrl(name, value, sign) {
  let search = getSearch(window.location.href);
  let queryParams = new URLSearchParams(search);
  queryParams.set(name, value);
  history.replaceState(null, null, sign + queryParams.toString());
}

function setUrlParameters(name, value) {
  setUrl(name, value, "?");
}

function setUrlHashParameter(name, value) {
  setUrl(name, value, "#");
}
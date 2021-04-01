function printWindowSize() {
  console.log(window.innerHeight, window.innerWidth);
}

function printEnvInfo() {
  for (let propName in window.navigator) {
    const propValue = window.navigator[propName];
    if (typeof propValue === "string") {
      console.log(propName, propValue);
    }
  }
}

function setSearchParameters(name, value) {
  const searchParams = new URLSearchParams(window.location.search);
  searchParams.set(name, value);
  window.location.search = searchParams;
}

function setHashParameters(name, value) {
  const hashParams = new URLSearchParams(window.location.hash.replace("#", "?"));
  hashParams.set(name, value);
  history.replaceState(null, null, `#${hashParams}`);
}

window.addEventListener("resize", printWindowSize);
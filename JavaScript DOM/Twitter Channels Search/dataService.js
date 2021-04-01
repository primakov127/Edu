export async function getAllChannels() {
  const channels = await fetch("data.json").then((data) => data.json());

  return channels;
}

export async function getChannelById(id) {
  const channel = await getAllChannels().then((channels) => channels.find((item) => item.id == id));

  return channel;
}

export async function getChannelByName(name) {
  const channel = await getAllChannels().then((channels) =>
    channels.find((item) => item.name === name)
  );

  return channel;
}

export async function getChannelsIncludesName(name) {
  const upperCaseName = name.toUpperCase();
  const channels = await getAllChannels().then((channels) =>
    channels.filter((item) => item.name.toUpperCase().includes(upperCaseName))
  );

  return channels;
}

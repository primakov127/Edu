import React, { useState, useEffect } from "react";

const fullTimeToSeconds = (fullTime) => {
  const { hours, minutes, seconds } = fullTime;
  return (hours || 0) * 60 * 60 + (minutes || 0) * 60 + (seconds || 0);
};

const secondsToFullTime = (seconds) => {
  const h = Math.floor(seconds / 3600);
  const m = Math.floor((seconds % 3600) / 60);
  const s = Math.floor((seconds % 3600) % 60);
  const fullDate = { hours: h, minutes: m, seconds: s };

  return fullDate;
};

const Timer = (props) => {
  const { settings, onComplete, children } = props;
  const seconds = fullTimeToSeconds(settings);
  const [time, setTime] = useState(seconds);

  useEffect(() => {
    if (time === 0) {
      return null;
    }

    const timer = setTimeout(() => {
      setTime((prevState) => prevState - 1);
    }, 1000);

    return () => clearTimeout(timer);
  });

  useEffect(() => {
    if (time === 0) {
      onComplete();
    }
  });

  const fullTime = secondsToFullTime(time);
  return children(fullTime.hours, fullTime.minutes, fullTime.seconds);
};

export default Timer;

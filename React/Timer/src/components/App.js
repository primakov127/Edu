import React from "react";
import Timer from "./Timer";

const settings = {
  seconds: 5,
};

const onTimerCompleted = () => {
  alert("Timer is completed");
};

const App = () => {
  return (
    <Timer settings={settings} onComplete={onTimerCompleted}>
      {(hours, minutes, seconds) => <span>{seconds}</span>}
    </Timer>
  );
};

export default App;

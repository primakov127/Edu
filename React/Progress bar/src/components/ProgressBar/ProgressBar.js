import React, { useEffect, useState } from "react";
import "./ProgressBar.css";

const ProgressBar = (props) => {
  const value = props.value >= 100 ? 100 : props.value;
  const [displayValue, setDisplayValue] = useState(value);

  const fillerStyles = {
    width: `${displayValue}%`,
  };

  useEffect(() => {
    const timer = setTimeout(() => {
      setDisplayValue((prev) => (prev < value ? prev + 1 : prev));
    }, 50);

    return () => clearTimeout(timer);
  });

  return (
    <div className="container">
      <div className="filler" style={fillerStyles}>
        <span className="label">{`${displayValue}%`}</span>
      </div>
    </div>
  );
};

export default ProgressBar;

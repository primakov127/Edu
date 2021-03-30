import React, { useState } from "react";

const ENTER_KEY = "Enter";

const ImmediateInput = (props) => {
  const { placeholder, onSearch } = props;

  const handleChange = (e) => {
    onSearch(e.target.value);
  };

  return <input placeholder={placeholder} onChange={handleChange} />;
};

const EnterPressedInput = (props) => {
  const { placeholder, onSearch } = props;

  const handlePressedKey = (e) => {
    if (e.key === ENTER_KEY) {
      onSearch(e.target.value);
    }
  };

  return <input placeholder={placeholder} onKeyDown={handlePressedKey} />;
};

const StoppedTypingInput = (props) => {
  const { placeholder, onSearch } = props;
  const [typingTimeout, setTypingTimeout] = useState(0);

  const handleChange = (e) => {
    if (typingTimeout) {
      clearTimeout(typingTimeout);
    }

    setTypingTimeout(setTimeout(() => onSearch(e.target.value), 1000));
  };

  return <input placeholder={placeholder} onChange={handleChange} />;
};

const SearchInput = (props) => {
  const { mode } = props;

  return mode === SearchInputModes.Immediate
    ? ImmediateInput(props)
    : mode === SearchInputModes.EnterPressed
    ? EnterPressedInput(props)
    : mode === SearchInputModes.StoppedTyping
    ? StoppedTypingInput(props)
    : null;
};

export const SearchInputModes = {
  Immediate: 0,
  EnterPressed: 1,
  StoppedTyping: 2,
};

export default SearchInput;

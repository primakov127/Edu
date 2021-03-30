import React from "react";
import SearchInput, { SearchInputModes } from "./SearchInput";

const App = () => {
  return (
    <SearchInput
      placeholder="Search"
      mode={SearchInputModes.EnterPressed}
      onSearch={(value) => console.log(`Search ${value}`)}
    ></SearchInput>
  );
};

export default App;

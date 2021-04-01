import React from "react";
import SearchInput, { SearchInputModes } from "./SearchInput";

const App = () => {
  return (
    <SearchInput
      placeholder="Search"
      mode={SearchInputModes.Immediate}
      onSearch={(value) => console.log(`Search ${value}`)}
    />
  );
};

export default App;

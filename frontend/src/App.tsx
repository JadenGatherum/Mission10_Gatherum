import React from "react";
import "./App.css";
import Header from "./header";
import BowlersList from "./Bowling/BowlingList";

function App() {
  return (
    <div className="App">
      <Header title="Here is a bunch of information on some bowlers" />
      <BowlersList />
    </div>
  );
}

export default App;

import React from "react";
import Layout from "./Modules/Layout/Layout";
import Products from "./Pages/Products/Products";
import { Route, Routes } from "react-router-dom";
import './App.css';

function App() {
  return (
    <div className="App">
      <Layout>
        <Routes>
          <Route path="/*" element={<Products/>}/>  
        </Routes>
        </Layout>
    </div>
  );
};

export default App;
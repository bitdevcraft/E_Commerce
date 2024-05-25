import React from "react";
import ReactDOM from "react-dom/client";
import "./index.css";

import { RouterProvider } from "react-router-dom";
import { router } from "./app/router/Routes.tsx";

import { StoreContext, store } from "./app/store/store.ts";

import { NextUIProvider } from "@nextui-org/react";

ReactDOM.createRoot(document.getElementById("root")!).render(
  <React.StrictMode>
    <StoreContext.Provider value={store}>
      <NextUIProvider>
        <RouterProvider router={router} />
      </NextUIProvider>
    </StoreContext.Provider>
  </React.StrictMode>
);

import { configureStore } from "@reduxjs/toolkit";
import ventasReducer from "./features/ventas-slice";

export const store = configureStore({
  reducer: {
    ventasReducer
  }
})

export type RootState = ReturnType<typeof store.getState>
export type AppDispatch = typeof store.dispatch
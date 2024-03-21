import { createSlice } from "@reduxjs/toolkit";
import { initialStateVentas } from "../initial-state";

const ventasSlice = createSlice({
  name: "ventas",
  initialState: initialStateVentas,

  reducers: {
    setSearchQuery: (state, action) => {
      state.query = action.payload;
    },
    setVentas: (state, action) => {
      state.ventas = action.payload;
    },
    setTransactions: (state, action) => {
      state.transactions = action.payload;
    },
    setLoading: (state, action) => {
      state.loading = action.payload;
    },
    setError: (state, action) => {
      state.error = action.payload;
    },
  },
});

export const {
  setSearchQuery,
  setVentas,
  setTransactions,
  setLoading,
  setError,
} = ventasSlice.actions;

export default ventasSlice.reducer;

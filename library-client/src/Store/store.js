import { configureStore } from "@reduxjs/toolkit";
import bookReducer from "./bookSlice";
import authorReducer from "./authorSlice";

export const store = configureStore({
    reducer: {
        books: bookReducer,
        authors: authorReducer,
    },
});

import { createSlice, createAsyncThunk } from "@reduxjs/toolkit";

export const fetchBooks = createAsyncThunk("books/fetchBooks", async ({pageNumber, pageSize}) => {
    const response = await fetch(`http://localhost:5144/books?pageNumber=${pageNumber}&pageSize=${pageSize}`, {
        method: "GET", mode: "cors", headers: {
            "Content-Type": "application/json", "Access-Control-Allow-Origin": "*",
        }
    });
    if (!response.ok) {
        throw new Error("Failed to fetch books");
    }
    return await response.json();
});

const bookSlice = createSlice({
    name: "books",
    initialState: {
        books: [],
        status: "idle", // 'idle' | 'loading' | 'succeeded' | 'failed'
        error: null,
    },
    reducers: {}, // No manual reducers, since we're using async fetch
    extraReducers: (builder) => {
        builder
            .addCase(fetchBooks.pending, (state) => {
                state.status = "loading";
            })
            .addCase(fetchBooks.fulfilled, (state, action) => {
                state.status = "succeeded";
                state.books = action.payload;
            })
            .addCase(fetchBooks.rejected, (state, action) => {
                state.status = "failed";
                state.error = action.error.message;
            });
    },
});

export default bookSlice.reducer;

import {createSlice, createAsyncThunk} from "@reduxjs/toolkit";

export const fetchAuthors = createAsyncThunk("authors", async () => {
    const response = await fetch("http://localhost:5144/authors", {
        method: "GET", mode: "cors", headers: {
            "Content-Type": "application/json", "Access-Control-Allow-Origin": "*",
        }
    });
    return await response.json();
});

const authorSlice = createSlice({
    name: "authors", initialState: {
        authors: [], status: "idle", // 'idle' | 'loading' | 'succeeded' | 'failed'
        error: null,
    }, reducers: {}, extraReducers: (builder) => {
        builder
            .addCase(fetchAuthors.pending, (state) => {
                state.status = "loading";
            })
            .addCase(fetchAuthors.fulfilled, (state, action) => {
                state.status = "succeeded";
                state.authors = action.payload;
            })
            .addCase(fetchAuthors.rejected, (state, action) => {
                state.status = "failed";
                state.error = action.error.message;
            });
    },
})

export default authorSlice.reducer;

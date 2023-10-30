import { createSlice, createAsyncThunk } from "@reduxjs/toolkit";


const initialState = {
    phoneRaws: [],
    status: "idle",
    errors: null,
};

const PhoneBookSlice= createSlice({
    name: 'phonebook',
    initialState: initialState,
    reducers: {},
    extraReducers() {
        
    },
    
});


export default PhoneBookSlice.reducer;
import { createSlice } from '@reduxjs/toolkit';
import type { PayloadAction } from '@reduxjs/toolkit';
import { CartItem } from '../types';

export interface CartState {
  items: CartItem[];
  visible: boolean;
};

const initialState: CartState = {
    items: [],
    visible: false,
};

export const cartSlice = createSlice({
  name: 'cart',
  initialState,
  reducers: {
    add: (state, action: PayloadAction<any>) => {
        let temp = state.items;
        let itemFound = temp.find( item => item.product.productId == action.payload.product.productId);
        if(itemFound!=undefined){
          let i = temp.indexOf(itemFound);
          state.items[i].quantity += action.payload.quantity;
        }
        else {
          temp.push(action.payload);
          state.items = temp;
        };    
    },
    remove: (state, action: PayloadAction<any>) => {
        let temp = state.items;
        let itemFound = temp.find( item => item.product.productId == action.payload.product.productId);
        if(itemFound!=undefined){
          let id = itemFound.product.productId;
          state.items = temp.filter(item=>item.product.productId!=id);
        };
    },
    change: (state, action: PayloadAction<any>) => {
        let temp = state.items;
        let itemFound = temp.find( item => item.product.productId == action.payload.product.productId);
        if(itemFound!=undefined && action.payload.quantity>0){
          let i = temp.indexOf(itemFound);
          state.items[i].quantity = action.payload.quantity;
        }
        else if(itemFound!=undefined && action.payload.quantity==0){
          let id = itemFound.product.productId;
          state.items = temp.filter(item=>item.product.productId!=id);
        };
    },
    toggle: (state) => {
        state.visible = !state.visible;    
    },
    reset: (state) => {
        state.items = [];    
    },
  },
});

// Action creators are generated for each case reducer function
export const { add, remove, change, toggle, reset } = cartSlice.actions;
export default cartSlice.reducer;
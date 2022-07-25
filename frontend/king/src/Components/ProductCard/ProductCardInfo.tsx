import React from 'react';
import shoppingCart from '../../images/cart.png';
import { useAppDispatch } from '../../redux/hooks';
import { add } from '../../redux/cart';
import { Product } from '../../types';
import './ProductCardInfo.css';
import { Link } from 'react-router-dom';

const ProductCardInfo = ({product}:{product: Product}) => {
    
    const dispatch = useAppDispatch();

    return(
        <div className="card-info">
            <h1 id="card-title">{(product.title.length)>20?product.title.substring(0,20)+' ...':product.title}</h1>
            <h2 id="card-price"> {product.price}<span id="card-currency">HRK</span></h2>
            <button id="card-buy-button" onClick={()=>dispatch(add({product: product, quantity: 1}))}>Add to Cart</button>
            <button id="card-buy-button-no-text" onClick={()=>dispatch(add({product: product, quantity: 1}))}> 
                <img src={shoppingCart} alt="shoppingCart"/>
            </button>
        </div>
    );
};

export default ProductCardInfo;
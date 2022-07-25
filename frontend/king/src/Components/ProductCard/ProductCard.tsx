import React from 'react';
import ProductCardInfo from './ProductCardInfo';
import { Product } from '../../types';
import './ProductCard.css';
import { Link } from 'react-router-dom';
import productAvatar from '../../images/product.jpeg';
import tableBL from '../../images/tableBL.png';

const ProductCard = ({product}: {product:Product}) => {

    return(
        <div className="card">
            <Link to={`/`} className="card-cover">
                <div className="card-cover">
                    <img src={productAvatar} alt="Cover." />
                </div>
            </Link>
            <div className="card-info-container">
                <button id="card-brush-button">                    
                    <img src={tableBL} alt="table"/>
                </button>
                <ProductCardInfo product={product}/>
            </div>
        </div>
    );
};

export default ProductCard;
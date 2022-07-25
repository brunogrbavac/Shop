import React from 'react';
import clsx from 'clsx';
import ProductCard from '../../Components/ProductCard/ProductCard';
import { Product } from '../../types';
import './ProductsGrid.css';


const ProductsGrid = ({workshopsArray, landingPage }:{workshopsArray: Product[], landingPage: boolean}) => {

    return(
        <div className = {clsx((landingPage)?"grid-landing":"grid-article","products-grid")}>
            {workshopsArray.map( (item: Product) => <ProductCard product={item}/>)}
        </div>
    );
};

export default ProductsGrid;
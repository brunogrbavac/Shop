import React from 'react';
import clsx from 'clsx';
import ProductCard from '../../Components/ProductCard/ProductCard';
import { Product } from '../../types';
import './ProductsGrid.css';


const ProductsGrid = ({productsArray, landingPage }:{productsArray: Product[], landingPage: boolean}) => {

    return(
        <div className = {clsx((landingPage)?"grid-landing":"grid-article","products-grid")}>
            {productsArray.map( (item: Product) => <ProductCard product={item}/>)}
        </div>
    );
};

export default ProductsGrid;
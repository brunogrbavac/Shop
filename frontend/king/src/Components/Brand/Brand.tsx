import React from 'react';
import clsx from 'clsx';
import table from '../../images/table.png';
import { Brand } from '../../types';

import './Brand.css';


const Category = ({brand, filter, setFilter}:{brand: Brand, filter: string, setFilter: any}) => {
    return(
        <p className={clsx("workshops-filter-option", (filter==brand)&&'wfo-blue')} onClick={()=>{setFilter(brand);}}>
            <img src={table} alt="icon" className="option-icon"/>
            {brand.name}
        </p>
    ); 
};

export default Category;
import React from 'react';
import clsx from 'clsx';
import table from '../../images/table.png';

import './Brand.css';


const Category = ({brand, filter, setFilter}:{brand: string, filter: string, setFilter: any}) => {
    return(
        <p className={clsx("workshops-filter-option", (filter==brand)&&'wfo-blue')} onClick={()=>{setFilter(brand);}}>
            <img src={table} alt="icon" className="option-icon"/>
            {brand}
        </p>
    ); 
};

export default Category;
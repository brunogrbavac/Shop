import React, { useEffect, useState } from 'react';
import clsx from 'clsx';
import { Product, productDefault } from '../../types';
import Brand from '../../Components/Brand/Brand';
import ProductsGrid from '../../Modules/ProductsGrid/ProductsGrid';
import { fetchData } from '../../fetch';
import ReactLoading from 'react-loading';
import up from '../../images/up.png';
import down from '../../images/down.png';
import './products.css';

const Products = () => {

    const WS_PER_PAGE = 9;
    const [page, setPage] = useState<number>(()=>1);
    const [loading, setLoading] = useState<boolean>(()=>true);
    const [filter, setFilter] = useState<string>(()=>"All");
    const [openBrands, setOpenBrands] = useState<boolean>(()=>true);
    const [productsFetched, setproductsFetched] = useState<Product[]>(()=>[productDefault]);
    const [brandsFetched, setBrandsFetched] = useState<string[]>(()=>[" "]);

    const fetchproducts = async() => {
        let data = await fetchData(`https://localhost:44330/api/Product`);
        setproductsFetched(data);
        setLoading(false);
    };

    const fetchBrands = async() => {
        let data = await fetchData(`https://localhost:44330/api/Brand`);
        setBrandsFetched(data);
    };

    useEffect(() => { 
        fetchproducts();
    }, [page, filter]);

    useEffect(() => { 
        fetchBrands();
    }, []);

    return(
        <div className='products'>
            
            <div className={clsx("products-sidebar", !openBrands&&'closed-sidebar', !openBrands&&'display-none-md')}>
                <p className='products-filter-text'>Filter by brand:</p>
                <Brand brand="All" filter={filter} setFilter={(i:string)=>{setFilter(i); setPage(1); setOpenBrands(false);}} />
                {brandsFetched.map( item => 
                    <Brand brand={item[0].toUpperCase()+item.substring(1,item.length)} filter={filter} setFilter={(i:string)=>{setFilter(i); setPage(1); setOpenBrands(false);}} />
                )}
            </div>

            <div className={clsx("products-sidebar", !openBrands&&'closed-sidebar','display-none', openBrands&&'display-none-md')}>
                <img src={openBrands?up:down} alt="Icon" className="fold-icon" onClick={()=>setOpenBrands(true)}/>
                <p className={clsx("products-filter-sel-option",'wfo-blue')} onClick={()=>{setOpenBrands(true);}}>
                    {filter}
                </p>
            </div>

            <div className="products-right">
                <h1 className="products-title">products</h1>
                <p className="products-number">Displayed: <span>{productsFetched.length}</span></p>
                {loading?
                    <ReactLoading type="bubbles" color="sky-blue" className="loading"/>:
                    <><ProductsGrid productsArray={productsFetched} landingPage={true}/>
                    {(productsFetched.length<9)?
                        null
                        :(page==1)?
                            <p className="products-load-more" onClick={()=>setPage(2)}>Load more</p>
                            :<p className="products-load-more" onClick={()=>setPage(1)}>Show less</p>
                    }</>
                }
            </div>
        </div>
    );
};

export default Products;
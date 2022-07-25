export type Product = {
    productId: number,
    name: string,
    description: string,
    price: number,
    brandId: number,
    brandName: string,
};

export type Brand = {
    name: string,
};

export type CartItem = {
    product: Product,
    quantity: number,
};

export const productDefault: Product = {
    id: 0,
    title: "",
    desc: "",
    price: 0,
    date: "",
    category: "",
    userId: 0,
    imageUrl: "",
};

export const cartItemDefault = {
    product: productDefault,
    quantity: 0,
};
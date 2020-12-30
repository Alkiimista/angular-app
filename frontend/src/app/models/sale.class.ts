export class Sale {
    product: string;
    price: number;
    quantity: number;
    date: string;

    constructor(product: string, price: string, quantity: string, date: string){
        this.product = product;
        this.price = parseInt(price, 10);
        this.quantity = parseInt(quantity, 10);
        this.date = date;
    }
}
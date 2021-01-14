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

export function mapSales(item: any): Sale{
    return new Sale(
        item.Product,
        item.Price,
        item.Quantity,
        item.Date,
    );
}
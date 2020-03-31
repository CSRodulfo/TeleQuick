export class InvoiceDetail {
  // Note: Using only optional constructor properties without backing store disables typescript's type checking for the type
  constructor(id?: number, date?: Date, quantity?: number, total?: number, category?: number,
    vehicleRegistration?: string, tollStation?: string, concessionaryName?: string) {

    this.id = id;
    this.date = date;
    this.quantity = quantity;
    this.tollStation = tollStation
    this.category = category;
    this.total = total;
    this.vehicleRegistration = vehicleRegistration;
    this.concessionaryName = concessionaryName;
  }

  public id: number;
  public date: Date;
  public quantity: number;
  public tollStation: string;
  public category: number;
  public total: number;
  public vehicleRegistration: string;
  public concessionaryName: string;
}

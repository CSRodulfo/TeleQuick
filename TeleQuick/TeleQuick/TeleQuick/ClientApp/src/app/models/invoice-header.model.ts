export class InvoiceHeader {
  // Note: Using only optional constructor properties without backing store disables typescript's type checking for the type
  constructor(id?: number, date?: Date, subtotal?: number, total?: number, ivains?: number,
    concessionaryName?: string) {

    this.id = id;
    this.date = date;
    this.subtotal = subtotal;
    this.ivains = ivains;
    this.total = total;
    this.concessionaryName = concessionaryName;
  }

  public id: number;
  public date: Date;
  public subtotal: number;
  public ivains: number;
  public total: number;
  public concessionaryName: string;
}

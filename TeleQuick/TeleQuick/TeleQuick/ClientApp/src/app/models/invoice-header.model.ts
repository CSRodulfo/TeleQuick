export class InvoiceHeader {
  // Note: Using only optional constructor properties without backing store disables typescript's type checking for the type
  constructor(id?: number, date?: Date, subTotal?: number, total?: number, ivaIns?: number,
    concessionaryName?: string) {

    this.id = id;
    this.date = date;
    this.subTotal = subTotal;
    this.ivaIns = ivaIns;
    this.total = total;
    this.concessionaryName = concessionaryName;
  }

  public id: number;
  public date: Date;
  public subTotal: number;
  public ivaIns: number;
  public total: number;
  public concessionaryName: string;
}

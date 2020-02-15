// =============================
// Email: info@ebenmonney.com
// www.ebenmonney.com/templates
// =============================

export class Vehicle {
  // Note: Using only optional constructor properties without backing store disables typescript's type checking for the type
  constructor(id?: number, make?: string, model?: string, year?: number, registrationNumber?: string, tagNumber?: number) {

    this.id = id;
    this.make = make;
    this.model = model;
    this.year = year;
    this.registrationNumber = registrationNumber;
    this.tagNumber = tagNumber;
  }

  public id: number;
  public make: string;
  public model: string;
  public year: number;
  public registrationNumber: string;
  public tagNumber: number;
}

// =============================
// Email: info@ebenmonney.com
// www.ebenmonney.com/templates
// =============================

export class Vehicle {
  // Note: Using only optional constructor properties without backing store disables typescript's type checking for the type
  constructor(id?: string, make?: string, model?: string, year?: string, registrationNumber?: string) {

    this.id = id;
    this.make = make;
    this.model = model;
    this.year = year;
    this.registrationNumber = registrationNumber;
  }

  public id: string;
  public make: string;
  public model: string;
  public year: string;
  public registrationNumber: string;
}

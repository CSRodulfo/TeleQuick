
export class Test {
  // Note: Using only optional constructor properties without backing store disables typescript's type checking for the type
  constructor(name?: string, description?: string) {

    this.name = name;
    this.description = description;

  }

  public name: string;
  public description: string;

}

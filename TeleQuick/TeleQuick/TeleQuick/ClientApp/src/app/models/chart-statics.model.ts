export class ChartStaticsData {
    // Note: Using only optional constructor properties without backing store disables typescript's type checking for the type
    constructor(labels?: string, data?: number) {
  
      this.labels = labels;
      this.data = data;
    }
  
    public labels: string;
    public data: number;
  }
  
export class Currency {
  code: string;
  name: string;
  symbol: string;

  get displayName(): string {
    return `${this.symbol} ${this.code} - ${this.name}`;
  }
}

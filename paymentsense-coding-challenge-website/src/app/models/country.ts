import { Currency } from "./currency";
import { Language } from "./language";

export class Country {
  name: string;
  flag: string;
  population: number;
  capital: string;
  timezones: string[];
  currencies: Currency[];
  languages: Language[];
  borders: string[];
}

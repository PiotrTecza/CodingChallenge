import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { environment } from "src/environments/environment";
import { Country } from "../models/country";

@Injectable({
  providedIn: "root",
})
export class CountryDataService {
  constructor(private httpClient: HttpClient) {}

  public getAll(): Observable<Country[]> {
    return this.httpClient.get<Country[]>(`${environment.apiUrl}/countries`);
  }
}

import { Component, OnInit, ViewChild } from "@angular/core";
import { MatPaginator } from "@angular/material/paginator";
import { MatTableDataSource } from "@angular/material/table";
import { Country } from "../models/country";
import { CountryDataService } from "../services/country-data.service";
import { animate, state, style, transition, trigger } from "@angular/animations";

@Component({
  selector: "countries",
  templateUrl: "./countries.component.html",
  styleUrls: ["./countries.component.scss"],
  animations: [
    trigger("detailExpand", [
      state("collapsed", style({ height: "0px", minHeight: "0" })),
      state("expanded", style({ height: "*" })),
      transition("expanded <=> collapsed", animate("225ms cubic-bezier(0.4, 0.0, 0.2, 1)")),
    ]),
  ],
})
export class CountriesComponent implements OnInit {
  displayedColumns: string[] = ["flag", "name"];
  expandedElement: Country | null;
  dataSource = new MatTableDataSource<Country>();
  loading = true;
  hasError = false;

  @ViewChild(MatPaginator, { static: false }) set setPaginator(paginator: MatPaginator) {
    this.dataSource.paginator = paginator;
  }

  constructor(private countryDataService: CountryDataService) {}

  ngOnInit(): void {
    this.countryDataService.getAll().subscribe(
      (data: Country[]) => {
        this.loading = false;
        this.dataSource = new MatTableDataSource<Country>(data);
      },
      (err) => {
        this.loading = false;
        this.hasError = true;
      }
    );
  }
}

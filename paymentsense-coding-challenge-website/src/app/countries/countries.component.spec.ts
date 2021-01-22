import { async, ComponentFixture, TestBed } from "@angular/core/testing";
import { MatPaginatorModule, MatProgressSpinnerModule, MatTableModule } from "@angular/material";
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";
import { of, throwError } from "rxjs";
import { Country } from "../models/country";
import { CountryDataService } from "../services/country-data.service";

import { CountriesComponent } from "./countries.component";

describe("CountriesComponent", () => {
  let component: CountriesComponent;
  let fixture: ComponentFixture<CountriesComponent>;
  let mockCountryDataService: jasmine.SpyObj<CountryDataService>;
  let countries: Country[] = [
    <Country>{
      name: "USA",
      flag: "http://flags.com/usa.svg",
    },
    <Country>{
      name: "UK",
      flag: "http://flags.com/uk.svg",
    },
  ];

  beforeEach(async(() => {
    mockCountryDataService = jasmine.createSpyObj<CountryDataService>("countryDataService", ["getAll"]);

    mockCountryDataService.getAll.and.returnValue(of(countries));

    TestBed.configureTestingModule({
      imports: [MatTableModule, MatPaginatorModule, MatProgressSpinnerModule, BrowserAnimationsModule],
      declarations: [CountriesComponent],
      providers: [
        {
          provide: CountryDataService,
          useFactory: () => mockCountryDataService,
        },
      ],
    }).compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CountriesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it("should create", () => {
    expect(component).toBeTruthy();
  });

  it("should set datasource", () => {
    expect(component.dataSource.data).toBe(countries);
  });

  it("should update loading flag", () => {
    expect(component.loading).toBeFalsy();
  });

  it("should update error and loading flag on error", () => {
    mockCountryDataService.getAll.and.returnValue(throwError(new Error()));

    component.ngOnInit();

    expect(component.loading).toBeFalsy();
    expect(component.hasError).toBeTruthy();
  });

  it("should render error message in a h2 tag", () => {
    mockCountryDataService.getAll.and.returnValue(throwError(new Error()));

    component.ngOnInit();
    fixture.detectChanges();

    const compiled = fixture.debugElement.nativeElement;
    expect(compiled.querySelector("h2").textContent).toContain("Failed to get the list of countries");
  });

  it("should expand selected record", () => {
    component.ngOnInit();
    fixture.detectChanges();

    const compiled = fixture.debugElement.nativeElement;
    compiled.querySelector(".country-element-row").click();

    expect(component.expandedElement).toBe(countries[0]);
  });
});

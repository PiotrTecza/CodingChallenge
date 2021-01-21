import { BrowserModule } from "@angular/platform-browser";
import { NgModule } from "@angular/core";

import { AppRoutingModule } from "./app-routing.module";
import { AppComponent } from "./app.component";
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";
import { PaymentsenseCodingChallengeApiService } from "./services";
import { HttpClientModule } from "@angular/common/http";
import { FontAwesomeModule } from "@fortawesome/angular-fontawesome";
import { CountriesComponent } from "./countries/countries.component";
import { CountryDataService } from "./services/country-data.service";
import { MatPaginatorModule, MatProgressSpinnerModule, MatTableModule } from "@angular/material";

@NgModule({
  declarations: [AppComponent, CountriesComponent],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    HttpClientModule,
    FontAwesomeModule,
    MatTableModule,
    MatPaginatorModule,
    MatProgressSpinnerModule,
  ],
  providers: [PaymentsenseCodingChallengeApiService, CountryDataService],
  bootstrap: [AppComponent],
})
export class AppModule {}

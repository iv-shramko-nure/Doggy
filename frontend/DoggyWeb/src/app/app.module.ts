import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CoreModule } from 'src/app/core/core.module';
import { RouterModule } from '@angular/router';
import { ShelterSearchComponent } from './shelters/components/shelter-search/shelter-search.component';
import { ShelterSearchResultComponent } from './shelters/components/shelter-search/shelter-search-result/shelter-search-result.component';
import { ShelterSearchResultItemComponent } from './shelters/components/shelter-search/shelter-search-result-item/shelter-search-result-item.component';
import { RatingComponent } from './shared/components/rating/rating.component';

@NgModule({
  declarations: [
    AppComponent,
    ShelterSearchComponent,
    ShelterSearchResultComponent,
    ShelterSearchResultItemComponent,
    RatingComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule,
    CoreModule,
    RouterModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

import { SharedModule } from './shared/shared.module';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';
import { CoreModule } from 'src/app/core/core.module';
import { RouterModule } from '@angular/router';
import { ShelterSearchComponent } from './shelters/components/shelter-search/shelter-search.component';
import { ShelterSearchResultComponent } from './shelters/components/shelter-search/shelter-search-result/shelter-search-result.component';
import { ShelterSearchResultItemComponent } from './shelters/components/shelter-search/shelter-search-result-item/shelter-search-result-item.component';
import { AuthInterceptor } from 'src/app/auth/interceptors/auth.interceptor';

@NgModule({
  declarations: [
    AppComponent,
    ShelterSearchComponent,
    ShelterSearchResultComponent,
    ShelterSearchResultItemComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule,
    CoreModule,
    RouterModule,
    SharedModule,
  ],
  // providers: [
  //   { provide: HTTP_INTERCEPTORS, useClass: AuthInterceptor, multi: true }
  // ],
  bootstrap: [AppComponent]
})
export class AppModule { }

import { BrowserModule, Title } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppRoutingModule, routingComponents } from './app-routing.module';
import { AppComponent } from './app.component';

//Shared components
import { HeadComponent } from './shared/head/head.component';
import { MainComponent } from './shared/main/main.component';

//Services
import { SeoService } from './services/seo.service';

@NgModule({
  declarations: [
    AppComponent,
    routingComponents,
    HeadComponent,
    MainComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  //Serviços
  providers: [
    Title,
    SeoService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
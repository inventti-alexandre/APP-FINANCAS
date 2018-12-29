import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

//<Rotas>
import { HomeLoginComponent } from './home-login/home-login.component';
import { AboutUsComponent } from './about-us/about-us.component';
import { PricingComponent } from './pricing/pricing.component';
import { RegisterComponent } from './register/register.component';

const routes: Routes = [
  { path: "", redirectTo: "home", pathMatch: "full" },
  { path: "home", component: HomeLoginComponent },
  { path: "about", component: AboutUsComponent },
  { path: "pricing", component: PricingComponent },
  { path: "register", component: RegisterComponent }
];
//</Rotas>

@NgModule({
  imports: [RouterModule.forRoot(routes, {useHash:false})],
  exports: [RouterModule]
})

export class AppRoutingModule { }

export const routingComponents = [
  HomeLoginComponent, AboutUsComponent, PricingComponent, RegisterComponent
]
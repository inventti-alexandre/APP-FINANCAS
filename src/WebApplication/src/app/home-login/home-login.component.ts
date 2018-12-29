import { Component, OnInit } from '@angular/core';
import { SeoService, SeoModel } from '../services/seo.service';

@Component({
  selector: 'app-home-login',
  templateUrl: './home-login.component.html',
  styleUrls: ['./home-login.component.css']
})
export class HomeLoginComponent implements OnInit {

  constructor(seoService: SeoService) {
    let seoModel: SeoModel = <SeoModel> {
      title: "Bem Vindo",
      robots: "Index,Follow"
    }

    seoService.setSeoData(seoModel);
  }

  ngOnInit() {
  }

}

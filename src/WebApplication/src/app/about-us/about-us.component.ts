import { Component, OnInit } from '@angular/core';
import { SeoService, SeoModel } from '../services/seo.service';

@Component({
  selector: 'app-about-us',
  templateUrl: './about-us.component.html',
  styleUrls: ['./about-us.component.css']
})
export class AboutUsComponent implements OnInit {

  constructor(seoService: SeoService) {
    let seoModel: SeoModel = <SeoModel> {
      title: "Sobre nós",
      description: "Sobre a molia e nossa vontade de ajudar você",
      robots: "Index,Follow"
    }

    seoService.setSeoData(seoModel);
  }

  ngOnInit() {
  }

}

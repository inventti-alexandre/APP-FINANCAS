import { Component, OnInit } from '@angular/core';
import { SeoService, SeoModel } from '../services/seo.service';

@Component({
  selector: 'app-pricing',
  templateUrl: './pricing.component.html',
  styleUrls: ['./pricing.component.css']
})
export class PricingComponent implements OnInit {

  constructor(seoService: SeoService) {
    let seoModel: SeoModel = <SeoModel> {
      title: "Preços",
      description: "E a molia ainda é de graça para você",
      robots: "Index,Follow"
    }

    seoService.setSeoData(seoModel);
  }

  ngOnInit() {
  }

}

import { Component, OnInit } from '@angular/core';
import { SeoService, SeoModel } from '../services/seo.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  constructor(seoService: SeoService) {
    let seoModel: SeoModel = <SeoModel> {
      title: "Nova conta",
      description: "Cadastro de nova conta, molia",
      robots: "Index,Follow"
    }

    seoService.setSeoData(seoModel);
  }

  ngOnInit() {
  }
}
import { Injectable } from '@angular/core';
import { Title, Meta } from '@angular/platform-browser';
import { StringUtils } from '../utils/string.utils';

@Injectable()

export class SeoService {
    private titleService: Title;
    private meta: Meta;

    public constructor(titleService:Title, meta:Meta) {
        this.titleService = titleService;
        this.meta = meta;
        this.setTitle("");
    }

    public setSeoData(seoModel: SeoModel) {
        this.setTitle(seoModel.title);
        this.setMetaRobots(seoModel.robots);
        this.setMetaDescription(seoModel.description);
        this.setMetaKeywords(seoModel.keywords);
    }

    private setMetaDescription(description:string) {
        if (StringUtils.isNullOrEmpty(description)) description = "Gestão financeira pessoal e familiar, fácil e rápido";
        this.meta.updateTag({ name:"description", content:description });
    }

    private setMetaKeywords(keywords:string) {
        if (StringUtils.isNullOrEmpty(keywords)) keywords = "finanças,financas,gestão,gestao,família,familia,financeira,familiar,free,gratuito,gratúito";
        this.meta.updateTag({ name:"keywords", content:keywords });
    }

    private setMetaRobots(robots:string) {
        if (StringUtils.isNullOrEmpty(robots)) robots = "all";
        this.meta.updateTag({ name:"robots", content:robots });
    }

    private setTitle(newTitle:string) {
        if (StringUtils.isNullOrEmpty(newTitle)) newTitle = "Defina um título";
        this.titleService.setTitle("molia ;) - " + newTitle);
    }
}

export class SeoModel {
    public title: string = "";
    public description: string = "";
    public robots: string = "";
    public keywords: string = "";
}
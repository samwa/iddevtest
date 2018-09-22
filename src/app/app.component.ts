import { Component, OnInit } from '@angular/core';
import { Http } from '@angular/http';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {

  constructor(private _httpService: Http) { }

  title = 'id-dev-test';
  lgas: string[] = [];

  ngOnInit() {
    this._httpService.get('/api/lga').subscribe(values => {
        this.lgas = values.json() as string[];
    });
   }
}

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
  states = [
    {'short': '', 'long': 'All'},
    {'short': 'nsw', 'long': 'New South Wales'},
    {'short': 'vic', 'long': 'Victoria'},
    {'short': 'qld', 'long': 'Queensland'},
    {'short': 'sa', 'long': 'South Australia'},
    {'short': 'wa', 'long': 'Western Australia'},
    {'short': 'tas', 'long': 'Tasmania'},
    {'short': 'nt', 'long': 'Northern Territory'},
    {'short': 'act', 'long': 'Australian Capital Territory'}
  ];

  ngOnInit() {
    this._httpService.get('/api/lga').subscribe(response => {
        this.lgas = response.json() as string[];
    });
   }

  onChange(stateValue) {
    console.log(stateValue);
    this._httpService.get('/api/lga?state='+stateValue).subscribe(response => {
        this.lgas = response.json() as string[];
    });
  }
}

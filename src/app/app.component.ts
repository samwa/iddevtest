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
    this._httpService.get('/api/lga?state=vic').subscribe(response => {
        var lgas = response.json() as string[];
        var median = lgas;
        this.lgas = response.json() as string[];
    });
   }

  onChange(stateValue) {
    
    this._httpService.get('/api/lga?state='+stateValue).subscribe(response => {

        this.lgas = response.json() as string[];
    });
  }

  median(values) {

    values.sort( function(a,b) {return a - b;} );

    var half = Math.floor(values.length/2);

    if(values.length % 2)
        return values[half];
    else
        return (values[half-1] + values[half]) / 2.0;
  }
}

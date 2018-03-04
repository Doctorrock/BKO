import { Component, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { UserService } from '../../user.service';

@Component({
  selector: 'hidden-data',
  templateUrl: './hidden.component.html'
})
export class HiddenComponent {
  public forecasts: WeatherForecast[];

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
    //TODO: this is POC move to separate service

    console.log(localStorage);

      let authToken = localStorage.getItem('auth_token');
      let headers = new HttpHeaders().set('Authorization', `Bearer ${authToken}`);
      this.http.get<WeatherForecast[]>(this.baseUrl + "api/SampleData", { headers }).subscribe(result => {
          this.forecasts = result;
        },
        error => console.error(error));

  }
}

interface WeatherForecast {
  dateFormatted: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}

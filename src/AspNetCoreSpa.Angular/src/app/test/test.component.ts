import { Component, OnInit } from '@angular/core';
import {WeatherForecast} from "../models/weather.forecast";
import {RepositoryService} from "../services/repository.service";

@Component({
  selector: 'app-test',
  templateUrl: './test.component.html',
  styleUrls: ['./test.component.scss']
})
export class TestComponent implements OnInit {

  public weatherForecasts: WeatherForecast[]=[];

  constructor(private repository: RepositoryService) { }
  ngOnInit(): void {
    this.getWeatherForecast();
  }
  public getWeatherForecast = () => {
    let apiAddress: string = "api/WeatherForecast";
    this.repository.getData(apiAddress)
      .subscribe(res => {
        this.weatherForecasts = res as WeatherForecast[];
      })
  }
}

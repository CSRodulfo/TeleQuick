import { Component, OnInit, OnDestroy } from '@angular/core';
import { AlertService, DialogType, MessageSeverity } from '../../services/alert.service';
import { Subscription, Observable, fromEvent, of, merge } from 'rxjs';
import { map, distinctUntilChanged } from 'rxjs/operators';
import { ChartType } from 'chart.js';

import { BusinessService } from "../../services/business.service";
import { GlobalResources } from "../../services/globalResources";
import { Utilities } from "../../services/utilities";

@Component({
  selector: 'statistics-vehicle',
  templateUrl: './statistics-vehicle.component.html',
  styleUrls: ['./statistics-vehicle.component.scss']
})
export class StatisticsVehicleComponent implements OnInit, OnDestroy {

  Labels = [];
  Data = [];

  chartData = [{ data: this.Data, label: "Concesionaria" }];
  chartLabels = this.Labels;

  chartOptions = {
    responsive: true,
    title: {
      display: false,
      fontSize: 16,
      text: 'Important Stuff'
    }
  };
  chartColors = [
    { // something else
     backgroundColor: ['#F7464A', '#46BFBD', '#FDB45C', '#949FB1', '#4D5360'],
      hoverBackgroundColor: ['#FF5A5E', '#5AD3D1', '#FFC870', '#A8B3C5', '#616774'],
      borderWidth: 2,
    }

  ];
  chartLegend = false;
  chartType = 'bar' as any;

  timerReference: any;
  windowWidth$: Observable<number>;
  windowWidthSub: Subscription;


  constructor(
    private alertService: AlertService,
    private businessService: BusinessService,
    private resx: GlobalResources
  ) {}

  ngOnInit() {
    const initialWidth$ = of(window.innerWidth);
    const resizedWidth$ = fromEvent(window, 'resize').pipe(map((event: any) => event.target.innerWidth as number));
    this.windowWidth$ = merge(initialWidth$, resizedWidth$).pipe(distinctUntilChanged());

    this.windowWidthSub = this.windowWidth$.subscribe(width => this.chartLegend = width < 600 ? false : true);

    this.loadData();
  }

  ngOnDestroy() {
    clearInterval(this.timerReference);
    this.windowWidthSub.unsubscribe();
  }

  loadData() {
    this.businessService.getChartDataVehicle().subscribe({
      next: (results: any) => {
        this.onDataLoadSuccessful(results);
      },
      error: (error: any) => {
        this.onDataLoadFailed(error);
      },
      complete: () => {
        console.log("complete");
      }
    });
  }

  onDataLoadSuccessful(chartData: any) {
    chartData.forEach(x => {
      this.Labels.push(x.vehicleName);
      this.Data.push(x.total);
    });
  }

  onDataLoadFailed(error: any) {
    
    this.alertService.showStickyMessage(
      this.resx.loadError,
      `${this.resx.loadErrorDetail} ${Utilities.getHttpResponseMessages(
        error
      )}"`,
      MessageSeverity.error,
      error
    );
  }

}

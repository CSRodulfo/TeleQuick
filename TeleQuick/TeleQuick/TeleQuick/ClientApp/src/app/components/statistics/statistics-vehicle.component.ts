import { Component, OnInit, OnDestroy } from '@angular/core';
import { AlertService, DialogType, MessageSeverity } from '../../services/alert.service';
import { Subscription, Observable, fromEvent, of, merge } from 'rxjs';
import { map, distinctUntilChanged } from 'rxjs/operators';

require('chart.js');

@Component({
  selector: 'statistics-vehicle',
  templateUrl: './statistics-vehicle.component.html',
  styleUrls: ['./statistics-vehicle.component.scss']
})
export class StatisticsVehicleComponent implements OnInit, OnDestroy {

  chartData = [
    { data: [300, 590, 120, 700, 56], label: 'Series A' }
  ];
  chartLabels = ['MTI797', 'KTO278', 'AB123CD', 'AR987FD', 'GGF456'];
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


  constructor(private alertService: AlertService) {

  }

  ngOnInit() {
    const initialWidth$ = of(window.innerWidth);
    const resizedWidth$ = fromEvent(window, 'resize').pipe(map((event: any) => event.target.innerWidth as number));
    this.windowWidth$ = merge(initialWidth$, resizedWidth$).pipe(distinctUntilChanged());

    this.windowWidthSub = this.windowWidth$.subscribe(width => this.chartLegend = width < 600 ? false : true);
  }

  ngOnDestroy() {
    clearInterval(this.timerReference);
    this.windowWidthSub.unsubscribe();
  }

  changeChartType(type: any) {
    this.chartType = type;
  }

  chartClicked(e): void {
    console.log(e);
  }

}

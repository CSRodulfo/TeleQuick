import { Component, OnInit, OnDestroy } from '@angular/core';
import { AlertService, DialogType, MessageSeverity } from '../../services/alert.service';
import { Subscription, Observable, fromEvent, of, merge } from 'rxjs';
import { map, distinctUntilChanged } from 'rxjs/operators';

require('chart.js');

@Component({
  selector: 'statistics-year',
  templateUrl: './statistics-year.component.html',
  styleUrls: ['./statistics-year.component.scss']
})
export class StatisticsYearComponent implements OnInit, OnDestroy {

  chartData = [
    { data: [650, 590, 800, 810, 560, 550, 700, 850, 1100], label: 'Total' },
    { data: [300, 190, 600, 410, 500, 500, 400, 350, 100], label: 'AUSA' },
    { data: [350, 400, 200, 410, 60, 50, 300, 550, 1000], label: 'AUSOL' },
  ];
  chartLabels = ['Ene', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Ago'];
  chartOptions = {
    responsive: true,
    title: {
      display: false,
      fontSize: 16,
      text: 'Important Stuff'
    }
  };
  chartColors = [
    { // dark grey
      backgroundColor: 'rgba(77,83,96,0.2)',
      borderColor: 'rgba(77,83,96,1)',
      pointBackgroundColor: 'rgba(77,83,96,1)',
      pointBorderColor: '#fff',
      pointHoverBackgroundColor: '#fff',
      pointHoverBorderColor: 'rgba(77,83,96,1)'
    },
    { // something else
      backgroundColor: 'rgba(128,128,128,0.2)',
      borderColor: 'rgba(128,128,128,1)',
      pointBackgroundColor: 'rgba(128,128,128,1)',
      pointBorderColor: '#fff',
      pointHoverBackgroundColor: '#fff',
      pointHoverBorderColor: 'rgba(128,128,128,0.8)'
    },
    { // something else
      backgroundColor: 'rgba(255, 0, 0 ,0.4)',
      borderColor: 'rgb(255, 0, 0, 0.4)',
      pointBackgroundColor: 'rgb(255, 0, 0, 0.4)',
      pointBorderColor: '#fff',
      pointHoverBackgroundColor: '#fff',
      pointHoverBorderColor: 'rgba(255, 0, 0, 0.4)'
    }
  ];
  chartLegend = true;
  chartType = 'line' as any;

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

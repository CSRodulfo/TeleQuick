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
    {
      backgroundColor: 'rgba(105, 0, 132, .2)',
      borderColor: 'rgba(200, 99, 132, .7)',
      borderWidth: 2,
    },
    {
      backgroundColor: 'rgba(0, 137, 132, .2)',
      borderColor: 'rgba(0, 10, 130, .7)',
      borderWidth: 2,
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

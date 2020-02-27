// =============================
// Email: info@ebenmonney.com
// www.ebenmonney.com/templates
// =============================

import { Component, OnInit, OnDestroy } from '@angular/core';
import { AlertService, DialogType, MessageSeverity } from '../../services/alert.service';
import { Subscription, Observable, fromEvent, of, merge } from 'rxjs';
import { map, distinctUntilChanged } from 'rxjs/operators';
import { ChartsModule } from 'ng2-charts';
import { ChartDataSets, ChartType, RadialChartOptions } from 'chart.js';

require('chart.js');



@Component({
  selector: 'statistics-demo',
  templateUrl: './statistics-demo.component.html',
  styleUrls: ['./statistics-demo.component.scss']
})
export class StatisticsDemoComponent implements OnInit, OnDestroy {

  chartData = [
    { data: [650, 590, 800, 1200, 560, 550], label: 'Concesionaria' }
  ];
  chartLabels = ['AUSA', 'AUSOL', 'AUSUR', 'AUOESTE', 'AUBASA', 'CEAMSE'];
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
      backgroundColor: 'rgba(255, 0, 0 ,0.4)',
      borderColor: 'rgb(255, 0, 0, 0.4)',
      pointBackgroundColor: 'rgb(255, 0, 0, 0.4)',
      pointBorderColor: '#fff',
      pointHoverBackgroundColor: '#fff',
      pointHoverBorderColor: 'rgba(255, 0, 0, 0.4)'
    }

  ];
  chartLegend = true;
  chartType = 'bar' as ChartType

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

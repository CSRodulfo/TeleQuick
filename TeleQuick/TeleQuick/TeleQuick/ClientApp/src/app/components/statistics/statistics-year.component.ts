import { Component, OnInit, OnDestroy } from "@angular/core";
import { AlertService, MessageSeverity } from "../../services/alert.service";
import { Subscription, Observable, fromEvent, of, merge } from "rxjs";
import { map, distinctUntilChanged } from "rxjs/operators";
import { ChartType, ChartDataSets } from "chart.js";

import { BusinessService } from "../../services/business.service";
import { GlobalResources } from "../../services/globalResources";
import { Utilities } from "../../services/utilities";

@Component({
  selector: "statistics-year",
  templateUrl: "./statistics-year.component.html",
  styleUrls: ["./statistics-year.component.scss"]
})
export class StatisticsYearComponent implements OnInit, OnDestroy {
  Labels = [];
  Data = [];
  label = "";

  chartData: ChartDataSets[]; // = [
  //{ data: [], label: "" }
  //{ data: [350, 400, 200, 410, 60, 50, 300, 550, 1000], label: 'AUSOL' },
  //];

  chartLabels = [];
  chartOptions = {
    responsive: true,
    title: {
      display: false,
      fontSize: 16,
      text: "Important Stuff"
    },
    scales: {
      xAxes: [{
        ticks: {}
      }],
      yAxes: [{
        ticks: {
          beginAtZero: true,
          // Return an empty string to draw the tick line but hide the tick label
          // Return `null` or `undefined` to hide the tick line entirely
          userCallback: function (value, index, values) {
            return value.toLocaleString("es-AR", { style: 'currency', currency: "ARS", minimumFractionDigits: 0, maximumFractionDigits: 0 });
          }
        }
      }]
    },
    tooltips: {
      callbacks: {
        label: function (tooltipItem, data) {
          var index = tooltipItem.index;   
          return data.labels[index] +': '+ Number(tooltipItem.yLabel).toLocaleString("es-AR", { style: 'currency', currency: "ARS", minimumFractionDigits: 0, maximumFractionDigits: 0 });
        }
      }
    }
  };
  chartColors = [
    {
      backgroundColor: "rgba(105, 0, 132, .2)",
      borderColor: "rgba(200, 99, 132, .7)",
      borderWidth: 2
    },
    {
      backgroundColor: "rgba(0, 137, 132, .2)",
      borderColor: "rgba(0, 10, 130, .7)",
      borderWidth: 2
    },
    {
      // something else
      backgroundColor: "rgba(255, 0, 0 ,0.4)",
      borderColor: "rgb(255, 0, 0, 0.4)",
      pointBackgroundColor: "rgb(255, 0, 0, 0.4)",
      pointBorderColor: "#fff",
      pointHoverBackgroundColor: "#fff",
      pointHoverBorderColor: "rgba(255, 0, 0, 0.4)"
    }
  ];
  chartLegend = true;
  chartType = "line" as any;

  timerReference: any;
  windowWidth$: Observable<number>;
  windowWidthSub: Subscription;

  constructor(
    private alertService: AlertService,
    private businessService: BusinessService,
    private resx: GlobalResources
  ) {
    //this.loadData();
  }

  ngOnInit() {
    this.loadData();
    const initialWidth$ = of(window.innerWidth);
    const resizedWidth$ = fromEvent(window, "resize").pipe(
      map((event: any) => event.target.innerWidth as number)
    );
    this.windowWidth$ = merge(initialWidth$, resizedWidth$).pipe(
      distinctUntilChanged()
    );

    this.windowWidthSub = this.windowWidth$.subscribe(
      width => (this.chartLegend = width < 600 ? false : true)
    );
  }

  ngOnDestroy() {
    clearInterval(this.timerReference);
    this.windowWidthSub.unsubscribe();
  }

  loadData() {
    this.businessService.getChartDataYear().subscribe({
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
    chartData.chartData.forEach(x => {
      var datas = [];
      x.data.forEach(element => {
        datas.push(element.total);
      });

      if (this.chartData === undefined) {
        this.chartData = [{ data: datas, label: x.label }];
      } else {
        this.chartData.push({ data: datas, label: x.label });
      }
    });

    this.chartLabels = chartData.labels;
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

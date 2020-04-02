import { Component, OnInit, OnDestroy } from "@angular/core";
import {
  AlertService,
  DialogType,
  MessageSeverity
} from "../../services/alert.service";
import { Subscription, Observable, fromEvent, of, merge } from "rxjs";
import { map, distinctUntilChanged } from "rxjs/operators";
import { ChartType } from "chart.js";

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

  chartData = [
    { data: [], label: "" }
    //{ data: [350, 400, 200, 410, 60, 50, 300, 550, 1000], label: 'AUSOL' },
  ];
  chartLabels = ["Ene", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Ago"];
  chartOptions = {
    responsive: true,
    title: {
      display: false,
      fontSize: 16,
      text: "Important Stuff"
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
  ) {}

  ngOnInit() {
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

    this.loadData();
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

  onDataLoadSuccessful(invoice: any) {
    invoice.forEach(x => {
      var datas = [];
      x.data.forEach(element => {
        datas.push(element.total);
      });
      this.chartData.push({ data: datas, label: x.label });
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

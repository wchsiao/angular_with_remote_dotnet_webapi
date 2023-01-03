import { Component, OnInit, OnDestroy } from '@angular/core';
import { interval, Subscription } from 'rxjs';

import { EFormServiceStatus } from '../eform-service-status';
import { EFormServiceStatusService } from '../eform-service-status.service';

@Component({
  selector: 'app-eform-service-status',
  templateUrl: './eform-service-status.component.html',
  styleUrls: ['./eform-service-status.component.css']
})

export class EFormServiceStatusComponent implements OnInit, OnDestroy {
  eformServiceStatus: EFormServiceStatus[] = [];
  statusDate: Date = new Date();
  successCount: number = 0;
  failedCount: number = 0;

  interval =  setInterval(() => {
    this.statusDate = new Date();
    this.getEFormServiceStatus();
  }, 2000);;

  constructor(private eformServiceStatusService: EFormServiceStatusService) { }

  ngOnInit(): void {
    this.getEFormServiceStatus();

    //this.refreshInterval();
  }

  ngOnDestroy(): void {
    if(this.interval) {
      clearInterval(this.interval);
    }
  }

  getEFormServiceStatus(): void {
    //this.eformServiceStatusService.getEFormServiceStatus()
    //.subscribe(ess => this.eformServiceStatus = ess);

    this.eformServiceStatusService.getEFormServiceStatus()
      .subscribe((ess) => {
        this.eformServiceStatus = ess;

        var cs = 0;
        for (var i = 0; i<ess.length; i++) {
          cs += ess[i].success;
        }
        this.successCount = cs;
        
        var cf = 0;
        for (var i = 0; i<ess.length; i++) {
          cf += ess[i].failed;
        }
        this.failedCount = cf;
      });

    //this.subscription = timer(0, 5000)
  }

  refreshInterval(): void {
    setInterval(() => {
      //this.myDate = new Date();
      //console.log(this.myDate); // just testing if it is working

      this.statusDate = new Date();
      this.getEFormServiceStatus();
    }, 2000);
  }

  getSuccessCount(): Number {
    var c = 0;
    for (var i = 0; this.eformServiceStatus.length; i++) {
      c += this.eformServiceStatus[i].success;
    }
    return c;
  }

  getFailedCount(): Number {
    var c = 0;
    for (var i = 0; this.eformServiceStatus.length; i++) {
      c += this.eformServiceStatus[i].failed;
    }
    return c;
  }
}

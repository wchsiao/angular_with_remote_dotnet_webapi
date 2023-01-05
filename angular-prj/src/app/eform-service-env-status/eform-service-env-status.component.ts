import { Component, OnInit, OnDestroy } from '@angular/core';
import { interval, Subscription } from 'rxjs';

import { EFormServiceEnvStatus } from '../eform-service-env-status';
//import { EFormServiceStatus } from '../eform-service-status';
import { EFormServiceEnvStatusService } from '../eform-service-env-status.service';

@Component({
  selector: 'app-eform-service-status',
  templateUrl: './eform-service-env-status.component.html',
  styleUrls: ['./eform-service-env-status.component.css']
})

export class EFormServiceEnvStatusComponent implements OnInit, OnDestroy {
  eformServiceEnvStatus: EFormServiceEnvStatus = <EFormServiceEnvStatus>{};
  statusDate: Date = new Date();
  successCount: number = 0;
  failedCount: number = 0;

  interval =  setInterval(() => {
    this.statusDate = new Date();
    this.getEFormServiceEnvStatus();
  }, 2000);;

  constructor(private eformServiceEnvStatusService: EFormServiceEnvStatusService) { }

  ngOnInit(): void {
    this.getEFormServiceEnvStatus();

    //this.refreshInterval();
  }

  ngOnDestroy(): void {
    if(this.interval) {
      clearInterval(this.interval);
    }
  }

  getEFormServiceEnvStatus(): void {
    //this.eformServiceStatusService.getEFormServiceStatus()
    //.subscribe(ess => this.eformServiceStatus = ess);

    this.eformServiceEnvStatusService.getEFormServiceEnvStatus()
      .subscribe((ess) => {
        this.eformServiceEnvStatus = ess;

        var cs = 0;
        for (var i = 0; i<ess.eFormServiceStatusList.length; i++) {
          cs += ess.eFormServiceStatusList[i].success;
        }
        this.successCount = cs;
        
        var cf = 0;
        for (var i = 0; i<ess.eFormServiceStatusList.length; i++) {
          cf += ess.eFormServiceStatusList[i].failed;
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
      this.getEFormServiceEnvStatus();
    }, 2000);
  }

  getSuccessCount(): Number {
    var c = 0;
    for (var i = 0; this.eformServiceEnvStatus.eFormServiceStatusList.length; i++) {
      c += this.eformServiceEnvStatus.eFormServiceStatusList[i].success;
    }
    return c;
  }

  getFailedCount(): Number {
    var c = 0;
    for (var i = 0; this.eformServiceEnvStatus.eFormServiceStatusList.length; i++) {
      c += this.eformServiceEnvStatus.eFormServiceStatusList[i].failed;
    }
    return c;
  }
}

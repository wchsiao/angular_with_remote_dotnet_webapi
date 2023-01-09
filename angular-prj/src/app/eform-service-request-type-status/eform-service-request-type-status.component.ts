import { Component, OnInit, OnDestroy, Input } from '@angular/core';
import { interval, Subscription } from 'rxjs';
import { ActivatedRoute, ParamMap } from '@angular/router'

import { EFormServiceRequestTypeStatus } from '../eform-service-request-type-status';
import { EformServiceRequestTypeStatusService } from '../eform-service-request-type-status.service';

@Component({
  selector: 'app-eform-service-request-type-status',
  templateUrl: './eform-service-request-type-status.component.html',
  styleUrls: ['./eform-service-request-type-status.component.css']
})
export class EFormServiceRequestTypeStatusComponent implements OnInit, OnDestroy {

  eformServiceRequestTypeStatus: EFormServiceRequestTypeStatus[] = [];
  queryTime: Date = new Date();
  statusDateTime: Date = new Date();
  serverName: string = "";
  successCount: number = 0;
  failedCount: number = 0;

  interval = setInterval(() => {
    this.queryTime = new Date();
    this.getEFormServiceRequestTypeStatus();
  }, 2000);;

  constructor(
    private route: ActivatedRoute,
    private eformServiceRequestTypeStatusService: EformServiceRequestTypeStatusService
  ) {


  }

  ngOnInit(): void {
    this.route.paramMap.subscribe((params: ParamMap) => {
      this.serverName = params.get('server-name') || '';
    })
    this.getEFormServiceRequestTypeStatus();

    //this.refreshInterval();
  }

  ngOnDestroy(): void {
    if (this.interval) {
      clearInterval(this.interval);
    }
  }

  getEFormServiceRequestTypeStatus(): void {
    //this.eformServiceStatusService.getEFormServiceStatus()
    //.subscribe(ess => this.eformServiceStatus = ess);

    this.eformServiceRequestTypeStatusService.getEFormServiceRequestTypeStatus(this.serverName)
      .subscribe((ess) => {
        this.eformServiceRequestTypeStatus = ess;

        if (ess && ess.length >= 1) {
          this.statusDateTime = ess[0].statusDateTime;
          this.serverName = ess[0].serverName;
        }

        var cs = 0;
        for (var i = 0; i < ess.length; i++) {
          cs += ess[i].success;
        }
        this.successCount = cs;

        var cf = 0;
        for (var i = 0; i < ess.length; i++) {
          cf += ess[i].failed;
        }
        this.failedCount = cf;
      });
  }

  refreshInterval(): void {
    setInterval(() => {
      //this.myDate = new Date();
      //console.log(this.myDate); // just testing if it is working

      this.queryTime = new Date();
      this.getEFormServiceRequestTypeStatus();
    }, 2000);
  }
}

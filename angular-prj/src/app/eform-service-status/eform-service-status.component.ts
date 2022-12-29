import { Component, OnInit } from '@angular/core';

import { EFormServiceStatus } from '../eform-service-status';
import { EFormServiceStatusService } from '../eform-service-status.service';

@Component({
  selector: 'app-eform-service-status',
  templateUrl: './eform-service-status.component.html',
  styleUrls: ['./eform-service-status.component.css']
})

export class EFormServiceStatusComponent implements OnInit{
  eformServiceStatus: EFormServiceStatus[] = [];

  constructor(private eformServiceStatusService: EFormServiceStatusService) {}

  ngOnInit(): void {
    this.getEFormServiceStatus();
  }

  getEFormServiceStatus(): void {
    this.eformServiceStatusService.getEFormServiceStatus()
    .subscribe(ess => this.eformServiceStatus = ess);
  }
}

import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';

import { Person } from '../person';
import { PersonsService } from '../persons.service';

@Component({
  selector: 'app-person-detail',
  templateUrl: './person-detail.component.html',
  styleUrls: ['./person-detail.component.css']
})
export class PersonDetailComponent implements OnInit {
  person: Person | undefined;

  constructor(
    private route: ActivatedRoute,
    private personsService: PersonsService,
    private location: Location
  ) { }

  ngOnInit(): void {
    this.getPerson();
  }

  getPerson() {
    const id = parseInt(this.route.snapshot.paramMap.get('id')!, 10);
    this.personsService.getPerson(id)
      .subscribe(p => this.person = p);
  }

  goBack(): void {
    this.location.back();
  }

  save(): void {
    if (this.person) {
      this.personsService.updatePerson(this.person)
        .subscribe(() => this.goBack());
    }
  }
}

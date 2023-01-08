import { Component, OnInit } from '@angular/core';

import { Person } from '../person';
import { PersonsService } from '../persons.service';

@Component({
  selector: 'app-persons',
  templateUrl: './persons.component.html',
  styleUrls: ['./persons.component.css']
})
export class PersonsComponent implements OnInit {
  persons: Person[] = [];

  constructor(private personService: PersonsService) { }

  ngOnInit(): void {
    this.getPersons();
  }

  getPersons(): void {
    this.personService.getPersons()
      .subscribe(persons => this.persons = persons);
  }

  delete(person: Person): void {
    this.persons = this.persons.filter(p => p !== person);
    this.personService.deletePerson(person.personId).subscribe();
  }
}

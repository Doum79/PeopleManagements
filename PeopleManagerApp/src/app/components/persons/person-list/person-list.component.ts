import { Component, OnInit } from '@angular/core';
import { PersonService } from '../../../services/person.service';

@Component({
  selector: 'app-person-list',
  standalone: true,
  imports: [],
  templateUrl: './person-list.component.html',
  styleUrl: './person-list.component.css'
})
export class PersonListComponent implements OnInit{

  persons: any[] = [];

  constructor(private personService: PersonService) { }

  ngOnInit(): void {
    this.personService.getAllPersons().subscribe((data: any[]) => {
      // Trier par ordre alphabétique
      this.persons = data.sort((a, b) => a.firstName.localeCompare(b.firstName));
    }, error => {
      console.error('Error fetching persons', error);
    });
  }
}

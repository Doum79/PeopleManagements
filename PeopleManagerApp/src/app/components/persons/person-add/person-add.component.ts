import { Component } from '@angular/core';
import { PersonService } from '../../../services/person.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-person-add',
  standalone: true,
  imports: [],
  templateUrl: './person-add.component.html',
  styleUrl: './person-add.component.css'
})
export class PersonAddComponent {
  firstName: string = '';
  lastName: string = '';
  birthDate: string = '';
  errorMessage: string = '';

  constructor(private personService: PersonService, private router: Router) { }

  // Méthode pour ajouter une personne
  addPerson() {
    const currentDate = new Date();
    const birthDate = new Date(this.birthDate);
    const age = currentDate.getFullYear() - birthDate.getFullYear();

    if (age > 150) {
      this.errorMessage = 'L\'âge de la personne ne peut pas dépasser 150 ans.';
      return;
    }

    const newPerson = {
      firstName: this.firstName,
      lastName: this.lastName,
      birthDate: this.birthDate
    };

    this.personService.addPerson(newPerson).subscribe(response => {
      console.log('Person added successfully', response);
      this.router.navigate(['/persons']);  // Redirige vers la liste des personnes
    }, error => {
      this.errorMessage = 'Une erreur s\'est produite lors de l\'ajout de la personne.';
      console.error(error);
    });
  }
}

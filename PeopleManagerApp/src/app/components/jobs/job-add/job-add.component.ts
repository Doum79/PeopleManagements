import { Component, OnInit } from '@angular/core';
import { PersonService } from '../../../services/person.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-job-add',
  standalone: true,
  imports: [],
  templateUrl: './job-add.component.html',
  styleUrl: './job-add.component.css'
})
export class JobAddComponent implements OnInit{

  personId: number=0;
  companyName: string = '';
  position: string = '';
  startDate: string = '';
  endDate: string = '';

  constructor(
    private personService: PersonService,
    private route: ActivatedRoute,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.personId = params['id'];
    });
  }

  addJob() {
    const job = {
      companyName: this.companyName,
      position: this.position,
      startDate: this.startDate,
      endDate: this.endDate
    };

    this.personService.addJob(this.personId, job).subscribe(response => {
      console.log('Job added successfully', response);
      this.router.navigate([`/persons/${this.personId}`]);  // Redirige vers la page de la personne
    }, error => {
      console.error('Error adding job', error);
    });
  }
}

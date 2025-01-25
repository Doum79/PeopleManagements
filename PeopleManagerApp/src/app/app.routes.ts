import { RouterModule, Routes } from '@angular/router';
import { MainLayoutComponent } from './layouts/main-layout/main-layout.component';
import { PersonListComponent } from './components/persons/person-list/person-list.component';
import { JobAddComponent } from './components/jobs/job-add/job-add.component';
import { NgModule } from '@angular/core';


export const routes: Routes = [
   /* path: '', // Chemin de base
    component: MainLayoutComponent, // Mise en page principale
    children: [
      {
        path: 'persons', // Liste des personnes
        component: PersonListComponent,
      },
     
      
      {
        path: 'add-job', // Ajouter un nouvel emploi
        component: JobAddComponent,
      },
      {
        path: '', // Redirection par défaut
        redirectTo: 'persons',
        pathMatch: 'full',
      },
    ],
 */
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
  })
  export class AppRoutingModule { }
  
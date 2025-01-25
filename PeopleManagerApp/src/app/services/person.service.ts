import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../environements/environments';
import { Person } from '../models/person';
import { url } from 'inspector';

@Injectable({
  providedIn: 'root'
})
export class PersonService {

  private readonly routeBase = '';
  constructor(private readonly httpClient: HttpClient) { }


  // Ajouter une personne
  addPerson(person: any): Observable<any> {
    const url = `${environment.apiBaseUrl}/${this.routeBase}`;
    return this.httpClient.post<Person>(url, person);
  }
    // Ajouter un emploi pour une personne
    addJob(personId: number, job: any): Observable<any> {
      const url = `${environment.apiBaseUrl}/${this.routeBase}`;
      return this.httpClient.post(`${url}/${personId}/jobs`, job);
    }

    // Récupérer toutes les personnes, triées par ordre alphabétique
    getAllPersons(): Observable<any[]> {
      const url = `${environment.apiBaseUrl}/${this.routeBase}`;
      return this.httpClient.get<Person[]>(url);
     
    }
     // Récupérer toutes les personnes ayant travaillé dans une entreprise donnée
  getPersonsByCompany(companyName: string): Observable<any[]> {
    const url = `${environment.apiBaseUrl}/${this.routeBase}`;
    return this.httpClient.get<any[]>(`${url}/company/${companyName}`);
  }
  
  getJobsBetweenDates(personId: number, startDate: string, endDate: string): Observable<any[]> {
    const url = `${environment.apiBaseUrl}/${this.routeBase}`;
    return this.httpClient.get<any[]>(`${url}/${personId}/jobs?startDate=${startDate}&endDate=${endDate}`);
  }
}

import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../environements/environments';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class JobService {

   private readonly routeBase = 'api/${personId}/jobs';
   constructor(private readonly httpClient: HttpClient) { }

    // Ajouter un emploi pour une personne
       addJob(personId: number, job: any): Observable<any> {
         const url = `${environment.apiBaseUrl}/${this.routeBase}`;
         return this.httpClient.post(url, job);
       }

       getJobsBetweenDates(personId: number, startDate: string, endDate: string): Observable<any[]> {
        const url = `${environment.apiBaseUrl}/${this.routeBase}`;
        return this.httpClient.get<any[]>(`${url}?startDate=${startDate}&endDate=${endDate}`);
      }
   
}

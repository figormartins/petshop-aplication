import { HttpClient, HttpClientModule, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Animal } from '../models/animal.model';

@Injectable({
  providedIn: 'root'
})
export class AnimalService {

  apiUrl = 'https://localhost:5001/api/animal';
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  };
  constructor(
    private httpClient: HttpClient
  ) { }

  public getAnimals(): Observable<Animal[]> {
    return this.httpClient.get<Animal[]>(this.apiUrl)
  }

  public postAnimals(animal: Animal): Observable<Animal> {
    return this.httpClient.post<Animal>(this.apiUrl, animal, this.httpOptions);
  }
}

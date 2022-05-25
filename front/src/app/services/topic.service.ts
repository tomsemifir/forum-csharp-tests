import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Message } from '../models/message';
import { Topic } from '../models/topic';

@Injectable({
  providedIn: 'root'
})
export class SubjectService {

  constructor(private http : HttpClient) { }

  findAll() {
    return this.http.get<Topic[]>(`${environment.apiUrl}/topics`);
  }

  findById(id: number) {
    return this.http.get<Topic>(`${environment.apiUrl}/topics/${id}`);
  }

  create(subject: Topic) {
    return this.http.post<Topic>(`${environment.apiUrl}/topics`, subject);
  }

  delete(id: number) {
    return this.http.delete<Topic>(`${environment.apiUrl}/topics/${id}`);
  }
}

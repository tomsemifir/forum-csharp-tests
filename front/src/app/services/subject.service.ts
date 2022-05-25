import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Message } from '../models/message';
import { Subject } from '../models/subject';

@Injectable({
  providedIn: 'root'
})
export class SubjectService {

  constructor(private http : HttpClient) { }

  findAll() {
    return this.http.get<Subject[]>(`http://localhost:3000/subject`);
  }

  findById(id: string) {
    return this.http.get<Subject>(`http://localhost:3000/subject/${id}`);
  }

  create(subject: Subject) {
    return this.http.post<Subject>(`http://localhost:3000/subject`, subject);
  }

  addMessage(id: string, message: Message) {
    return this.http.post<Subject>(`http://localhost:3000/subject/${id}/message`, message);
  }

  deleteMessage(id: string, message: Message) {
    return this.http.delete<Subject>(`http://localhost:3000/subject/${id}/message`, {body: message});
  }

  delete(id: string) {
    return this.http.delete<Subject>(`http://localhost:3000/subject/${id}`);
  }
}

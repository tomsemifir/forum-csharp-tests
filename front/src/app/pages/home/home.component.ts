import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { Subject } from 'src/app/models/subject';
import { SubjectService } from 'src/app/services/subject.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  subjects : Subject[];

  subjectForm = this.fb.group({
    title: ""
  })

  constructor(
    private subjectService: SubjectService,
    private fb: FormBuilder
    ) { }

  ngOnInit(): void {
    this.initSubjects();
  }

  initSubjects() {
    this.subjectService.findAll().subscribe({
      next: (data) => {
        this.subjects = data;
      }
    })
  }

  sendSubject() {
    this.subjectService.create(this.subjectForm.value).subscribe({
      next: () => {
        this.subjectForm.reset();
        this.initSubjects();
      }
    })
  }

}

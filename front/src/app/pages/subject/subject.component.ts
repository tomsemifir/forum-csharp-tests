import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { Subject } from 'src/app/models/subject';
import { SubjectService } from 'src/app/services/subject.service';

@Component({
  selector: 'app-subject',
  templateUrl: './subject.component.html',
  styleUrls: ['./subject.component.scss']
})
export class SubjectComponent implements OnInit {

  id : string;
  subject : Subject;

  messageForm = this.fb.group({
    content: ""
  });

  constructor(
    private subjectService: SubjectService,
    private route: ActivatedRoute,
    private fb: FormBuilder
    ) { 
      this.id = this.route.snapshot.params["id"];
    }

  ngOnInit(): void {
    this.initSubject();
  }

  initSubject() {
    this.subjectService.findById(this.id).subscribe({
      next: (data) => {
        this.subject = data;
      }
    })
  }

  sendMessage() {
    this.subjectService.addMessage(this.id, this.messageForm.value).subscribe({
      next: () => {
        this.messageForm.reset();
        this.initSubject();
      }
    })
  }

}

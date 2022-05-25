import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { Message } from 'src/app/models/message';
import { Topic } from 'src/app/models/topic';
import { MessageService } from 'src/app/services/message.service';
import { SubjectService } from 'src/app/services/topic.service';

@Component({
  selector: 'app-subject',
  templateUrl: './subject.component.html',
  styleUrls: ['./subject.component.scss']
})
export class SubjectComponent implements OnInit {

  id : number;
  subject : Topic;

  messageForm = this.fb.group({
    content: ""
  });

  constructor(
    private subjectService: SubjectService,
    private messageService: MessageService,
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
    let message : Message = this.messageForm.value;
    message.topicId = this.id;
    this.messageService.create(message).subscribe({
      next: () => {
        this.messageForm.reset();
        this.initSubject();
      }
    })
  }

}

import { Component, Input, OnInit } from '@angular/core';
import { Subject } from 'src/app/models/subject';

@Component({
  selector: 'app-display-subject',
  templateUrl: './display-subject.component.html',
  styleUrls: ['./display-subject.component.scss']
})
export class DisplaySubjectComponent implements OnInit {

  @Input() subject : Subject;

  constructor() { }

  ngOnInit(): void {
  }

}

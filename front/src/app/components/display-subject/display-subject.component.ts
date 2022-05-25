import { Component, Input, OnInit } from '@angular/core';
import { Topic } from 'src/app/models/topic';

@Component({
  selector: 'app-display-subject',
  templateUrl: './display-subject.component.html',
  styleUrls: ['./display-subject.component.scss']
})
export class DisplaySubjectComponent implements OnInit {

  @Input() subject : Topic;

  constructor() { }

  ngOnInit(): void {
  }

}

import { Component, OnInit } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';

@Component({
  selector: 'app-adminstrator-actions',
  templateUrl: './adminstrator-actions.component.html',
  styleUrls: ['./adminstrator-actions.component.css']
})
export class AdminstratorActionsComponent implements OnInit {
  hide = true;
  email = new FormControl('', [Validators.required, Validators.email]);

  constructor() { }

  ngOnInit(): void {
  }

  getErrorMessage() {
    if (this.email.hasError('required')) {
      return 'You must enter a value';
    }

    return this.email.hasError('email') ? 'Not a valid email' : '';
  }

}

import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  styleUrls: ['./app.component.css'],
  template: `<div>
                <h1>{{pageHeader}}</h1>
                <app-emp></app-emp>
              </div>`
})
export class AppComponent {
  pageHeader = 'Employee Details';


}

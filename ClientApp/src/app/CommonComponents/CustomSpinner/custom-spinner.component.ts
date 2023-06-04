import { Component, Input } from '@angular/core';

@Component({
  selector: 'custom-spinner',
  templateUrl: './custom-spinner.component.html',
  styleUrls: ['./custom-spinner.component.css']
})
export class CustomSpinnerComponent {
  @Input() spin: boolean = false;
}

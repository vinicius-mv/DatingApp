import { Component, input, output } from '@angular/core';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-register',
  imports: [FormsModule],
  templateUrl: './register.component.html',
  styleUrl: './register.component.css'
})
export class RegisterComponent {
  // @Input() usersFromHomeComponent: any; // old way to receive data (no compiler warning)
  usersFromHomeComponent = input.required<any>();
  // @Output() cancelRegister = new EventEmitter(); // old way to send data (no compiler warning)
  cancelRegister = output<boolean>();

  model: any = {};

  register() {
    console.log(this.model);
  }

  cancel() {
    console.log('cancelled');
    this.cancelRegister.emit(false);
  }
}

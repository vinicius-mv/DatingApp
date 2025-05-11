import { Component, input } from '@angular/core';
import { Member } from '../../_models/member';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-member-card',
  imports: [RouterModule],
  templateUrl: './member-card.component.html',
  styleUrl: './member-card.component.css'
})
export class MemberCardComponent {
  member = input.required<Member>();
}

import { Component, OnInit } from '@angular/core';
import { AccountService } from '../_services/account.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
  model: any = {}
  loggegId: boolean;

  constructor(private accountService: AccountService) { }

  ngOnInit(): void {
  }

  login(): void {
    this.accountService.loging(this.model).subscribe(response => {
      console.log(response);
      this.loggegId = true;
    }, error => {
      console.log(error);
    })
  }
}

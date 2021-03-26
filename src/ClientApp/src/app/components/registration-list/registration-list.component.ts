import { Component, OnInit } from '@angular/core';
import { Registration } from 'src/app/domain/models/registration';
import { RegistrationClientService } from 'src/app/services/registration-client.service';

@Component({
  selector: 'app-registration-list',
  templateUrl: './registration-list.component.html',
  styleUrls: ['./registration-list.component.scss']
})
export class RegistrationListComponent implements OnInit {

  page = 1;
  pageSize = 4;
  registrations: Registration[] = [];
  collectionSize = 0;

  constructor(
    private registrationClient: RegistrationClientService
    ) { }

  ngOnInit(): void {
    this.refreshRegistrations();
  }
    
  refreshRegistrations() {

    this.registrationClient.getAllRegistrations()
    .subscribe(value => {
      console.log(value);
      this.registrations = value
      this.registrations
      .map((registration, i) => ({i: i + 1, ...registration}))
      .slice((this.page - 1) * this.pageSize, (this.page - 1) * this.pageSize + this.pageSize);
    });
  }

}

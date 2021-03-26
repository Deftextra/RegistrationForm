import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { first } from 'rxjs/operators';
import { RegistrationClientService } from 'src/app/services/registration-client.service';

@Component({
  selector: 'app-registration-form',
  templateUrl: './registration-form.component.html',
  styleUrls: ['./registration-form.component.scss'],
})
export class RegistrationFormComponent implements OnInit {
  form!: FormGroup;
  loading = false;
  submitted = false;

  readonly phoneNumberRegex = /^[\+]?[(]?[0-9]{3}[)]?[-\s\.]?[0-9]{3}[-\s\.]?[0-9]{4,6}$/im;

  constructor(
    private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private registrationService: RegistrationClientService
  ) {}

  ngOnInit() {
    this.form = this.formBuilder.group({
      firstName: ['', Validators.required, Validators.maxLength(10)],
      lastName: ['', Validators.required, Validators.maxLength(10)],
      phoneNumber: [
        '',
        Validators.required,
        Validators.pattern(this.phoneNumberRegex),
      ],
      emailAddress: ['', [Validators.required, Validators.email]],
      // Address starts here.
      country: ['', [Validators.required]],
      street: ['', [Validators.required]],
      city: ['', [Validators.required]],
      state: ['', [Validators.required]],
      postalCode: ['', [Validators.required]]
    });
  }

  get f() {
    return this.form.controls;
  }

  onSubmit() {
    this.submitted = true;
    // TODO: Add alert service

    // stop here if form is invalid
    if (this.form.invalid) {
      return;
    }

    // TODO: Uses nested forms to pervent manual mapping here.
    const formValue = this.form.value;

    const saveRegistrationRequest = {
      firstName: formValue.firstName as string,
      lastName: formValue.lastName as string,
      phoneNumber: formValue.phoneNumber as string,
      emailAddress: formValue.emailAddress as string,
      address: {
        country: formValue.country as string,
        street: formValue.street as string,
        city: formValue.city as string,
        state: formValue.state as string,
        postalCode: formValue.postalCode as string
      }
    }

    this.loading = true;
    this.registrationService
      .addRegistration(saveRegistrationRequest)
      .pipe(first())
      .subscribe({
        next: () => {
          this.router.navigate(['../list-registrations'], { relativeTo: this.route });
        },
        error: error => {
          /// TODO: Add server side error messages
          console.log(error);
            this.loading = false;
        }
      });
  }
}

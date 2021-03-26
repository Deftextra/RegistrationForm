import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { RegistrationFormComponent } from './components/Forms/registration-form/registration-form.component';
import { RegistrationListComponent } from './components/registration-list/registration-list.component';

const routes: Routes = [
  {path: 'list-registrations', component: RegistrationListComponent },
  {path: '', component: RegistrationListComponent },
  {path: 'registration-form', component: RegistrationFormComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

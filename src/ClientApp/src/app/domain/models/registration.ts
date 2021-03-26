import { RegistrationResponse } from "../Interfaces/registration-response";
import { Address } from "./address";

export class Registration {
  id: string;
  firstName: string;
  lastName: string;
  phoneNumber: string; 
  emailAddress: string;
  address: Address;




  constructor(registration: RegistrationResponse)
  {
      this.id = registration.id;
      this.firstName = registration.firstName;
      this.lastName = registration.lastName;
      this.phoneNumber = registration.phoneNumber;
      this.emailAddress = registration.emailAddress;
      this.address = registration.address;
  }

}


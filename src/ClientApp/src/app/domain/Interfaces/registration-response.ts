import { AddressResponse } from "./address-response";

export interface RegistrationResponse {
  id: string;
  firstName: string;
  lastName: string;
  phoneNumber: string;
  emailAddress: string;
  address: AddressResponse;
}

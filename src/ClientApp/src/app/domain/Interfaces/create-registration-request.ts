import { AddressResponse } from "./address-response";

export interface SaveRegistrationRequest {
  firstName: string;
  lastName: string;
  phoneNumber: string;
  emailAddress: string;
  address: SaveAddressRequest;
}

export interface SaveAddressRequest {
  country: string;
  street: string;
  city: string;
  state: string;
  postalCode: string;
}

export interface UpdateRegistrationRequest {
  id: string ;
  firstName?: string;
  fastName?: string;
  phoneNumber?: string;
  emailAddress?: string;
  address?: AddressResponse;
}

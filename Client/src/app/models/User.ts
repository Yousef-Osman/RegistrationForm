import { Address } from "./Address";

export interface User {
    firstName: string;
    middleName?: string;
    lastName: string;
    birthDate: Date;
    mobileNumber: string;
    email: string;
    addresses: Address[];
}

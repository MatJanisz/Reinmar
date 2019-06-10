import { Status } from "./status";


export interface Package{
sitId?: string;
orderName?: string;
receiverFullName: string;
receiverEmail?: string;
phoneNumber:	string;
country:	string;
city:	string;
postalCode:	string;
streetName:	string;
houseNumber:	string;
notes:	string;
cashOnDelivery:	number;
statuses:	Status[];
id?:	string;
}
export class WaybillBody {

    SitId: number;
    Category: string;
    CargoName: string;
    Quantity: 0;
    Code: string;
    IsAssembly: true;
    IsCollection: true;
    Zone: 0;
    Service: string;
    WaybillHeaders: WaybillHeaders;
    Status: [
      {
        id: 0;
        Location: string;
        Event: string;
        DateFrom: Date
      }
    ]


  constructor(
    SitId: 0,
    Category: string,
    CargoName: string,
    Quantity: 0,
    Code: string,
    IsAssembly: true,
    IsCollection: true,
    Zone: 0,
    Service: string,
    waybillHeaders: WaybillHeaders,
    status: [
      {
        location: string,
        event: string,
        dateFrom: string
      }
    ]
  ) { }
}

export class WaybillHeaders {
  SitId: number;
  FullName: string;
  Email: string;
  PhoneNumber: string;
  StreetName: string;
  HouseNumber: string;
  City: string;
  PostalCode: string;
  InvoiceId: string;
  Date: Date;
  Notes: string;
  CashOnDelivery: number;
  OrderName: string
  
  constructor(
    SitId: number,
    FullName: string,
    Email: string,
    PhoneNumber: string,
    StreetName: string,
    HouseNumber: string,
    City: string,
    PostalCode: string,
    InvoiceId: string,
    DateTime: Date,
    Notes: string,
    CashOnDelivery: number,
    OrderName: string
  ) { }
}
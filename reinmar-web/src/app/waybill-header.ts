export class WaybillBody {

    SitId: 0;
    Category: String;
    CargoName: String;
    Quantity: 0;
    Code: String;
    IsAssembly: true;
    IsCollection: true;
    Zone: 0;
    Service: String;
    WaybillHeaders: WaybillHeaders;
    Status: [
      {
        id: 0;
        Location: String;
        Event: String;
        DateFrom: Date
      }
    ]


  constructor(
    SitId: 0,
    Category: String,
    CargoName: String,
    Quantity: 0,
    Code: String,
    IsAssembly: true,
    IsCollection: true,
    Zone: 0,
    Service: String,
    waybillHeaders: WaybillHeaders,
    status: [
      {
        location: String,
        event: String,
        dateFrom: String
      }
    ]
  ) { }
}

export class WaybillHeaders {
  SitId: number;
  FullName: String;
  Email: String;
  PhoneNumber: String;
  StreetName: String;
  HouseNumber: String;
  City: String;
  PostalCode: String;
  InvoiceId: String;
  Date: Date;
  Notes: String;
  CashOnDelivery: number;
  OrderName: String
  
  constructor(
    SitId: number,
    FullName: String,
    Email: String,
    PhoneNumber: String,
    StreetName: String,
    HouseNumber: String,
    City: String,
    PostalCode: String,
    InvoiceId: String,
    DateTime: Date,
    Notes: String,
    CashOnDelivery: number,
    OrderName: String
  ) { }
}
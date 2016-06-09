# Everypay .NET library

## Usage

### Creating a Payment from card token.
```cs
using System;
using Everypay;
using System.Collections.Generic;

Everypay.Everypay.apiKey = "sk_YoUraPikEy";
Everypay.Everypay.isTest = true; // False for production environments.

Dictionary<string, string> data = new Dictionary<string, string> ();
data.Add ("amount", "1000"); // 10 EURO in cents
data.Add ("token", "ctn_tokenHashYouGot");

PaymentResource p = new Everypay.PaymentResource ();
p.create (data);

if (!p.success ()) {
    Console.WriteLine (p.getError ().message);
} else {
    Payment payment = p.getObject ();
    Console.WriteLine (payment.token);
}
```

### Creating a Payment from card data.
```cs
using System;
using Everypay;
using System.Collections.Generic;

Everypay.Everypay.apiKey = "sk_YoUraPikEy";
Everypay.Everypay.isTest = true; // False for production environments.

Dictionary<string, string> data = new Dictionary<string, string> ();
data.Add ("amount", "1000"); // 10 EURO in cents
data.Add ("card_number", "4111111111111111");
data.Add ("expiration_year", "2020");
data.Add ("expiration_month", "1");
data.Add ("cvv", "123");
data.Add ("holder_name", "JOHN DOE");

PaymentResource p = new Everypay.PaymentResource ();
p.create (data);

if (!p.success ()) {
    Console.WriteLine (p.getError ().message);
} else {
    Payment payment = p.getObject ();
    Console.WriteLine (payment.token);
}
```
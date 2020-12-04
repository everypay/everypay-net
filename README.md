# Everypay .NET library

# ATTENTION
**You must be using this plugin together with our [iFrame](https://docs.everypay.gr/accept-payments/payform/).**

**You cannot gather card data unless you are [PCI DSS SAQ D Certification](https://www.pcisecuritystandards.org/documents/SAQ_D_v3_Merchant.pdf)**

**Check our [docs](https://docs.everypay.gr/) for more information**

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

/*
 You can only handle card information if you have PCI DSS SEQ D
 This example is only for MOTO (mail order telephone order) payments
 You need to use this plugin with our iFrame solution in order to handle card data
*/
 
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

### Creating a Customer from card data.

```cs
using System;
using Everypay;
using System.Collections.Generic;

Everypay.Everypay.apiKey = "sk_YoUraPikEy";
Everypay.Everypay.isTest = true; // False for production environments.

Dictionary<string, string> data = new Dictionary<string, string> ();
data.Add ("card_number", "4111111111111111");
data.Add ("expiration_year", "2020");
data.Add ("expiration_month", "1");
data.Add ("cvv", "123");
data.Add ("holder_name", "JOHN DOE");

CustomerResource c = new Everypay.CustomerResource ();
c.create (data);

if (!c.success ()) {
    Console.WriteLine (c.getError ().message);
} else {
    Customer customer = c.getObject ();
    Console.WriteLine (customer.token);
}
```

### Creating a Schedule
```cs
Everypay.Everypay.apiKey = "sk_YoUraPikEy";
Everypay.Everypay.isTest = true; // False for production environments.

Dictionary<string, string> data = new Dictionary<string, string> ();
data.Add ("amount", "1000");
data.Add ("card_number", "5278900020308586");
data.Add ("expiration_year", "2020");
data.Add ("expiration_month", "1");
data.Add ("cvv", "123");
data.Add ("holder_name", "JOHN DOE");
data.Add ("description", "Test schedule");
data.Add ("customer_email", "john@example.net");
data.Add ("schedule_type", "percentage");
string[] scheduleRates = { "20", "30", "50" };
DateTime[] scheduleDatesArray = new DateTime[3];
scheduleDatesArray [0] = Convert.ToDateTime ("10/23/2016");
scheduleDatesArray [1] = Convert.ToDateTime ("11/23/2016");
scheduleDatesArray [2] = Convert.ToDateTime ("12/22/2016");

ScheduleResource s = new Everypay.ScheduleResource ();
s.create (data, scheduleDatesArray, scheduleRates);

if (!s.success ()) {
    Console.WriteLine (s.getError ().message);
} else {
    Schedule schedule = s.getObject ();
    Console.WriteLine (schedule.token);
}
```

### Canceling a schedule

```cs
Everypay.Everypay.apiKey = "sk_YoUraPikEy";
Everypay.Everypay.isTest = true; // False for production environments.

ScheduleResource s = new Everypay.ScheduleResource ();
s.delete ("sch_j7TwTG5RTy1VgJFLzWDd8kAi");
Schedule schedule = s.getObject ();

Console.WriteLine (schedule.token);
```

### Updating a schedule
```cs
Everypay.Everypay.apiKey = "sk_YoUraPikEy";
Everypay.Everypay.isTest = true; // False for production environments.

Dictionary<string, string> data = new Dictionary<string, string> ();
ScheduleResource s = new Everypay.ScheduleResource ();

// Add  new schedule rates
string[] scheduleRates = { "30", "20", "50" };

// Add dates
DateTime[] scheduleDatesArray = new DateTime[3];
scheduleDatesArray [0] = Convert.ToDateTime ("10/23/2016");
scheduleDatesArray [1] = Convert.ToDateTime ("11/23/2016");
scheduleDatesArray [2] = Convert.ToDateTime ("12/22/2016");

//Add Schedule item tokens
data["tokens"] = "sci_r4cyKn1MjbbIQRDfjdqzGG4T;sci_GeWnRgUnErH57KOvkJjUqPT9;sci_JiY1cmYhe1ZDY3dUQkBrZkX3";
s.update ("sch_cWISdpQAdX1QjRvvOILw3p6G", data, scheduleDatesArray, scheduleRates);

if (!s.success ()) {
    Console.WriteLine (s.getError ().message);
} else {
    Schedule schedule = s.getObject ();
    Console.WriteLine (schedule.token);
}
```

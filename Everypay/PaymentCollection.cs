using System;
using System.Collections.Generic;

namespace Everypay
{
	public class PaymentCollection
	{
		public string total_count { get; set;}

		public List<Payment> items { get; set;}
	}
}
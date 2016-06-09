using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Net.Http;

namespace Everypay
{
	/**
	 * 
     * Get a collection of given resource objects by applying some filters.
     * 
     * Filters are optionals and include:
     * - count:     The number of objects to returns. Availabe range is 1 - 20.
     * - offset:    The offset of collection to return. Useful for pagination.
     * - date_from: Return objects that created after that date.
     *              Format: YYYY-mm-dd
     * - date_to:   Return objects that created before that date.
     *              Format: YYYY-mm-dd
	 * 
     * Create a new payment object.
     *
     * Available params are:
     * - amount: The amount in cents for the payment. [Required]
     * For direct payment with credit / debit cards, card info are required.
     * - card_number:       A valid credit /debit card number. [Required]
     * - expiration_month:  Integer representation of month. [Required]
     * - expiration_year:   Integer represantation of a valid expiration year. [Required]
     * - cvv:               Card verification value. Three or four (American express) digits. [Required]
     * - holder_name:       First and last name of the card holder. [Required]
     * For payments with card token, a valid card token required. Card tokens
     * can be obtained from Token::create api calls.
     * - token [Required].
     * Optional params.
     * - currency:      The ISO 4217 code currency used for this payment. [Optional]
     * - description:   A decription for this payment max 255 chars. [Optional]
     * - payee_email:   Customer email. [Optional]
     * - payee_phone:   Customer phone number. [Optional]
     * - capture:       Boolean Whether to capture a payment or just authorize it.
     *                  To authorize a payment this value must be 0.
     * - create_customer: Boolean Whether to create a customer and store its
     *                    card or not.
     * - installments: Integer The number of installments for this payment.
     *                 Can only be used for credit card payments.
     * - max_installments: Integer Used for payments with token, to validate
     *                      max installments set by the merchant from
     *                      everypay Button.
     * 
     * Refund a payment.
     * Available $params are:
     * - amount: The amount to refund. The amount must not exceed the maximum
     *           amount of Payment. Can be used for partial refunds. If ommited
     *           then a full refund will be created. [Optional]
     * - description: A description for this refund max 255 chars. [Optional]
     * 
     */
	public class PaymentResource : Resource
	{
		/**
		 * Captures a Pre-Authorized payment.
		 * 
		 */
		public void capture(string token)
		{
			Dictionary<string, string> data = new Dictionary<string, string> ();
			data.Add("token", token);
			data.Add ("namespace", "capture");

			invoke (HttpMethod.Put, data);
		}

		public void refund(string token, Dictionary<string, string> data = null)
		{
			if (null == data) {
				data = new Dictionary<string, string> ();
			}
			data.Add("token", token);
			data.Add ("namespace", "refund");

			invoke (HttpMethod.Put, data);
		}

		public Payment getObject()
		{
			return JsonConvert.DeserializeObject<Payment>(responseContent);
		}

		public PaymentCollection getCollection()
		{
			return JsonConvert.DeserializeObject<PaymentCollection>(responseContent);
		}

		protected override string getResource()
		{
			return "payments";
		}

		public new void update(string token, Dictionary<string, string> data = null)
		{
			string message = "Resource `Payment` does not support `update` method";
			throw new MethodNotAllowedException (message);
		}

		public new void delete(string token)
		{
			string message = "Resource `Payment` does not support `delete` method";
			throw new MethodNotAllowedException (message);
		}
	}
}
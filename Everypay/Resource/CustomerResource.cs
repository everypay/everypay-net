using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Net.Http;

namespace Everypay
{
	/**
     * Create a new customer object.
     *
     * Available params are:
     * For customers from credit / debit cards, card info are required.
     * - card_number: A valid credit /debit card number. [Required]
     * - expiration_month: Integer representation of month. [Required]
     * - expiration_year: Integer represantation of a valid expiration year. [Required]
     * - cvv: Card verification value. Three or four (American express) digits. [Required]
     * - holder_name: First and last name of the card holder. [Required]
     * For customers from card token, a valid card token required. Card tokens
     * can be obtained from Token::create api calls.
     * - token [Required].
     * Optional params.
     * - description: A decription for this customer max 255 chars. [Optional]
     * - email:       Customer email. [Optional]
     * - full_name:   Customer full name. [Optional]
     * 
     * 
     * Update an existing customer.
     *
     * Parameters that can be updated are:
     * - description: A decription for this customer max 255 chars. [Optional]
     * - email:       Customer email. [Optional]
     * - full_name:   Customer full name. [Optional]
     *
     * Following parameters can be used in case of adding a new card for customer
     * or updating the default one.
     * - token: The CardToken that holds credit card information.
     * - card: The token of a Card object.
     * - default_card: Whether the above tokens will be set as default card
     *                  for customer. Set this value to 1 to set as default card.
     *
     * You can also add a new card to customer by sending the same card info
     * you send when creating a customer.
     * 
     */
	public class CustomerResource : Resource
	{
		public Customer getObject()
		{
			return JsonConvert.DeserializeObject<Customer>(responseContent);
		}

		protected override string getResource()
		{
			return "customers";
		}
	}
}
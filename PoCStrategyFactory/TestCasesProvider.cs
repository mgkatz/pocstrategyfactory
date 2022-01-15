using PoCStrategyFactory.Data;
using PoCStrategyFactory.Business.Models;
using System.Collections.Generic;

namespace PoCStrategy
{
	/// <summary>
	/// EN: Class that provides the test cases.
	/// ES: Clase que provee los casos de prueba.
	/// </summary>
	public static class TestCasesProvider
	{
		/// <summary>
		/// EN: Dictionary with each of the test cases.
		/// ES: Diccionario con cada uno de los casos de prueba.
		/// </summary>
		public static readonly IDictionary<string, PaymentInfoDto> PaymentInfoTestCases = new Dictionary<string, PaymentInfoDto>
		{
			{ "Digital channel - Price for payment through a digital channel", GetPriceThroughDigitalChannel() },
			{ "Digital channel - Price for payment through a digital channel that not exists", GetPriceThroughNonExistingDigitalChannel() },
			{ "Digital channel - Price for payment through a digital channel with no existing payment method", GetPriceThroughDigitalChannelWithNoExistingPaymentMethod() },
			{ "In Person channel - Price for cash with list price", GetPriceForCashWithListPrice() },
			{ "In Person channel - Price for cash with discount", GetPriceForCashWithDiscount() },
			{ "In Person channel - Price for debit card with list price", GetPriceForDebitCardWithListPrice() },
			{ "In Person channel - Price for credit card with list price in one payment", GetPriceForCreditCardWithListPriceInOnePayment() },
			{ "In Person channel - Price for credit card with extra charge in one payment", GetPriceForCreditCardWithExtraChargeInOnePayment() },
			{ $"In Person channel - Price for credit card {nameof(CardCompany.VICARD)} with 3 payments", GetPriceForCreditCardViCardWith3Payments() },
			{ $"In Person channel - Price for credit card {nameof(CardCompany.VICARD)} with 6 payments", GetPriceForCreditCardViCardWith6Payments() },
			{ $"In Person channel - Price for credit card {nameof(CardCompany.VICARD)} with 12 payments", GetPriceForCreditCardViCardWith12Payments() },
			{ $"In Person channel - Price for credit card {nameof(CardCompany.VICARD)} with 18 payments", GetPriceForCreditCardViCardWith18Payments() },
			{ $"In Person channel - Price for credit card {nameof(CardCompany.ACARD)} with 3 payments", GetPriceForCreditCardAcardWith3Payments() },
			{ $"In Person channel - Price for credit card {nameof(CardCompany.ACARD)} with 6 payments", GetPriceForCreditCardAcardWith6Payments() },
			{ $"In Person channel - Price for credit card {nameof(CardCompany.ACARD)} with 12 payments", GetPriceForCreditCardAcardWith12Payments() },
			{ $"In Person channel - Price for credit card {nameof(CardCompany.MYCARD)} with 3 payments", GetPriceForCreditCardMyCardWith3Payments() },
			{ $"In Person channel - Price for credit card {nameof(CardCompany.MYCARD)} with 6 payments", GetPriceForCreditCardMyCardWith6Payments() },
			{ "In Person channel - Price for credit card with no existing plan", GetPriceForCreditCardNoExistingPlan() },
			{ "In Person channel - Price for payment through the In Person channel with incorrect payment method", GetPriceThroughInPersonChannelWithIncorrectPaymentMethod() }
		};

		/// <summary>
		/// EN: Test case - Payment through the digital channel must return the corresponding price.
		/// ES: Caso de prueba - Pago mediante el canal digital debe retornar el precio correspondiente.
		/// </summary>
		/// <returns>
		/// EN: The payment information.
		/// ES: La información de pago.
		/// </returns>
		private static PaymentInfoDto GetPriceThroughDigitalChannel() => new()
		{
			CardCompany = null,
			NumberOfPayments = 1,
			PaymentChannelType = PaymentChannelType.Digital,
			PaymentMethodId = 1,
			Price = 1000.00M,
			TypeOfPayment = PaymentMethodType.Digital
		};

		/// <summary>
		/// EN: Test case - It should generate an error because the channel type does not exist for the Digital payment channel.
		/// ES: Caso de prueba - Debe generar un error porque el tipo de canal no existe para el canal de pago Digital.
		/// </summary>
		/// <returns>
		/// EN: The payment information.
		/// ES: La información de pago.
		/// </returns>
		private static PaymentInfoDto GetPriceThroughNonExistingDigitalChannel() => new()
		{
			CardCompany = null,
			NumberOfPayments = 1,
			PaymentChannelType = PaymentChannelType.Unknown,
			PaymentMethodId = 1, Price = 1000.00M,
			TypeOfPayment = PaymentMethodType.Digital
		};

		/// <summary>
		/// EN: Test case - It should generate an error because the payment method chosen for the payment channel Digital does not exist.
		/// ES: Caso de prueba - Debe generar un error porque el método de pagos elegido para el canal de pago Digital no existe.
		/// </summary>
		/// <returns>
		/// EN: The payment information.
		/// ES: La información de pago.
		/// </returns>
		private static PaymentInfoDto GetPriceThroughDigitalChannelWithNoExistingPaymentMethod() => new()
		{
			CardCompany = null,
			NumberOfPayments = 1,
			PaymentChannelType = PaymentChannelType.Digital,
			PaymentMethodId = 1,
			Price = 1000.00M,
			TypeOfPayment = PaymentMethodType.Cash
		};

		/// <summary>
		/// EN: Test case - Payment in cash must return the same list price.
		/// ES: Caso de prueba - Pago en efectivo debe retornar el mismo precio de lista.
		/// </summary>
		/// <returns>
		/// EN: The payment information.
		/// ES: La información de pago.
		/// </returns>
		private static PaymentInfoDto GetPriceForCashWithListPrice() => new()
		{
			PaymentMethodId = 1,
			TypeOfPayment = PaymentMethodType.Cash,
			Price = 1000.00M,
			PaymentChannelType = PaymentChannelType.InPerson
		};

		/// <summary>
		/// EN: Test case - Payment in cash must return the price with a discount.
		/// ES: Caso de prueba - Pago en efectivo debe retornar el precio con un descuento.
		/// </summary>
		/// <returns>
		/// EN: The payment information.
		/// ES: La información de pago.
		/// </returns>
		private static PaymentInfoDto GetPriceForCashWithDiscount() => new()
		{
			PaymentMethodId = 2,
			TypeOfPayment = PaymentMethodType.Cash,
			Price = 1000.00M,
			PaymentChannelType = PaymentChannelType.InPerson
		};

		/// <summary>
		/// EN: Test case - Payment by debit card must return the same list price.
		/// ES: Caso de prueba - Pago con tarjeta de débito debe retornar el mismo precio de lista.
		/// </summary>
		/// <returns>
		/// EN: The payment information.
		/// ES: La información de pago.
		/// </returns>
		private static PaymentInfoDto GetPriceForDebitCardWithListPrice() => new()
		{
			PaymentMethodId = 3,
			TypeOfPayment = PaymentMethodType.DebitCard,
			Price = 1000.00M,
			PaymentChannelType = PaymentChannelType.InPerson
		};

		/// <summary>
		/// EN: Test case - You must return the list price when choosing a credit card in one payment only.
		/// ES: Caso de prueba - Debe retornar el precio de lista cuando se elige una tarjeta de crédito en un pago sólo.
		/// </summary>
		/// <returns>
		/// EN: The payment information.
		/// ES: La información de pago.
		/// </returns>
		private static PaymentInfoDto GetPriceForCreditCardWithListPriceInOnePayment() => new()
		{
			PaymentMethodId = 4,
			TypeOfPayment = PaymentMethodType.CreditCard,
			Price = 1000.00M,
			NumberOfPayments = 1,
			CardCompany = CardCompany.VICARD,
			PaymentChannelType = PaymentChannelType.InPerson
		};

		/// <summary>
		/// EN: Test case - You must return the final price when choosing a credit card in a payment with a charge for payment with it.
		/// ES: Caso de prueba - Debe retornar el precio final cuando se elige una tarjeta de crédito en un pago con un cargo por pago con la misma.
		/// </summary>
		/// <returns>
		/// EN: The payment information.
		/// ES: La información de pago.
		/// </returns>
		private static PaymentInfoDto GetPriceForCreditCardWithExtraChargeInOnePayment() => new()
		{
			PaymentMethodId = 5,
			TypeOfPayment = PaymentMethodType.CreditCard,
			Price = 1000.00M,
			NumberOfPayments = 1,
			CardCompany = CardCompany.VICARD,
			PaymentChannelType = PaymentChannelType.InPerson
		};

		/// <summary>
		/// EN: Test case - You must return the final price when you choose the VICARD credit card with payments in 3 payments.
		/// ES: Caso de prueba - Debe retornar el precio final cuando se elige la tarjeta de crédito VICARD con pagos en 3 cuotas.
		/// </summary>
		/// <returns>
		/// EN: The payment information.
		/// ES: La información de pago.
		/// </returns>
		private static PaymentInfoDto GetPriceForCreditCardViCardWith3Payments() => new()
		{
			PaymentMethodId = 6,
			TypeOfPayment = PaymentMethodType.CreditCard,
			Price = 1000.00M,
			NumberOfPayments = 3,
			CardCompany = CardCompany.VICARD,
			PaymentChannelType = PaymentChannelType.InPerson
		};

		/// <summary>
		/// EN: Test case - You must return the final price when you choose the VICARD credit card with payments in 6 payments.
		/// ES: Caso de prueba - Debe retornar el precio final cuando se elige la tarjeta de crédito VICARD con pagos en 6 cuotas.
		/// </summary>
		/// <returns>
		/// EN: The payment information.
		/// ES: La información de pago.
		/// </returns>
		private static PaymentInfoDto GetPriceForCreditCardViCardWith6Payments() => new()
		{
			PaymentMethodId = 6,
			TypeOfPayment = PaymentMethodType.CreditCard,
			Price = 1000.00M,
			NumberOfPayments = 6,
			CardCompany = CardCompany.VICARD,
			PaymentChannelType = PaymentChannelType.InPerson
		};

		/// <summary>
		/// EN: Test case - You must return the final price when you choose the VICARD credit card with payments in 12 payments.
		/// ES: Caso de prueba - Debe retornar el precio final cuando se elige la tarjeta de crédito VICARD con pagos en 12 cuotas.
		/// </summary>
		/// <returns>
		/// EN: The payment information.
		/// ES: La información de pago.
		/// </returns>
		private static PaymentInfoDto GetPriceForCreditCardViCardWith12Payments() => new()
		{
			PaymentMethodId = 6,
			TypeOfPayment = PaymentMethodType.CreditCard,
			Price = 1000.00M,
			NumberOfPayments = 12,
			CardCompany = CardCompany.VICARD,
			PaymentChannelType = PaymentChannelType.InPerson
		};

		/// <summary>
		/// EN: Test case - You must return the final price when you choose the VICARD credit card with payments in 18 payments.
		/// ES: Caso de prueba - Debe retornar el precio final cuando se elige la tarjeta de crédito VICARD con pagos en 18 cuotas.
		/// </summary>
		/// <returns>
		/// EN: The payment information.
		/// ES: La información de pago.
		/// </returns>
		private static PaymentInfoDto GetPriceForCreditCardViCardWith18Payments() => new()
		{
			PaymentMethodId = 6,
			TypeOfPayment = PaymentMethodType.CreditCard,
			Price = 1000.00M,
			NumberOfPayments = 18,
			CardCompany = CardCompany.VICARD,
			PaymentChannelType = PaymentChannelType.InPerson
		};

		/// <summary>
		/// EN: Test case - You must return the final price when you choose the ACARD credit card with payments in 3 payments.
		/// ES: Caso de prueba - Debe retornar el precio final cuando se elige la tarjeta de crédito ACARD con pagos en 3 cuotas.
		/// </summary>
		/// <returns>
		/// EN: The payment information.
		/// ES: La información de pago.
		/// </returns>
		private static PaymentInfoDto GetPriceForCreditCardAcardWith3Payments() => new()
		{
			PaymentMethodId = 6,
			TypeOfPayment = PaymentMethodType.CreditCard,
			Price = 1000.00M,
			NumberOfPayments = 3,
			CardCompany = CardCompany.ACARD,
			PaymentChannelType = PaymentChannelType.InPerson
		};

		/// <summary>
		/// EN: Test case - You must return the final price when you choose the ACARD credit card with payments in 6 payments.
		/// ES: Caso de prueba - Debe retornar el precio final cuando se elige la tarjeta de crédito ACARD con pagos en 6 cuotas.
		/// </summary>
		/// <returns>
		/// EN: The payment information.
		/// ES: La información de pago.
		/// </returns>
		private static PaymentInfoDto GetPriceForCreditCardAcardWith6Payments() => new()
		{
			PaymentMethodId = 6,
			TypeOfPayment = PaymentMethodType.CreditCard,
			Price = 1000.00M,
			NumberOfPayments = 6,
			CardCompany = CardCompany.ACARD,
			PaymentChannelType = PaymentChannelType.InPerson
		};

		/// <summary>
		/// EN: Test case - You must return the final price when you choose the ACARD credit card with payments in 12 payments.
		/// ES: Caso de prueba - Debe retornar el precio final cuando se elige la tarjeta de crédito ACARD con pagos en 12 cuotas.
		/// </summary>
		/// <returns>
		/// EN: The payment information.
		/// ES: La información de pago.
		/// </returns>
		private static PaymentInfoDto GetPriceForCreditCardAcardWith12Payments() => new()
		{
			PaymentMethodId = 6,
			TypeOfPayment = PaymentMethodType.CreditCard,
			Price = 1000.00M,
			NumberOfPayments = 12,
			CardCompany = CardCompany.ACARD,
			PaymentChannelType = PaymentChannelType.InPerson
		};

		/// <summary>
		/// EN: Test case - You must return the final price when you choose the MYCARD credit card with payments in 3 payments.
		/// ES: Caso de prueba - Debe retornar el precio final cuando se elige la tarjeta de crédito MYCARD con pagos en 3 cuotas.
		/// </summary>
		/// <returns>
		/// EN: The payment information.
		/// ES: La información de pago.
		/// </returns>
		private static PaymentInfoDto GetPriceForCreditCardMyCardWith3Payments() => new()
		{
			PaymentMethodId = 6,
			TypeOfPayment = PaymentMethodType.CreditCard,
			Price = 1000.00M,
			NumberOfPayments = 3,
			CardCompany = CardCompany.MYCARD,
			PaymentChannelType = PaymentChannelType.InPerson
		};

		/// <summary>
		/// EN: Test case - You must return the final price when you choose the MYCARD credit card with payments in 6 payments.
		/// ES: Caso de prueba - Debe retornar el precio final cuando se elige la tarjeta de crédito MYCARD con pagos en 6 cuotas.
		/// </summary>
		/// <returns>
		/// EN: The payment information.
		/// ES: La información de pago.
		/// </returns>
		private static PaymentInfoDto GetPriceForCreditCardMyCardWith6Payments() => new()
		{
			PaymentMethodId = 6,
			TypeOfPayment = PaymentMethodType.CreditCard,
			Price = 1000.00M,
			NumberOfPayments = 6,
			CardCompany = CardCompany.MYCARD,
			PaymentChannelType = PaymentChannelType.InPerson
		};

		/// <summary>
		/// EN: Test case - It must return an error because the chosen payment plan does not exist for the selected credit card.
		/// ES: Caso de prueba - Debe retornar error porque el plan de pagos elegido no existe para la tarjeta de crédito seleccionada.
		/// </summary>
		/// <returns>
		/// EN: The payment information.
		/// ES: La información de pago.
		/// </returns>
		private static PaymentInfoDto GetPriceForCreditCardNoExistingPlan() => new()
		{
			PaymentMethodId = 6,
			TypeOfPayment = PaymentMethodType.CreditCard,
			Price = 1000.00M,
			NumberOfPayments = 12,
			CardCompany = CardCompany.MYCARD,
			PaymentChannelType = PaymentChannelType.InPerson
		};

		/// <summary>
		/// EN: Test case - It should generate an error because the payment method chosen for the payment channel In Person does not exist.
		/// ES: Caso de prueba - Debe generar un error porque el método de pago elegido para el canal de pago En Persona no existe.
		/// </summary>
		/// <returns>
		/// EN: The payment information.
		/// ES: La información de pago.
		/// </returns>
		private static PaymentInfoDto GetPriceThroughInPersonChannelWithIncorrectPaymentMethod() => new()
		{
			PaymentMethodId = 1,
			TypeOfPayment = PaymentMethodType.Digital,
			Price = 1000.00M,
			PaymentChannelType = PaymentChannelType.InPerson
		};
	}
}

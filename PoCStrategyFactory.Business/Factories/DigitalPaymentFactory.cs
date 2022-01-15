using PoCStrategyFactory.Business.PriceStrategies;
using PoCStrategyFactory.Business.SeedWork;
using PoCStrategyFactory.Data;
using System;

namespace PoCStrategyFactory.Business.Factories
{
	/// <summary>
	/// EN: Factory that solves the appropriate strategy for payments made by digital means and based on the payment method.
	/// ES: Factory que resuelve la estrategia adecuada para los pagos hechos por medios digitales y basada en el método de pago.
	/// </summary>
	internal class DigitalPaymentFactory : PaymentFactory
	{
		/// <summary>
		/// EN: It allows to obtain the appropriate strategy based on the type of payment method.
		/// ES: Permite obtener la estrategia adecuada basada en el tipo de método de pago.
		/// </summary>
		/// <param name="paymentMethodType">
		/// EN: Type of payment method.
		/// ES: Tipo de método de pago.
		/// </param>
		/// <returns>
		/// EN: Returns the appropriate strategy for the type of payment method indicated.
		/// ES: Retorna la estrategia adecuada para el tipo de método de pago indicado.
		/// </returns>
		protected override IPriceStrategy GetPriceStrategy(PaymentMethodType paymentMethodType) => paymentMethodType switch
		{
			PaymentMethodType.Digital => new DigitalStrategy(),
			_ => throw new Exception($"The type of payment '{paymentMethodType}' doesn't exist or is not available.")
		};
	}
}

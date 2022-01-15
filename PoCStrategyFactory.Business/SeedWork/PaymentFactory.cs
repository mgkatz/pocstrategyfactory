using PoCStrategyFactory.Business.Models;
using PoCStrategyFactory.Data;
using PoCStrategyFactory.Business.Factories;
using System;

namespace PoCStrategyFactory.Business.SeedWork
{
	/// <summary>
	/// EN: Factory type base class that allows obtaining the appropriate factory with the appropriate strategy for calculating the final price.
	/// ES: Clase base de tipo factory que permite obtener la factory adecuada con la estrategia adecuada para el cálculo del precio final.
	/// </summary>
	internal abstract class PaymentFactory
	{
		/// <summary>
		/// EN: Method that allows a factory to obtain the appropriate strategy. Each factory that inherits must be responsible for implementing this method.
		/// ES: Método que le permite a una factory obtener la estrategia adecuada. Cada factory que herede debe ser responsable de implementar este método.
		/// </summary>
		/// <param name="paymentMethodType">
		/// EN: Type of payment method.
		/// ES: Tipo de método de pago.
		/// </param>
		/// <returns>
		/// EN: Returns the appropriate strategy for the type of payment method indicated.
		/// ES: Retorna la estrategia adecuada para el tipo de método de pago indicado.
		/// </returns>
		protected abstract IPriceStrategy GetPriceStrategy(PaymentMethodType paymentMethodType);

		/// <summary>
		/// EN: It allows the calculation of the final price according to the payment information provided. The method can be overridden by each factory if necessary.
		/// ES: Permite el cálculo del precio final de acuerdo a la información de pago proporcionada. El método puede ser sobreescrito por cada factory si fuera necesario.
		/// </summary>
		/// <param name="paymentInfo">
		/// EN: The payment information.
		/// ES: La información del pago.
		/// </param>
		/// <returns>
		/// EN: The final price.
		/// ES: El precio final.
		/// </returns>
		public virtual decimal CalculatePrice(PaymentInfoDto paymentInfo)
		{
			// EN: The specific factory that inherits from this class must be able to determine the appropriate strategy through its implementation of the GetPriceStrategy method.
			// ES: La factory específica que herede de esta clase, debe ser capaz de determinar la estrategia adecuada a través de la implementación que haya hecho del método GetPriceStrategy.
			IPriceStrategy priceStrategy = GetPriceStrategy(paymentInfo.TypeOfPayment);

			// EN: The returned strategy (it doesn't matter what it is specifically) will have a method that returns the final price based on the payment information.
			// ES: La estrategia retornada (no importa cuál sea específicamente) tendrá un método que retorne el precio final basado en la información del pago.
			return priceStrategy.GetFinalPrice(paymentInfo);
		}

		/// <summary>
		/// EN: It allows obtaining the appropriate factory according to the indicated payment channel.
		/// ES: Permite obtener la factory adecuada según el canal de pago indicado.
		/// </summary>
		/// <param name="paymentChannelType">
		/// EN: The type of payment channel.
		/// ES: El tipo de canal de pago.
		/// </param>
		/// <returns>
		/// EN: Returns the appropriate factory for the indicated payment channel.
		/// ES: Retorna la factory adecuada para el canal de pago indicado.
		/// </returns>
		public static PaymentFactory CreatePriceFactory(PaymentChannelType paymentChannelType) => paymentChannelType switch
		{
			PaymentChannelType.Digital => new DigitalPaymentFactory(),
			PaymentChannelType.InPerson => new InPersonPaymentFactory(),
			_ => throw new Exception($"The channel '{paymentChannelType}' is not available for payments.")
		};
	}
}

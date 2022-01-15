﻿using PoCStrategyFactory.Data;
using PoCStrategyFactory.Business.Extensions;
using PoCStrategyFactory.Business.Models;
using PoCStrategyFactory.Business.SeedWork;
using System;
using System.Linq;

namespace PoCStrategyFactory.Business.PriceStrategies
{
	/// <summary>
	/// EN: Strategy implemented for payment by credit card.
	/// ES: Estrategia implementada para el pago con tarjeta de crédito.
	/// </summary>
	internal class CreditCardStrategy : IPriceStrategy
	{
		/// <summary>
		/// EN: It allows the calculation of the final price according to the payment information provided.
		/// ES: Permite el cálculo del precio final de acuerdo a la información de pago proporcionada.
		/// </summary>
		/// <param name="paymentInfo">
		/// EN: The payment information.
		/// ES: La información del pago.
		/// </param>
		/// <returns>
		/// EN: The final price.
		/// ES: El precio final.
		/// </returns>
		public decimal GetFinalPrice(PaymentInfoDto paymentInfo)
		{
			// EN: In the case of credit cards, it will be mandatory to indicate the type of card, for that reason an error is validated and returned if it is not specified.
			// ES: En el caso de las tarjetas de crédito va a ser obligatorio indicar el tipo de tarjeta, por eso se valida y retorna un error en caso de que no esté especificado.
			if (!paymentInfo.CardCompany.HasValue)
				throw new Exception("The credit card company is mandatory. Please provide it.");

			// EN: We obtain the payment method information through a mock up that returns data simulating what the data layer would do.
			// ES: Obtenemos la información del método de pago a través de un mock que retorna datos simulando lo que haría la capa de datos.
			PaymentMethod paymentMethod = TestDataProvider.GetPaymentMethodInfo(paymentInfo.PaymentMethodId);

			// EN: If there isn't any payments plan in the information provided by the data layer and, using an extension method for the application of percentages, the final price is calculated and returned based on the original price and the percentage indicated by the information obtained. of the data layer.
			// ES: Si no hay plan de cuotas en la información que nos brinda la capa de datos y, usando un método de extensión para la aplicación de porcentajes, se calcula y se retorna el precio final basados en el precio original y el porcentaje que indica la información obtenida de la capa de datos.
			if (paymentMethod.PaymentPlans == null)
				return paymentInfo.Price.ApplyPercentage(paymentMethod.Percentage);

			// EN: Information on the payments plan to apply is obtained.
			// ES: Se obtiene la información sobre el plan de cuotas a aplicar.
			PaymentPlan paymentPlan = paymentMethod
				.PaymentPlans
				.SingleOrDefault(f => f.CardCompany == paymentInfo.CardCompany && f.NumberOfPayments == paymentInfo.NumberOfPayments);

			// EN: If there are no details regarding the payment plan chosen for the indicated credit card, an error will be returned. Otherwise, using an extension method for applying percentages, the final price is calculated and returned based on the original price and the percentage indicated by the information obtained from the data layer.
			// ES: Si no hay detalles respecto al plan de cuotas elegido para la tarjeta de crédito indicada se retornará un error. De lo contrario, usando un método de extensión para la aplicación de porcentajes, se calcula y se retorna el precio final basados en el precio original y el porcentaje que indica la información obtenida de la capa de datos.
			return paymentPlan == null
                ? throw new Exception($"A plan in {paymentInfo.NumberOfPayments} payments with {paymentInfo.CardCompany} credit card is not possible because the card is not providing that plan.")
				: paymentInfo.Price.ApplyPercentage(paymentPlan.Percentage);
		}
	}
}

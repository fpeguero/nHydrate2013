//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Linq;

namespace Acme.Northwind.EFDAL.Interfaces.Entity
{
	/// <summary>
	/// This is the interface for the entity CustOrdersDetail
	/// </summary>
	[System.CodeDom.Compiler.GeneratedCode("nHydrateModelGenerator", "5.1.2")]
	public partial interface ICustOrdersDetail
	{
		#region Properties

		/// <summary>
		/// The property for the field 'Discount'
		/// </summary>
		int? Discount { get; }

		/// <summary>
		/// The property for the field 'ExtendedPrice'
		/// </summary>
		decimal? ExtendedPrice { get; }

		/// <summary>
		/// The property for the field 'ProductName'
		/// </summary>
		string ProductName { get; }

		/// <summary>
		/// The property for the field 'Quantity'
		/// </summary>
		short? Quantity { get; }

		/// <summary>
		/// The property for the field 'UnitPrice'
		/// </summary>
		decimal? UnitPrice { get; }

		#endregion

	}

}


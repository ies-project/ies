﻿using System;
namespace ICT.DAL.DB
{
	/// <summary>
	/// Area class
	/// </summary>
	public class Area
	{
		/// <summary>
		/// Primary key of Area
		/// </summary>
        [Key]
		public int Id { get; set; }
		/// <summary>
		/// Foreign key from the table Building
		/// </summary>
		public int Id_Building { get; set; }
		public virtual Building Building { get; set; }
		/// <summary>
		/// Foreign key from the table Area Type
		/// </summary>
		public int Id_Type { get; set; }
		/// <summary>
		/// Name of the Area
		/// </summary>
		[StringLength(32)]
		public string Name { get; set; }
		/// <summary>
		/// Area FLoor
		/// </summary>
		[StringLength(32)]
		public string Floor { get; set; }
		/// <summary>
		/// Number of Fire Balls in a Area
		/// </summary>
		public int NumFireBalls { get; set; }
		/// <summary>
		/// Number of Springles in a Area
		/// </summary>
		public int NumSpringles { get; set; }
		/// <summary>
		/// Number of Bocas Singulares in a Area
		/// </summary>
		public int NumBocasSingulares { get; set; }
		/// <summary>
		/// Number of Bocas Siameses in a Area
		/// </summary>
		public int NumBocasSiameses { get; set; }

	}
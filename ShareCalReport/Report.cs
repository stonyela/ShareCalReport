using System;
namespace ShareCalReport
{
	public class Report
	{
		public Report()
		{

		}
		public string ProductName { get; set; }
		public int DrawNumber { get; set; }
		public int RolloverNumber { get; set; }
		public double NextRollOverAmount { get; set; }
		public List<int> ShareDivisions { get; set; } = new List<int>();
		public List<double> ShareValuePerDivision { get; set; } = new List<double>();
        public List<int> NumberOfSharePerDivision { get; set; } = new List<int>();
        public List<double> PayoutAmountPerDivision { get; set; } = new List<double>();
    }
}


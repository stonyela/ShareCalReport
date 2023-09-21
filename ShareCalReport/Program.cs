// See https://aka.ms/new-console-template for more information
using System.Xml.Linq;
using ShareCalReport;

string directory = "/Users/sinovuyotonyela/Downloads";

var files = Directory.GetFiles(directory).Where(x => x.EndsWith("rep")).ToList();

if (files.Count() == 0)
{
    Console.WriteLine("Nothing to process");
}
else
{
    Console.WriteLine(new string('-', 106));

    foreach (var file in files)
    {
        if (file.Contains("008"))
            DisplayLotto(file);
        else if (file.Contains("012"))
            DisplayPowerball(file);
        else if (file.Contains("013"))
            DisplayDailyLotto(file);
    }
}

static void DisplayLotto(string file)
{
    int lineCount = 0;

    var rep1 = new Report();
    var rep2 = new Report();
    var rep3 = new Report();

    rep1.ProductName = rep2.ProductName = rep3.ProductName = "LOTTO";

    using (StreamReader reader = new StreamReader($"{file}"))
    {
        while (reader.EndOfStream == false)
        {
            lineCount++;
            var c = reader.ReadLine();

            if (lineCount == 4)
            {
                var a = ParseLine(c);
                rep1.DrawNumber = rep2.DrawNumber = rep3.DrawNumber = int.Parse(a.Last());
            }

            if (lineCount == 6)
            {
                var a = ParseLine(c);
                rep1.RolloverNumber = int.Parse(a.Last());

            }

            if (lineCount > 7 && lineCount < 16)
            {
                var a = ParseLine(c);

                rep1.ShareDivisions.Add(int.Parse(a[0]));
                rep1.ShareValuePerDivision.Add(double.Parse(a[1].Replace("R", "")));
                rep1.NumberOfSharePerDivision.Add(int.Parse(a[2]));
                rep1.PayoutAmountPerDivision.Add(double.Parse(a[3].Replace("R", "")));

                rep1.NextRollOverAmount += double.Parse(a[4].Replace("R", ""));

            }

            if (lineCount == 65)
            {
                var a = ParseLine(c);
                rep2.RolloverNumber = int.Parse(a.Last());

            }

            if (lineCount > 66 && lineCount < 75)
            {
                var a = ParseLine(c);

                rep2.ShareDivisions.Add(int.Parse(a[0]));
                rep2.ShareValuePerDivision.Add(double.Parse(a[1].Replace("R", "")));
                rep2.NumberOfSharePerDivision.Add(int.Parse(a[2]));
                rep2.PayoutAmountPerDivision.Add(double.Parse(a[3].Replace("R", "")));

                rep2.NextRollOverAmount += double.Parse(a[4].Replace("R", ""));

            }

            if (lineCount == 126)
            {
                var a = ParseLine(c);
                rep3.RolloverNumber = int.Parse(a.Last());

            }

            if (lineCount > 127 && lineCount < 136)
            {
                var a = ParseLine(c);

                rep3.ShareDivisions.Add(int.Parse(a[0]));
                rep3.ShareValuePerDivision.Add(double.Parse(a[1].Replace("R", "")));
                rep3.NumberOfSharePerDivision.Add(int.Parse(a[2]));
                rep3.PayoutAmountPerDivision.Add(double.Parse(a[3].Replace("R", "")));

                rep3.NextRollOverAmount += double.Parse(a[4].Replace("R", ""));
            }
        }

    }

    Display(rep1);
    Display(rep2);
    Display(rep3);
}

static void DisplayPowerball(string file)
{
    int lineCount = 0;

    var rep1 = new Report();
    var rep2 = new Report();

    rep1.ProductName= rep2.ProductName = "POWERBALL";

    using (StreamReader reader = new StreamReader($"{file}"))
    {
        while (reader.EndOfStream == false)
        {
            lineCount++;
            var c = reader.ReadLine();

            if (lineCount == 4)
            {
                var a = ParseLine(c);
                rep1.DrawNumber = rep2.DrawNumber = int.Parse(a.Last());
            }

            if (lineCount == 6)
            {
                var a = ParseLine(c);
                rep1.RolloverNumber = int.Parse(a.Last());

            }

            if (lineCount > 7 && lineCount < 16)
            {
                var a = ParseLine(c);

                rep1.ShareDivisions.Add(int.Parse(a[0]));
                rep1.ShareValuePerDivision.Add(double.Parse(a[1].Replace("R", "")));
                rep1.NumberOfSharePerDivision.Add(int.Parse(a[2]));
                rep1.PayoutAmountPerDivision.Add(double.Parse(a[3].Replace("R", "")));

                rep1.NextRollOverAmount += double.Parse(a[4].Replace("R", ""));

            }

            if (lineCount == 65)
            {
                var a = ParseLine(c);
                rep2.RolloverNumber = int.Parse(a.Last());

            }

            if (lineCount > 66 && lineCount < 75)
            {
                var a = ParseLine(c);

                rep2.ShareDivisions.Add(int.Parse(a[0]));
                rep2.ShareValuePerDivision.Add(double.Parse(a[1].Replace("R", "")));
                rep2.NumberOfSharePerDivision.Add(int.Parse(a[2]));
                rep2.PayoutAmountPerDivision.Add(double.Parse(a[3].Replace("R", "")));

                rep2.NextRollOverAmount += double.Parse(a[4].Replace("R", ""));

            }
        }

        Display(rep1);
        Display(rep2);
    }
}

static void DisplayDailyLotto(string file)
{
    int lineCount = 0;
    var rep1 = new Report();

    rep1.ProductName = "DAILY LOTTO";

    using (StreamReader reader = new StreamReader($"{file}"))
    {
        while (reader.EndOfStream == false)
        {
            lineCount++;
            var c = reader.ReadLine();

            if (lineCount == 4)
            {
                var a = ParseLine(c);
                rep1.DrawNumber = int.Parse(a.Last());
            }

            if (lineCount == 6)
            {
                var a = ParseLine(c);
                rep1.RolloverNumber = int.Parse(a.Last());

            }

            if (lineCount > 7 && lineCount < 12)
            {
                var a = ParseLine(c);

                rep1.ShareDivisions.Add(int.Parse(a[0]));
                rep1.ShareValuePerDivision.Add(double.Parse(a[1].Replace("R", "")));
                rep1.NumberOfSharePerDivision.Add(int.Parse(a[2]));
                rep1.PayoutAmountPerDivision.Add(double.Parse(a[3].Replace("R", "")));

                rep1.NextRollOverAmount += double.Parse(a[4].Replace("R", ""));

            }
        }
    }

    Display(rep1);
}

static void Display(Report rep)
{
    Console.WriteLine("|{0,20}|{1,20}|{2,20}|{3,20}|{4,20}|", "Product Name", rep.ProductName, "", "Draw Number", rep.DrawNumber);
    Console.WriteLine(new string('-', 106));
    Console.WriteLine("|{0,20}|{1,20}|{2,20}|{3,20}|{4,20}|", "Next Draw Rollover", rep.NextRollOverAmount, "", "Rollover Number", rep.RolloverNumber);
    Console.WriteLine(new string('-', 106));
    Console.WriteLine("|{0,20}|{1,20}|{2,20}|{3,20}|{4,20}|", "Div", "Share value", "Nbr of Shares", "Payout Amount", "");
    Console.WriteLine(new string('-', 106));
    Console.WriteLine("|{0,20}|{1,20}|{2,20}|{3,20}|{4,20}|", "", "", "", "", "");
    Console.WriteLine(new string('-', 106));

    for (int i = 0; i < rep.ShareDivisions.Count; i++)
    {
        Console.WriteLine("|{0,20}|{1,20}|{2,20}|{3,20}|{4,20}|", rep.ShareDivisions[i], rep.ShareValuePerDivision[i],
            rep.NumberOfSharePerDivision[i], rep.PayoutAmountPerDivision[i], "");
        Console.WriteLine(new string('-', 106));
    }
}

static List<string> ParseLine(string line)
{
    return line.Split(' ').Where(x => x != "").ToList();

}


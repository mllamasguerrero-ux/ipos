using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace iPos
{
    public class UpcLabel
    {

        private string upc;

        public UpcLabel(string upc)
        {
            if (upc == null)
            {
                throw new ArgumentNullException("upc");
            }

            this.upc = upc;
        }

        public void Print(string printerName)
        {
            StringBuilder sb;

            if (printerName == null)
            {
                throw new ArgumentNullException("printerName");
            }

            sb = new StringBuilder();
            sb.AppendLine();
            sb.AppendLine("N");
            sb.AppendLine("q609");
            sb.AppendLine("Q203,26");
            sb.AppendLine(string.Format(
                CultureInfo.InvariantCulture,
                "B26,26,0,UA0,2,2,152,B,\"{0}\"",
                this.upc));
            sb.AppendLine("P1,1");

            RawPrinterHelperZebra.SendStringToPrinter(printerName, sb.ToString());
        }
    }
}

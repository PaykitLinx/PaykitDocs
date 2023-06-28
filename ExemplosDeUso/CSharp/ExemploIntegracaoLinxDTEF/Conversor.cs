using System;

namespace LinxDTEF
{
  public class Conversor
  {
    public static string DecimalToString(Decimal dValor, int iCasasDecimaisEntraValor)
    {
      string sMascara = "{0:#,##0." + String.Empty.PadRight(iCasasDecimaisEntraValor, '0') + "}";

      return String.Format(sMascara, dValor);
    }

    public static Decimal ToDecimalDef(string sValor, Decimal dDefault)
    {
      Decimal d = 0;
      try
      {
        if (!Decimal.TryParse(sValor, out d))
          d = dDefault;
      }
      catch (Exception ex)
      {
        d = dDefault;
      }

      return d;
    }

    public static int ToIntDef(string sValor, int iDefault)
    {
      int i = 0;
      try
      {
        if (!Int32.TryParse(sValor, out i))
          i = iDefault;
      }
      catch (Exception ex)
      {
        i = iDefault;
      }

      return i;
    }

  }
}

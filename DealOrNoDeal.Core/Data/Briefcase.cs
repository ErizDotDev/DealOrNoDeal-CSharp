namespace DealOrNoDeal.Core.Data
{
   public class Briefcase
   {
      public int Number { get; set; }
      public double Amount { get; set; }

      public string FullAmount
      {
         get { return $"PHP{Amount.ToString()}"; }
      }
   }
}

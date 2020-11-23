// given a list of currency exchange rates like this:

// EUR/USD => 1.2
// USD/GBP => 0.75
// GBP/AUD => 1.7
// AUD/JPY => 90
// GBP/JPY => 150
// EUR/AUD => 1.61
// JPY/INR => 0.6
// CAD/MXN => 16.74

// write a method which gives the highest possible conversion amount, and writes out the conversion steps!

// double convert(String inputCurrency, String outputCurrency, double amount)

// eg.:
// convert(AUD, EUR, 100.0)
// convert(AUD, MXN, 100.0)

using System.Collections.Generic;
using System.Linq;

namespace challenge.Application
{
    public class Convertion
    {
        public string Input { get; set; }
        public string Output { get; set; }
        public double Rate { get; set; }
    }
    public class CurrencyConversion
    {

        public static readonly List<Convertion> conversionList = new List<Convertion>()
        {
            new Convertion(){Input = "EUR", Output = "USD", Rate = 1.2},
            new Convertion(){Input = "USD", Output = "GBP", Rate = 0.75},
            new Convertion(){Input = "GBP", Output = "AUD", Rate = 1.7},
            new Convertion(){Input = "AUD", Output = "JPY", Rate = 90},
            new Convertion(){Input = "GBP", Output = "JPY", Rate = 150},
            new Convertion(){Input = "EUR", Output = "AUD", Rate = 1.61},
            new Convertion(){Input = "JPY", Output = "INR", Rate = 0.6},
            new Convertion(){Input = "CAD", Output = "MXN", Rate = 16.74}
        };

        private List<Convertion> cashedConversion
        = new List<Convertion>();

        private List<double> convertAmountList = new List<double>();
        public double Convert(string inputCurrency, string outputCurrency, double amount)
        {

            //find availble conversion by current input
            var availbaleConversionList =
            conversionList.Where(x => x.Input == inputCurrency
                                    || x.Output == inputCurrency).ToList();


            foreach (var conversion in availbaleConversionList)
            {
                var newConversion = CorrectConvertion(conversion,inputCurrency);
                cashedConversion = new List<Convertion>()
                {
                    new Convertion(){Output = newConversion.Output},
                    new Convertion(){Output = newConversion.Input},
                };

                
                var convertedAmount = amount * newConversion.Rate;
                if (newConversion.Output == outputCurrency)
                {
                    // add to final converstion list.
                    convertAmountList.Add(convertedAmount);
                    continue;
                }
                ConvertByCheckingCycle(newConversion.Output, outputCurrency, convertedAmount);

            }
            if(convertAmountList.Count >0)
            {
                return convertAmountList.Max(x=> x);
            }
            return 0;
            

        }

        private void ConvertByCheckingCycle
        (string inputCurrency, string outputCurrency, double amount)
        {
            var availbaleConversionList =
               conversionList.Where(x => x.Input == inputCurrency
                                  || x.Output == inputCurrency).ToList();

            foreach (var conversion in availbaleConversionList)
            {
                var newConversion = CorrectConvertion(conversion,inputCurrency);
                

                //check if this output used before.
                if (cashedConversion.Exists(x => x.Output == newConversion.Output))
                {
                    continue;
                }
                else
                {
                    //add the output is not the final output add to cash
                    //avoiding currency conversion cycle 
                    if(newConversion.Output != outputCurrency)
                    {
                             cashedConversion.Add(new Convertion() { Output = newConversion.Output });
                    }
                    
                  
                }

                //convert to new output
                var convertedAmount = amount * newConversion.Rate;

                //check if the output is the request conversion output
                if (newConversion.Output == outputCurrency)
                {
                    // add to final converstion list.
                    convertAmountList.Add(convertedAmount);
                    continue;
                }
                
                // call it self to convert to new output
                ConvertByCheckingCycle(newConversion.Output, outputCurrency, convertedAmount);
                continue;
                
            }

        }
        private Convertion CorrectConvertion(Convertion conversion, string input)
        {

            if (conversion.Input == input)
            {
                return conversion;
            }
            return new Convertion()
            {
                Input = conversion.Output,
                Output = conversion.Input,
                Rate = 1 / conversion.Rate
            };

        }
    }
}
using CtoHomework.Data;
using CtoHomework.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Net;
using System.Text.Json;
using System.Text.RegularExpressions;
using Newtonsoft.Json.Linq;

namespace CtoHomework.Controllers
{
    [ApiController]
    public class CalculationsController : Controller
    {
        private readonly CtoHomeworkDbContext _context;
        public CalculationsController(CtoHomeworkDbContext ctoHomeworkDbContext)
        {
            this._context = ctoHomeworkDbContext;
        }

        [HttpGet]
        [Route("calculate/{number1}/{number2}/{operation}")]
        public IActionResult Calculate(int number1, int number2, string operation)
        {
            double result = 0;

            switch (operation)
            {
                case "+":
                    result = number1 + number2;
                    break;
                case "-":
                    result = number1 - number2;
                    break;
                case "*":
                    result = number1 * number2;
                    break;
                case "%2F":
                    if (number2 == 0)
                    {
                        return BadRequest("Cannot divide by zero");
                    }
                    operation = "/";
                    result = Convert.ToDouble(number1) / Convert.ToDouble(number2);
                    break;
                default:
                    return BadRequest("Invalid operation");
            }

            Calculator calculation = new Calculator();
            calculation.Operation = number1 + operation + number2;
            calculation.Result = result;

            _context.Calculations.Add(calculation);
            _context.SaveChanges();

            return Ok(calculation);
        }

        [HttpGet("calculate/{input}")]
        public IActionResult Calculate(string input)
        {
            // Check if the input contains no more than 5 digits
            if (!Regex.IsMatch(input, @"^\D*\d\D*\d?\D*\d?\D*\d?\D*\d?\D*$"))
            {
                return BadRequest("Input must contain no more than 5 numbers.");
            }

            input = input.Replace("div", "/");

            DataTable dt = new DataTable();
            object result = dt.Compute(input, "");
            double resultAsDouble = Convert.ToDouble(result);

            Calculator calculation = new Calculator();
            calculation.Operation = input;
            calculation.Result = resultAsDouble;

            _context.Calculations.Add(calculation);
            _context.SaveChanges();

            return Ok(calculation);
        }







        [HttpGet("compare/{input}")]
        public IActionResult GetHighestAndLowest(string input)
        {
            bool isMatch = Regex.IsMatch(input, @"^\d+(,\d+)*$");

            if (!isMatch)
            {
                return BadRequest("Invalid operation");
            }

            string[] parts = input.Split(',');
            int[] numbers = Array.ConvertAll(parts, int.Parse);
            int highest = numbers.Max();
            int lowest = numbers.Min();

            return Ok(highest + "," + lowest);
        }
        [HttpGet("countries")]
        public async Task<IActionResult> GetAllCountries()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("https://restcountries.com/v2/all");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();

            
            JsonDocument doc = JsonDocument.Parse(responseBody);
            JsonElement root = doc.RootElement;

            
            string[] countries = root.EnumerateArray()
                .Select(country => country.GetProperty("name").GetString())
                .OrderBy(name => name)
                .ToArray();


            string ipAddress = new WebClient().DownloadString("https://api.ipify.org");

            
            string apiAccessKey = "7ae31b331e7a08b18fbff4343a5af564";
            string apiUrl = $"http://api.ipstack.com/{ipAddress}?access_key={apiAccessKey}";

            
            string json = new WebClient().DownloadString(apiUrl);

            string country = JObject.Parse(json)["country_name"].ToString();

            CountriesInfo countriesInfo= new CountriesInfo();
            countriesInfo.countries = countries;
            countriesInfo.currentLocation= country;
            return Ok(countriesInfo);
        
        }
    }
}

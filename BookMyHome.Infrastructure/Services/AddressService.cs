using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Azure;
using BookMyHome.Domain.Entity.ValueObjects;
using BookMyHome.Domain.Enum;
using BookMyHome.Domain.Services;
using Microsoft.EntityFrameworkCore.Update;

namespace BookMyHome.Infrastructure.Services
{
    public class AddressService : IAddressService
    {
        private readonly HttpClient _httpClient;

        public AddressService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        //async Task<ValidStatus> IAddressService.ValidateAddress(Address address)
        //{
        //    var jsonContent = JsonSerializer.Serialize(address);
        //    var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");

        //    var response = await _httpClient.PostAsync($"/validateaddress", httpContent);

        //    if (response.IsSuccessStatusCode)
        //    {
        //        var responseContent = await response.Content.ReadAsStringAsync();
        //        var validationResponse = JsonSerializer.Deserialize<AddressValidationResponse>(responseContent);

        //        return validationResponse.Status switch
        //        {
        //            "Valid" => ValidStatus.Valid,
        //            "Invalid" => ValidStatus.Invalid,
        //            "Pending" => ValidStatus.Pending,
        //        };
        //    }

        //    return ValidStatus.Invalid;
        //}


        async Task<ValidStatus> IAddressService.ValidateAddress(Address address)
        {
            var response = await _httpClient.PostAsJsonAsync($"/validateaddress", address);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();

                Console.WriteLine(result);
                if (result.Trim('"') == "Valid")
                {
                    return ValidStatus.Valid;
                }
            }
            var result2 = await response.Content.ReadAsStringAsync();
            Console.WriteLine(result2);
            return ValidStatus.Invalid;
        }
    }
}

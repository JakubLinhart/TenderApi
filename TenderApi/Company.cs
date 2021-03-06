﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using TenderApi.Model;

namespace TenderApi
{
    public partial class TenderApi
    {
        public List<Company> GetCompanies()
        {
            return GetCollection<Company>("companies", "companies");
        }

        public Company CreateCompany(string name)
        {
            var request = new RestRequest
            {
                Method = Method.POST,
                RequestFormat = RestSharp.DataFormat.Json,
                Resource = "companies",
                RootElement = "companies",
            };

            request.AddParameter("name", name);

            var response = _client.Execute<List<Company>>(request);

            if (response.Data != null)
            {
                return response.Data.FirstOrDefault();    
            }
            else
            {
                return null;
            }
        }
    }
}

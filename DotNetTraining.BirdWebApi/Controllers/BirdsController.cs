using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetTraining.BirdWebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DotNetTraining.BirdWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BirdsController : Controller
    {
        private readonly string _url = "https://burma-project-ideas.vercel.app/birds";
        // GET: api/values
        [HttpGet]
        public async Task<IActionResult> Get()
        {

            HttpClient httpClient = new HttpClient();
            var response = await httpClient.GetAsync($"{_url}");
            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                List<BirdDataModel> birdDataList = JsonConvert.DeserializeObject<List<BirdDataModel>>(json)!;

                List<BirdViewModel> lst = birdDataList.Select(bird => Change(bird)).ToList();
                //string jsonReturn = JsonConvert.SerializeObject(lst);
                return Ok(lst); // Return the processed data instead of the original JSON string
            }
            else
            {
                return BadRequest();
            }


        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.GetAsync($"{_url}/{id}");
            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                BirdDataModel? birdDataList = JsonConvert.DeserializeObject<BirdDataModel>(json);

                if (birdDataList != null)
                {
                    BirdViewModel lst = Change(birdDataList);
                    return Ok(lst);
                } else
                {
                    return Ok("Not Found");
                }    
               
            }
            else
            {
                return BadRequest();
            }
        }

        private BirdViewModel Change(BirdDataModel bird)
        {
            return new BirdViewModel
            {
                BirdId = bird.Id,
                BirdName = bird.BirdMyanmarName,
                Desc = bird.Description,
                Image = $"https://burma-project-ideas.vercel.app/{bird.ImagePath}"
            };
        }
    }
}

